using Flurl.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePlatform.Api.Core.Http
{
    public static class FlurlClientExtensions
    {
        public static T AcceptJsonHeader<T>(this T clientOrRequest) where T : IHttpSettingsContainer
        {
            return clientOrRequest.WithHeader("Accept", "application/json");
        }

        public async static Task<T> GetJsonWithDefaultAsync<T>(this IFlurlRequest request, System.Net.HttpStatusCode httpStatusCode)
        {
            try
            {
                return await request.GetJsonAsync<T>();

            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == httpStatusCode)
                {
                    return default;
                }
                throw;
            }
        }

        public static IFlurlClient SetDefaultSettings(this IFlurlClient flurlClient)
        {
            return flurlClient
                .AcceptJsonHeader()
                .HandleHttpStatusAsync();
        }

        public static IFlurlClient HandleHttpStatusAsync(this IFlurlClient flurlClient)
        {
            return flurlClient.Configure(config =>
            {
                config.OnErrorAsync = async httpCall =>
                {
                    await Handle422Async(httpCall);
                    await Handle404Async(httpCall);
                    await Handle401Async(httpCall);
                    await Handle403Async(httpCall);
                };
            });
        }

        private static async Task Handle422Async(HttpCall call)
        {
            if ((int)call.HttpStatus == 422)
            {
                call.ExceptionHandled = true;
                var result = JsonConvert.DeserializeObject<Dictionary<string, IEnumerable<string>>>(await call.Response.Content.ReadAsStringAsync());
                if (result.Any())
                {
                    throw new EntityValidationException(result, result.FirstOrDefault().Value.FirstOrDefault(), call.Exception);
                }
            }
        }

        private static async Task Handle404Async(HttpCall call)
        {
            if (call.HttpStatus == System.Net.HttpStatusCode.NotFound)
            {
                call.ExceptionHandled = true;
                throw new EntityNotFoundException(await call.Response.Content.ReadAsStringAsync(), call.Exception);
            }
        }

        private static async Task Handle403Async(HttpCall call)
        {
            if (call.HttpStatus == System.Net.HttpStatusCode.Forbidden)
            {
                call.ExceptionHandled = true;
                throw new ForbiddenExcepitons(await call.Response.Content.ReadAsStringAsync(), call.Exception);
            }
        }

        private static async Task Handle401Async(HttpCall call)
        {
            if (call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
            {
                call.ExceptionHandled = true;
                throw new UnauthorizedExcepiton(await call.Response.Content.ReadAsStringAsync(), call.Exception);
            }
        }
    }
}
