using ePlatform.Api.Core;
using ePlatform.Api.Core.Http;
using ePlatform.Api.eBelge.Invoice.Models;
using Flurl.Http;
using Flurl.Http.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ePlatform.Api.eBelge.Invoice
{
    public class EArchiveInvoiceClient
    {
        private readonly ClientOptions clientOptions;
        private readonly IFlurlClient flurlClient;
        public UblBuilderModel NewOutboxInvoceModel()
        {
            return new UblBuilderModel() { RecordType = (int)RecordType.Invoice, };
        }
        public InvoiceLineBaseModel<InvoiceLineTaxBaseModel> NewInvoceLineModel()
        {
            return new InvoiceLineBaseModel<InvoiceLineTaxBaseModel>();
        }
        public EArchiveInvoiceClient(ClientOptions clientOptions, IFlurlClientFactory flurlClientFac)
        {
            this.clientOptions = clientOptions;
            flurlClient = flurlClientFac.Get(this.clientOptions.InvoiceServiceUrl).SetDefaultSettings();
        }

        /// <summary>
        /// Get One Outbox Invoice with Guid Id
        /// </summary>
        public async Task<OutboxInvoiceGetModel> Get(Guid id)
        {
            return await flurlClient.Request($"/v1/earchive/{id}")
                .GetJsonAsync<OutboxInvoiceGetModel>();
        }

        /// <summary>
        /// Get Filtered Outbox Invoice
        /// </summary>
        public async Task<PagedList<OutboxInvoiceGetModel>> Get(PagingModel model)
        {
            var list = await flurlClient.Request($"/v1/earchive/list")
                .SetQueryParams(model)
                .GetJsonAsync<PagedList<OutboxInvoiceGetModel>>();
            return list;
        }

        /// <summary>
        /// Email Status:
        /// Created=0,Queued=10,Send=20,Failed=30,SendStopped=40
        /// </summary>
        public async Task<List<EarsivInvoiceMailModel>> GetMailDetail(string id)
        {
            return await flurlClient.Request($"/v1/earchive/getmaildetail")
                .SetQueryParam("id", id.ToString())
                .GetJsonAsync<List<EarsivInvoiceMailModel>>();
        }

        public async Task<bool> Cancel(Guid[] ids)
        {
            var response = await flurlClient.Request($"/v1/earchive/cancelinvoice")
                .PutJsonAsync(ids);
            return response.IsSuccessStatusCode;
        }

        public async Task RetryInvoiceMail(Guid id)
        {
            await flurlClient.Request($"/v1/earchive/retryinvoicemail/{id}")
                .GetAsync();
        }

        public async Task RetryInvoiceWithDifferentMail(Guid id, string mail)
        {
            await flurlClient.Request($"/v1/earchive/retryinvoicemail/{id}/{mail}")
               .GetAsync();
        }
    }
}
