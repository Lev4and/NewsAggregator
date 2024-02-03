namespace NewsAggregator.Domain.Entities
{
    public class ResultModel<TResult>
    {
        public bool IsError => Exception != null;

        public TResult? Result { get; }

        public Exception? Exception { get; }

        public ResultModel(TResult? result, Exception? exception = null)
        {
            Result = result;
            Exception = exception;
        }
    }
}
