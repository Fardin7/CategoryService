using Polly;
using Polly.Retry;

namespace CategoryService.Client
{
    public class ClientPolicy
    {
        public AsyncRetryPolicy<HttpResponseMessage> immediateRetryPolicy { get; }
        public AsyncRetryPolicy<HttpResponseMessage> linearRetryPolicy { get; }
        public AsyncRetryPolicy<HttpResponseMessage> exponentialRetryPolicy { get; }
        public ClientPolicy()
        {
            immediateRetryPolicy = Policy.HandleResult<HttpResponseMessage>(q => !q.IsSuccessStatusCode)
              .RetryAsync(3);

            linearRetryPolicy = Policy.HandleResult<HttpResponseMessage>(q => !q.IsSuccessStatusCode)
              .WaitAndRetryAsync(3, retryattemp => TimeSpan.FromSeconds(4));

            exponentialRetryPolicy = Policy.HandleResult<HttpResponseMessage>(q => !q.IsSuccessStatusCode)
              .WaitAndRetryAsync(3, retryattemp => TimeSpan.FromSeconds(Math.Pow(2, retryattemp)));
        }
    }
}
