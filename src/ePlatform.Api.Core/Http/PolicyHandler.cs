using ePlatform.Api.Core.Auth;
using Polly;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ePlatform.Api.Core.Http
{
    public class PolicyHandler : DelegatingHandler
    {
        private readonly AuthClient authClient;
        public PolicyHandler(AuthClient authClient)
        {
            this.authClient = authClient;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var context = new Context($"Cache-{Guid.NewGuid()}", new Dictionary<string, object>
            {
                { "authClient", authClient }
            });


            return await Policies.TokenRefreshPolicy.ExecuteAsync(async (ctx, ct) =>
            {
                if (request.Headers.Contains("Authorization"))
                {
                    request.Headers.Remove("Authorization");
                }

                var token = await authClient.GetToken();
                request.Headers.Add("Authorization", $"Bearer {token}");

                return await base.SendAsync(request, ct);
            }, context, cancellationToken);
        }
    }
}
