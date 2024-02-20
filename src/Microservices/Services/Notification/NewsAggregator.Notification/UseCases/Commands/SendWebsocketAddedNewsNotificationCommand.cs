using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using NewsAggregator.Notification.DTOs;
using NewsAggregator.Notification.Web.Hubs;

namespace NewsAggregator.Notification.UseCases.Commands
{
    public class SendWebsocketAddedNewsNotificationCommand : IRequest
    {
        public News News { get; }

        public SendWebsocketAddedNewsNotificationCommand(News news)
        {
            News = news;
        }

        internal class Validator : AbstractValidator<SendWebsocketAddedNewsNotificationCommand>
        {
            public Validator()
            {
                RuleFor(command => command.News).NotNull();
            }
        }

        internal class Handler : IRequestHandler<SendWebsocketAddedNewsNotificationCommand>
        {
            private readonly IHubContext<NewsNotificationHub> _context;

            public Handler(IHubContext<NewsNotificationHub> context)
            {
                _context = context;
            }

            public async Task Handle(SendWebsocketAddedNewsNotificationCommand request, CancellationToken cancellationToken)
            {
                await _context.Clients.All.SendAsync("AddedNews", request.News, cancellationToken);
            }
        }
    }
}
