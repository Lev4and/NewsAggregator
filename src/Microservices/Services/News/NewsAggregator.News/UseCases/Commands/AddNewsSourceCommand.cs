using FluentValidation;
using MediatR;
using NewsAggregator.Domain.Infrastructure.Databases.Repositories;
using NewsAggregator.Domain.Infrastructure.Databases;
using NewsAggregator.News.Databases.EntityFramework.News.Entities;
using NewsAggregator.Domain.Infrastructure.Caching;
using NewsAggregator.News.Databases.EntityFramework.News.Repositories;

namespace NewsAggregator.News.UseCases.Commands
{
    public class AddNewsSourceCommand : IRequest<bool>
    {
        public NewsSource NewsSource { get; }

        public AddNewsSourceCommand(NewsSource newsSource)
        {
            NewsSource = newsSource;
        }

        public class Validator : AbstractValidator<AddNewsSourceCommand>
        {
            public Validator()
            {
                RuleFor(command => command.NewsSource).NotNull();
            }
        }

        internal class Handler : IRequestHandler<AddNewsSourceCommand, bool> 
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IRepository _repository;

            public Handler(IUnitOfWork unitOfWork, IRepository repository)
            {
                _unitOfWork = unitOfWork;
                _repository = repository;
            }

            public async Task<bool> Handle(AddNewsSourceCommand request, CancellationToken cancellationToken)
            {
                using (var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken))
                {
                    try
                    {
                        _repository.Add(request.NewsSource);

                        if (request.NewsSource.Logo is not null)
                        {
                            request.NewsSource.Logo.SourceId = request.NewsSource.Id;

                            _repository.Add(request.NewsSource.Logo);
                        }

                        if (request.NewsSource.ParseSettings is not null)
                        {
                            request.NewsSource.ParseSettings.SourceId = request.NewsSource.Id;

                            _repository.Add(request.NewsSource.ParseSettings);

                            if (request.NewsSource.ParseSettings.ParseEditorSettings is not null)
                            {
                                request.NewsSource.ParseSettings.ParseEditorSettings.ParseSettingsId = 
                                    request.NewsSource.ParseSettings.Id;

                                _repository.Add(request.NewsSource.ParseSettings.ParseEditorSettings);
                            }

                            if (request.NewsSource.ParseSettings.ParsePictureSettings is not null)
                            {
                                request.NewsSource.ParseSettings.ParsePictureSettings.ParseSettingsId =
                                    request.NewsSource.ParseSettings.Id;

                                _repository.Add(request.NewsSource.ParseSettings.ParsePictureSettings);
                            }

                            if (request.NewsSource.ParseSettings.ParseSubTitleSettings is not null)
                            {
                                request.NewsSource.ParseSettings.ParseSubTitleSettings.ParseSettingsId =
                                    request.NewsSource.ParseSettings.Id;

                                _repository.Add(request.NewsSource.ParseSettings.ParseSubTitleSettings);
                            }

                            if (request.NewsSource.ParseSettings.ParsePublishedAtSettings is not null)
                            {
                                request.NewsSource.ParseSettings.ParsePublishedAtSettings.ParseSettingsId =
                                    request.NewsSource.ParseSettings.Id;

                                _repository.Add(request.NewsSource.ParseSettings.ParsePublishedAtSettings);
                            }
                        }

                        if (request.NewsSource.SearchSettings is not null)
                        {
                            request.NewsSource.SearchSettings.SourceId = request.NewsSource.Id;

                            _repository.Add(request.NewsSource.SearchSettings);
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
