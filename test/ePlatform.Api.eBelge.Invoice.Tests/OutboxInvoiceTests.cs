using ePlatform.Api.Core;
using ePlatform.Api.eBelge.Invoice.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ePlatform.Api.eBelge.Invoice.Tests
{
    [Collection("eBelge")]
    public class OutboxInvoiceTests
    {
        private readonly OutboxInvoiceClient outboxInvoiceClient;
        public OutboxInvoiceTests(StartupFixture fixture)
        {
            outboxInvoiceClient = fixture.ServiceProvider.GetRequiredService<OutboxInvoiceClient>();
        }

        [Fact]
        public async Task Http_404_shold_throw_EntityNotFoundException()
        {
            var notExistingInvoiceId = Guid.Parse("85733EDC-958B-4C80-9E49-8942B85D0156");
            await Assert.ThrowsAsync<EntityNotFoundException>(async () =>
            {
                await outboxInvoiceClient.Get(notExistingInvoiceId);
            });
        }

        [Fact]
        public async Task Http_422_shold_throw_EntityValidationException()
        {
            var ublModel = new UblBuilderModel
            {
                GeneralInfoModel = new GeneralInfoBaseModel()
                {
                    Ettn = Guid.NewGuid(),
                    Prefix = null,
                    InvoiceNumber = null,
                    InvoiceProfileType = InvoiceProfileType.TEMELFATURA,
                    IssueDate = DateTime.Now,
                    Type = InvoiceType.SATIS,
                    CurrencyCode = "TRY"
                },
                AddressBook = new AddressBookModel()
                {
                    Alias = "urn:mail:defaulttest11pk@medyasoft.com.tr",
                    IdentificationNumber = "1234567801111111111", //invalid vkn
                }
            };
            await Assert.ThrowsAsync<EntityValidationException>(async () =>
            {
                await outboxInvoiceClient.Post(ublModel);
            });
        }

        [Fact]
        public async Task page_size_shold_return_number_of_page_size_item()
        {
            var notExistingInvoiceId = Guid.Parse("85733EDC-958B-4C80-9E49-8942B85D0156");
            var query = new QueryFilterBuilder<OutboxInvoiceGetModel>()
                .PageIndex(1)
                .PageSize(3)
                .QueryFor(q => q.Currency, Operator.Equal, "TRY")
                .Build();

            var result = await outboxInvoiceClient.Get(query);
            Assert.Equal(3, result.PageSize);
            Assert.Equal(3, result.Items.Count());
        }
        [Fact]
        public async Task Post_method_should_return_response_model()
        {
            var filledModel = FillUblModel.fillUblModel();
            var response = await outboxInvoiceClient.Post(filledModel);

            Assert.True(response.InvoiceNumber.Trim().Length > 0);
            Assert.True(response.Id.Trim().Length > 0);
        }
    }
}
