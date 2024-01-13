﻿using FluentValidation;
using MediatR;
using NewsAggregator.Domain.Infrastructure.Caching;
using NewsAggregator.News.Databases.EntityFramework.News.Repositories;
using NewsAggregator.News.Exceptions;
using Entities = NewsAggregator.News.Databases.EntityFramework.News.Entities;

namespace NewsAggregator.News.UseCases.Queries
{
    public class GetNewsByUrlQuery : IRequest<Entities.News>
    {
        public string Url { get; }

        public GetNewsByUrlQuery(string url)
        {
            Url = url;
        }

        public class Validator : AbstractValidator<GetNewsByUrlQuery>
        {
            public Validator()
            {
                RuleFor(query => query.Url).NotEmpty();
            }
        }

        internal class Handler : IRequestHandler<GetNewsByUrlQuery, Entities.News>
        {
            private readonly INewsRepository _repository;
            private readonly IMemoryCache _memoryCache;

            public Handler(INewsRepository repository, IMemoryCache memoryCache)
            {
                _repository = repository;
                _memoryCache = memoryCache;
            }

            public async Task<Entities.News> Handle(GetNewsByUrlQuery request, CancellationToken cancellationToken)
            {
                return await _memoryCache.GetAsync($"news:{request.Url}",
                    async () =>
                    {
                        return await _repository.FindNewsByUrlAsync(request.Url, cancellationToken)
                            ?? throw new NewsNotFoundException(request.Url);
                    }, 
                    cancellationToken);
            }
        }
    }
}