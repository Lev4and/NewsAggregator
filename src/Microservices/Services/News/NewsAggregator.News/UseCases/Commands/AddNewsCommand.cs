using Amazon.Runtime.Internal.Util;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using NewsAggregator.Domain.Infrastructure.Databases;
using NewsAggregator.Domain.Infrastructure.MessageBrokers;
using NewsAggregator.Domain.Repositories;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Exceptions;
using NewsAggregator.News.Extensions;
using NewsAggregator.News.Messages;
using NewsAggregator.News.Repositories;
using System.Runtime.CompilerServices;
using System.Transactions;

namespace NewsAggregator.News.UseCases.Commands
{
    public class AddNewsCommand : IRequest<bool>
    {
        public NewsDto News { get; }

        public AddNewsCommand(NewsDto news)
        {
            News = news;
        }

        public class Validator : AbstractValidator<AddNewsCommand>
        {
            public Validator()
            {
                RuleFor(command => command.News).NotNull();
            }
        }

        internal class Handler : IRequestHandler<AddNewsCommand, bool> 
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IRepository _repository;
            private readonly INewsEditorRepository _newsEditorRepository;
            private readonly INewsSourceRepository _newsSourceRepository;
            private readonly ILogger<Handler> _logger;

            public Handler(IUnitOfWork unitOfWork, IRepository repository,
                INewsEditorRepository newsEditorRepository, INewsSourceRepository newsSourceRepository, ILogger<Handler> logger)
            {
                _unitOfWork = unitOfWork;
                _repository = repository;
                _newsEditorRepository = newsEditorRepository;
                _newsSourceRepository = newsSourceRepository;
                _logger = logger;
            }

            public async Task<bool> Handle(AddNewsCommand request, CancellationToken cancellationToken)
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required,
                    new TransactionOptions() { IsolationLevel = IsolationLevel.RepeatableRead },
                        TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        var newsSourceSiteUri = new Uri(request.News.Url);

                        var newsSource = await _newsSourceRepository.FindNewsSourceBySiteUrlAsync(
                            newsSourceSiteUri.GetSiteUrl(), cancellationToken);

                        if (newsSource is null)
                        {
                            throw new NewsSourceNotFoundException(newsSourceSiteUri.Host);
                        }

                        var newsEditor = await _newsEditorRepository
                            .FindOneBySourceIdAndNameOrAddAsync(
                                new NewsEditor
                                {
                                    SourceId = newsSource.Id,
                                    Name = request.News.EditorName
                                },
                                newsSource.Id,
                                request.News.EditorName,
                                cancellationToken);

                        var news = new Entities.News
                        {
                            EditorId = newsEditor.Id,
                            Url = request.News.Url,
                            Title = request.News.Title,
                            PublishedAt = request.News.PublishedAt,
                            ModifiedAt = request.News.ModifiedAt,
                            ParsedAt = request.News.ParsedAt,
                            AddedAt = DateTime.UtcNow
                        };

                        _repository.Add(news);

                        if (!string.IsNullOrEmpty(request.News.SubTitle))
                        {
                            _repository.Add(
                                new NewsSubTitle
                                {
                                    NewsId = news.Id,
                                    Title = request.News.SubTitle
                                });
                        }

                        if (!string.IsNullOrEmpty(request.News.PictureUrl))
                        {
                            _repository.Add(
                                new NewsPicture
                                {
                                    NewsId = news.Id,
                                    Url = request.News.PictureUrl
                                });
                        }

                        if (!string.IsNullOrEmpty(request.News.VideoUrl))
                        {
                            _repository.Add(
                                new NewsVideo
                                {
                                    NewsId = news.Id,
                                    Url = request.News.VideoUrl
                                });
                        }

                        if (!string.IsNullOrEmpty(request.News.Description))
                        {
                            _repository.Add(
                                new NewsDescription
                                {
                                    NewsId = news.Id,
                                    Description = request.News.Description
                                });
                        }

                        await _unitOfWork.SaveChangesAsync(cancellationToken);

                        transaction.Complete();

                        return true;
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError("The add news {0} failed with an error {1}", request.News.Url, ex.Message);

                        return false;
                    }
                }
            }
        }

        internal class AddedNewsNotificationHandler : INotificationHandler<AddedNews>
        {
            private readonly IMessageBus _messageBus;
            private readonly ILogger<AddedNewsNotificationHandler> _logger;

            public AddedNewsNotificationHandler(IMessageBus messageBus, ILogger<AddedNewsNotificationHandler> logger)
            {
                _messageBus = messageBus;
                _logger = logger;
            }

            public async Task Handle(AddedNews notification, CancellationToken cancellationToken)
            {
                _logger.LogInformation("Added news {0}", notification.NewsUrl);

                await _messageBus.SendAsync(notification, cancellationToken);
            }
        }

        internal class ProcessedNewsNotificationHandler : INotificationHandler<ProcessedNews>
        {
            private readonly IMessageBus _messageBus;
            private readonly ILogger<ProcessedNewsNotificationHandler> _logger;

            public ProcessedNewsNotificationHandler(IMessageBus messageBus, ILogger<ProcessedNewsNotificationHandler> logger)
            {
                _messageBus = messageBus;
                _logger = logger;
            }

            public async Task Handle(ProcessedNews notification, CancellationToken cancellationToken)
            {
                _logger.LogInformation("Processed news {0}", notification.NewsUrl);

                await _messageBus.SendAsync(notification, cancellationToken);
            }
        }
    }
}
