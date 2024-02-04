using FluentValidation;
using MediatR;
using NewsAggregator.Domain.Infrastructure.Databases;
using NewsAggregator.Domain.Repositories;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Exceptions;
using NewsAggregator.News.Messages;
using NewsAggregator.News.Repositories;

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

            public Handler(IUnitOfWork unitOfWork, IRepository repository,
                INewsEditorRepository newsEditorRepository, INewsSourceRepository newsSourceRepository)
            {
                _unitOfWork = unitOfWork;
                _repository = repository;
                _newsEditorRepository = newsEditorRepository;
                _newsSourceRepository = newsSourceRepository;
            }

            public async Task<bool> Handle(AddNewsCommand request, CancellationToken cancellationToken)
            {
                using (var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken))
                {
                    try
                    {
                        var newsSourceSiteUri = new Uri(request.News.Url);

                        var newsSource = await _newsSourceRepository.FindNewsSourceBySiteUrlAsync(
                            $"{newsSourceSiteUri.Scheme}://{newsSourceSiteUri.Host}/", cancellationToken);

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

                        await transaction.CommitAsync(cancellationToken);

                        return true;
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync(cancellationToken);

                        return false;
                    }
                }
            }
        }
    }
}
