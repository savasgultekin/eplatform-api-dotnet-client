using ePlatform.Api.Core.Auth;
using Flurl.Http.Configuration;
using System.Net.Http;

namespace ePlatform.Api.Core.Http
{
    public class PollyHttpClientFactory : DefaultHttpClientFactory
    {
        private readonly AuthClient authClient;

        public PollyHttpClientFactory(AuthClient authClient)
        {
            this.authClient = authClient;
        }
        public override HttpMessageHandler CreateMessageHandler()
        {
            return new PolicyHandler(authClient)
            {
                InnerHandler = base.CreateMessageHandler()
            };
        }
    }
}
