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
    public class InboxInvoiceTests
    {
        private readonly InboxInvoiceClient inboxInvoiceClient;
        InboxInvoiceGetModel invoiceId = new InboxInvoiceGetModel();

        public InboxInvoiceTests(StartupFixture fixture)
        {
            inboxInvoiceClient = fixture.ServiceProvider.GetRequiredService<InboxInvoiceClient>();
        }

        [Fact]
        public async Task Http_404_should_throw_EntityNotFoundException()
        {
            var notExistingInvoiceId = Guid.Parse("85733EDC-958B-4C80-9E49-8942B85D0156");
            await Assert.ThrowsAsync<EntityNotFoundException>(async () =>
            {
                await inboxInvoiceClient.Get(notExistingInvoiceId);
            });
        }

        [Fact]
        public async Task page_size_should_return_number_of_page_size_item()
        {
            var query = new QueryFilterBuilder<OutboxInvoiceGetModel>()
                .PageIndex(1)
                .PageSize(3)
                .QueryFor(q => q.Currency, Operator.Equal, "TRY")
                .Build();

            var result = await inboxInvoiceClient.Get(query);
            Assert.True(result.Items.All(q => q.Currency == "TRY"));
            Assert.Equal(3, result.Items.Count());
        }

        [Fact]
        public async Task GetOnvoice_should_return_Ubl_Model()
        {
            var query = new QueryFilterBuilder<OutboxInvoiceGetModel>()
                .PageIndex(1)
                .PageSize(3)
                .QueryFor(q => q.Currency, Operator.Equal, "TRY")
                .Build();
            var pageList = await inboxInvoiceClient.Get(query);
            var model = pageList.Items.FirstOrDefault();

            var response = await inboxInvoiceClient.GetInvoice(model.Id);

            Assert.Equal(response.InvoiceId, model.Id);
            Assert.NotNull(response.AddressBook);
            Assert.NotNull(response.GeneralInfoModel);
        }
        [Fact]
        public async Task GetPdf_response_have_value()
        {
            var query = new QueryFilterBuilder<OutboxInvoiceGetModel>()
                .PageIndex(1)
                .PageSize(3)
                .QueryFor(q => q.Currency, Operator.Equal, "TRY")
                .Build();
            var pageList = await inboxInvoiceClient.Get(query);
            var model = pageList.Items.FirstOrDefault();

            var streamData = await inboxInvoiceClient.GetPdf(model.Id, false);
            using (var reader = new StreamReader(streamData, Encoding.UTF8))
            {
                string value = reader.ReadToEnd();
                Assert.Contains("PDF", value);
            }

        }
        [Fact]
        public async Task GetHtml_response_have_html_tags()
        {
            var query = new QueryFilterBuilder<OutboxInvoiceGetModel>()
                .PageIndex(1)
                .PageSize(3)
                .QueryFor(q => q.Currency, Operator.Equal, "TRY")
                .Build();
            var pageList = await inboxInvoiceClient.Get(query);
            var model = pageList.Items.FirstOrDefault();

            var streamData = await inboxInvoiceClient.GetHtml(model.Id);
            using (var reader = new StreamReader(streamData, Encoding.UTF8))
            {
                string value = reader.ReadToEnd();
                Assert.Contains("<html>", value);
                Assert.Contains("</html>", value);
                Assert.Contains("<head>", value);
            }

        }
        [Fact]
        public async Task Http_404_should_throw_EntityNotFoundException_Get_Html()
        {
            var notExistingInvoiceId = Guid.Parse("85733EDC-958B-4C80-9E49-8942B85D0156");
            await Assert.ThrowsAsync<EntityNotFoundException>(async () =>
            {
                await inboxInvoiceClient.GetHtml(notExistingInvoiceId);
            });
        }
        [Fact]
        public async Task GetUbl_response_have_xml_tags()
        {
            var query = new QueryFilterBuilder<OutboxInvoiceGetModel>()
                .PageIndex(1)
                .PageSize(3)
                .QueryFor(q => q.Currency, Operator.Equal, "TRY")
                .Build();
            var pageList = await inboxInvoiceClient.Get(query);
            var model = pageList.Items.FirstOrDefault();

            var streamData = await inboxInvoiceClient.GetUbl(model.Id);
            using (var reader = new StreamReader(streamData, Encoding.UTF8))
            {
                string value = reader.ReadToEnd();
                Assert.NotEmpty(value);
                Assert.Contains("<Invoice", value);
                Assert.Contains("<cbc:ID schemeID=", value);
                Assert.Contains("<cac:PartyIdentification>", value);
                Assert.Contains("<cac:PartyIdentification>", value);
            }
        }
        [Fact]
        public async Task Http_404_should_throw_EntityNotFoundException_Get_Ubl()
        {
            var notExistingInvoiceId = Guid.Parse("85733EDC-958B-4C80-9E49-8942B85D0156");
            await Assert.ThrowsAsync<EntityNotFoundException>(async () =>
            {
                await inboxInvoiceClient.GetHtml(notExistingInvoiceId);
            });
        }

    }
}
