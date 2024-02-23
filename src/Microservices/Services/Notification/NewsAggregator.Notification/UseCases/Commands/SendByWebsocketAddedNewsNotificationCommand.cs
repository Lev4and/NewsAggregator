using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using NewsAggregator.Notification.DTOs;
using NewsAggregator.Notification.Web.Hubs;

namespace NewsAggregator.Notification.UseCases.Commands
{
    public class SendByWebsocketAddedNewsNotificationCommand : IRequest
    {
        public News News { get; }

        public SendByWebsocketAddedNewsNotificationCommand(News news)
        {
            News = news;
        }

        internal class Validator : AbstractValidator<SendByWebsocketAddedNewsNotificationCommand>
        {
            public Validator()
            {
                RuleFor(command => command.News).NotNull();
            }
        }

        internal class Handler : IRequestHandler<SendByWebsocketAddedNewsNotificationCommand>
        {
            private readonly IHubContext<NewsNotificationHub> _context;
            private readonly ILogger<Handler> _logger;

            public Handler(IHubContext<NewsNotificationHub> context, ILogger<Handler> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async Task Handle(SendByWebsocketAddedNewsNotificationCommand request, CancellationToken cancellationToken)
            {
                _logger.LogInformation("Send by websocket added news notification {0}", request.News.Url);

                await _context.Clients.All.SendAsync("AddedNews", request.News, cancellationToken);
            }
        }
    }
}
