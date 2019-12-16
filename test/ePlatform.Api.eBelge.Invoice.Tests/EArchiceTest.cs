using ePlatform.Api.Core;
using ePlatform.Api.eBelge.Invoice.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ePlatform.Api.eBelge.Invoice.Tests
{
    [Collection("eBelge")]
    public class EArchiceTest
    {
        private readonly EArchiveInvoiceClient earchiceInvoiceClient;
        InboxInvoiceGetModel invoiceId = new InboxInvoiceGetModel();

        public EArchiceTest(StartupFixture fixture)
        {
            earchiceInvoiceClient = fixture.ServiceProvider.GetRequiredService<EArchiveInvoiceClient>();
        }

        [Fact]
        public async Task Http_404_shold_throw_EntityNotFoundException()
        {
            var notExistingInvoiceId = Guid.Parse("85733EDC-958B-4C80-9E49-8942B85D0156");
            await Assert.ThrowsAsync<EntityNotFoundException>(async () =>
            {
                await earchiceInvoiceClient.Get(notExistingInvoiceId);
            });
        }

        [Fact]
        public async Task page_size_shold_return_number_of_page_size_item()
        {
            var query = new QueryFilterBuilder<OutboxInvoiceGetModel>()
                .PageIndex(1)
                .PageSize(3)
                .QueryFor(q => q.Currency, Operator.Equal, "TRY")
                .Build();

            var result = await earchiceInvoiceClient.Get(query);
            Assert.True(result.Items.All(q => q.Currency == "TRY"));
            Assert.Equal(3, result.Items.Count());
        }

        [Fact]
        public async Task Get_should_return_earchive_Detail()
        {
            var query = new QueryFilterBuilder<OutboxInvoiceGetModel>()
                .PageIndex(1)
                .PageSize(3)
                .QueryFor(q => q.Currency, Operator.Equal, "TRY")
                .Build();
            var pageList = await earchiceInvoiceClient.Get(query);
            var model = pageList.Items.ToList();
            for (int i = 0; i < model.Count(); i++)
            {
                var response = await earchiceInvoiceClient.Get(model[i].Id);
                Assert.Equal(response.Id, model[i].Id);
                Assert.Equal(response.InvoiceNumber, model[i].InvoiceNumber);
                Assert.NotNull(response.TargetVknTckn);
            }
        }
        [Fact]
        public async Task GetPdfGetMailDetail_response_should_have_email_adress()
        {
            var query = new QueryFilterBuilder<OutboxInvoiceGetModel>()
                 .PageIndex(1)
                 .PageSize(100)
                 .QueryFor(q => q.Currency, Operator.Equal, "TRY")
                 .Build();
            var pageList = await earchiceInvoiceClient.Get(query);

            var model = pageList.Items.ToList();
            foreach (var item in model)
            {
                var response = await earchiceInvoiceClient.GetMailDetail(item.Id.ToString());
                foreach (var mailDetail in response)
                {
                    Assert.NotEmpty(mailDetail.EmailAddress);
                }
            }
        }

        [Fact]
        public async Task Http_404_shold_throw_EntityNotFoundException_Cancel_Metot()
        {
            var notExistingInvoiceId = Guid.Parse("85733EDC-958B-4C80-9E49-8942B85D0156");
            await Assert.ThrowsAsync<EntityNotFoundException>(async () =>
            {
                await earchiceInvoiceClient.Cancel(new Guid[] { notExistingInvoiceId });
            });
        }
        [Fact]
        public async Task Cancel_Metot_shoul_return_bool()
        {
            var query = new QueryFilterBuilder<OutboxInvoiceGetModel>()
                 .PageIndex(1)
                 .PageSize(2)
                 .QueryFor(q => q.Status, Operator.Equal, 60)
                 .Build();
            var pageList = await earchiceInvoiceClient.Get(query);

            var model = pageList.Items?.ToList();
            var guidArray = model?.Select(q => q.Id).ToArray();
            if (guidArray != null)
                Assert.True(await earchiceInvoiceClient.Cancel(guidArray));
        }
    }
}
