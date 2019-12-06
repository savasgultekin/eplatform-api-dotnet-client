using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace ePlatform.Api.eBelge.Invoice.Tests
{
    public class StartupFixture
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public StartupFixture()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var services = new ServiceCollection();

            services.AddDistributedMemoryCache().AddePlatformClients(configuration);


            ServiceProvider = services.BuildServiceProvider();
        }
    }

    [CollectionDefinition("eBelge")]
    public class StartupCollection : ICollectionFixture<StartupFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
