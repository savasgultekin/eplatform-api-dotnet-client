using ePlatform.Api.Core.Http;
using Flurl.Http;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ePlatform.Api.Core.Auth
{
    public class AuthClient
    {
        private readonly ClientOptions clientOptions;
        private readonly HttpClient client;
        private readonly IDistributedCache distributedCache;

        private static readonly string AccessTokenCacheKey = "ePlatformAccessToken";
        public AuthClient(ClientOptions clientOptions, HttpClient client, IDistributedCache distributedCache)
        {
            this.clientOptions = clientOptions;
            this.client = client;
            client.BaseAddress = new Uri(this.clientOptions.AuthServiceUrl);
            this.distributedCache = distributedCache;
        }

        public async ValueTask<string> GetToken()
        {

            var token = await distributedCache.GetStringAsync(AccessTokenCacheKey);
            if (token == null)
            {
                var encodedContent = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>{
                new KeyValuePair<string, string>("username", clientOptions.Auth.Username),
                new KeyValuePair<string, string>("password", clientOptions.Auth.Password),
                new KeyValuePair<string, string>("client_id", clientOptions.Auth.ClientId)
                });

                using (var request = new HttpRequestMessage(HttpMethod.Post, "v1/token"))
                {
                    request.Content = encodedContent;
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

                    using (var response = await client.SendAsync(request))
                    {
                        if (response.StatusCode != HttpStatusCode.OK)
                            throw new Exception($"Token REquest Error: {await response.Content.ReadAsStringAsync()}");

                        var tokenResponse = JsonConvert.DeserializeObject<TokenResponseModel>(await response.Content.ReadAsStringAsync());

                        token = tokenResponse.AccessToken;
                        await distributedCache.SetStringAsync(AccessTokenCacheKey, token, new DistributedCacheEntryOptions
                        {
                            AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(12)
                        });
                    }
                }
            }

            return token;
        }
        public async ValueTask<string> RefreshToken()
        {
            await distributedCache.RemoveAsync(AccessTokenCacheKey);
            return await GetToken();
        }
    }
}
