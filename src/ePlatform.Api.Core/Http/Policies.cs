using ePlatform.Api.Core.Auth;
using Polly;
using Polly.Retry;
using Polly.Wrap;
using System;
using System.Net.Http;

namespace ePlatform.Api.Core.Http
{
    internal static class Policies
    {
        public static AsyncRetryPolicy<HttpResponseMessage> TokenRefreshPolicy
        {
            get
            {
                return Policy
                    .HandleResult<HttpResponseMessage>(r => r.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    .WaitAndRetryAsync(
                        retryCount: 2,
                        sleepDurationProvider: retryAttempt => TimeSpan.FromMilliseconds(100 * Math.Pow(2, retryAttempt)),
                        onRetryAsync: async (exception, timeSpan, currentRetry, context) =>
                        {
                            if (context.TryGetValue("authClient", out var client) && client is AuthClient authClient)
                            {
                                await authClient.RefreshToken();
                            }

                            var a = exception;
                        });
            }
        }
    }
}
