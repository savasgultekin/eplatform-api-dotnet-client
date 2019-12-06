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
    public class CommonTests
    {
        private readonly CommonClient commonClient;
        public CommonTests(StartupFixture fixture)
        {
            commonClient = fixture.ServiceProvider.GetRequiredService<CommonClient>();
        }

        [Fact]
        public async Task GetUserAliasList_should_return_gib_user()
        {
            var query = new QueryFilterBuilder<OutboxInvoiceGetModel>()
                .PageIndex(1)
                .PageSize(3)
                .Build();

            var result = await commonClient.GetUserAliasList(query);
            Assert.Equal(3, result.PageSize);
            Assert.Equal(3, result.Items.Count());
        }

        [Fact]
        public async Task GetUserAliasList_return_user_info()
        {
            var query = new QueryFilterBuilder<OutboxInvoiceGetModel>()
                  .PageIndex(1)
                  .PageSize(3)
                  .Build();

            var result = await commonClient.GetUserAliasList(query);
            var userList = result.Items.ToList();

            foreach (var item in userList)
            {
                Assert.NotEmpty(item.Identifier);
                Assert.Contains(":", item.Alias);
                Assert.True(item.AppType == 1 || item.AppType == 3);
            }
        }

        [Fact]
        public async Task GetUser_return_user_deatils()
        {
            var query = new QueryFilterBuilder<OutboxInvoiceGetModel>()
                  .PageIndex(1)
                  .PageSize(3)
                  .Build();

            var result = await commonClient.GetUserAliasList(query);
            var userList = result.Items.ToList();


            foreach (var item in userList)
            {
                var userDetail = await commonClient.GetUser(item.Identifier);

                if (userDetail.ReceiverboxAliases.Count() > 0)
                {
                    foreach (var recaiver in userDetail.ReceiverboxAliases)
                    {
                        Assert.Contains(":", recaiver.Alias);
                        Assert.True(recaiver.AppType == 1 || recaiver.AppType == 3);
                    }
                }
                if (userDetail.SenderboxAliases.Count() > 0)
                {
                    foreach (var sender in userDetail.SenderboxAliases)
                    {
                        Assert.Contains(":", sender.Alias);
                        Assert.True(sender.AppType == 1 || sender.AppType == 3);
                    }
                }
            }
        }
        [Fact]
        public async Task CurrencyCodeList_should_return_currency_codes()
        {
            var result = await commonClient.CurrencyCodeList();
            List<string> containCurrency = new List<string> { "CHF", "TRY", "EUR" };
            Assert.NotNull(result);
            Assert.True(result.Where(q => containCurrency.Contains(q.Code)).ToList().Count() == containCurrency.Count());
        }
        [Fact]
        public async Task UnitCodeList_should_return_unitcode_codes()
        {
            var result = await commonClient.UnitCodeList();
            List<string> containUnitcode = new List<string> { "C62", "WEE", "CMT" };
            Assert.NotNull(result);
            Assert.True(result.Where(q => containUnitcode.Contains(q.Code)).ToList().Count() == containUnitcode.Count());
        }
        [Fact]
        public async Task TaxExemptionReasonList_should_return_Reason_values()
        {
            var result = await commonClient.TaxExemptionReasonList();
            List<string> containReasonCode = new List<string> { "201", "227", "803" };
            Assert.NotNull(result);
            Assert.True(result.Where(q => containReasonCode.Contains(q.Value)).ToList().Count() == containReasonCode.Count());
        }
        [Fact]
        public async Task TaxTypeCodeList_should_return_TaxType_values()
        {
            var result = await commonClient.TaxTypeCodeList();
            List<string> containReasonCode = new List<string> { "0003", "0015", "8002" };
            Assert.NotNull(result);
            Assert.True(result.Where(q => containReasonCode.Contains(q.Code)).ToList().Count() == containReasonCode.Count());
        }
        [Fact]
        public async Task TaxOfficeList_should_return_TaxOffice_values()
        {
            var result = await commonClient.TaxOfficeList();
            List<string> containTaxOfficeCode = new List<string> { "01205", "34203", "34263" };
            Assert.NotNull(result);
            Assert.True(result.Where(q => containTaxOfficeCode.Contains(q.Code)).ToList().Count() == containTaxOfficeCode.Count());
        }
        [Fact]
        public async Task CountrList_should_return_Country_values()
        {
            var result = await commonClient.CountrList();
            List<string> containCountryName = new List<string> { "Türkiye", "Brezilya", "Bulgaristan" };
            Assert.NotNull(result);
            Assert.True(result.Where(q => containCountryName.Contains(q.Name)).ToList().Count() == containCountryName.Count());
        }

    }
}
