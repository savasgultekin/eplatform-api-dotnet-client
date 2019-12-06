using ePlatform.Api.Core.Auth;
using ePlatform.Api.Core.Http;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ePlatform.Api.eBelge.Invoice.Sample.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var clientOpitons = new ClientOptions
            {
                AuthServiceUrl = "https://coretest.isim360.com",
                InvoiceServiceUrl = "https://efaturaservicetest.isim360.com",
                Auth = new ClientOptions.AuthOption
                {
                    ClientId = "serviceApi",
                    Username = "serviceuser01@isim360.com",
                    Password = "ePlatform123+"
                }
            };
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // tek servis ise memory kullanılabilir, aksi halde redis vb kullanılmalı
            var distributedCacheProvider = new MemoryDistributedCache(
                new OptionsWrapper<MemoryDistributedCacheOptions>(new MemoryDistributedCacheOptions()));
            var authClient = new AuthClient(clientOpitons, client, distributedCacheProvider);

            FlurlHttp.Configure(settings => settings.HttpClientFactory = new PollyHttpClientFactory(authClient));
            var clientFactory = new PerBaseUrlFlurlClientFactory();
            var outboxInvoiceClient = new OutboxInvoiceClient(clientOpitons, clientFactory);
            var inboxInvoiceClient = new InboxInvoiceClient(clientOpitons, clientFactory);
            var commonClient = new CommonClient(clientOpitons, clientFactory);
            var earchiveClient = new EArchiveInvoiceClient(clientOpitons, clientFactory);

            var currencies = await commonClient.CurrencyCodeList();
            currencies.ForEach(c => System.Console.WriteLine($"{c.Code} {c.Name}"));


            System.Console.ReadLine();
        }
    }
}
