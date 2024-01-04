namespace NewsAggregator.Domain.Infrastructure.MessageBrokers
{
    public interface IMessageBus
    {
        Task SendAsync<TMessage>(TMessage message, CancellationToken cancellationToken = default)
            where TMessage : class;
    }
}
