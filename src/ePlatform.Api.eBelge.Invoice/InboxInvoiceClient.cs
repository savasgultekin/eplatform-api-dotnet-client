using ePlatform.Api.Core.Http;
using ePlatform.Api.Core;
using Flurl.Http;
using Flurl.Http.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ePlatform.Api.eBelge.Invoice.Models;

namespace ePlatform.Api.eBelge.Invoice
{
    public class InboxInvoiceClient
    {
        private readonly ClientOptions clientOptions;
        private readonly IFlurlClient flurlClient;

        public InboxInvoiceClient(ClientOptions clientOptions, IFlurlClientFactory flurlClientFac)
        {
            this.clientOptions = clientOptions;
            flurlClient = flurlClientFac.Get(this.clientOptions.InvoiceServiceUrl).SetDefaultSettings();
        }

        public async Task<InboxInvoiceGetModel> Get(Guid id)
        {
            return await flurlClient.Request($"/v1/inboxinvoice/{id}")
                .GetJsonAsync<InboxInvoiceGetModel>();
        }

        public async Task<UblBuilderModel> GetInvoice(Guid id)
        {
            return await flurlClient.Request($"/v1/inboxinvoice/getinvoice")
                .SetQueryParam("guid", id)
                .GetJsonAsync<UblBuilderModel>();
        }

        public async Task<PagedList<InboxInvoiceGetModel>> Get(PagingModel model)
        {
            return await flurlClient.Request($"/v1/inboxinvoice/list")
                .SetQueryParams(model)
                .GetJsonAsync<PagedList<InboxInvoiceGetModel>>();
        }

        public async Task<InboxInvoiceModel> GetWithEnvelopes(Guid id)
        {
            return await flurlClient.Request($"/v1/inboxinvoice/getwithenvelopes/{id}")
                .GetJsonAsync<InboxInvoiceModel>();
        }

        public async Task<List<InboxInvoiceModel>> GetInboxInvoicesByEnvelopeId(Guid envelopId)
        {
            return await flurlClient.Request($"/v1/inboxinvoice/getinvoicesbyenvelopeid/{envelopId}")
                .GetJsonAsync<List<InboxInvoiceModel>>();
        }

        public async Task<bool> DeleteInboxInvoiceWithTaxes(Guid id)
        {
            var response = await flurlClient.Request($"/v1/inboxinvoice/deletewithtaxes/{id}")
                .DeleteAsync();
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> SendOrRemoveArchive(UpdateInvoiceModel model)
        {
            var response = await flurlClient.Request($"/v1/inboxinvoice/sendorremovearchivelist")
                .PutJsonAsync(model);
            return response.IsSuccessStatusCode;
        }

        public async Task<Stream> GetHtml(Guid id, bool useStandartXslt = false)
        {
            return await flurlClient.Request($"/v2/inboxinvoice/{id}/html/{useStandartXslt}")
                .GetStreamAsync();
        }

        public async Task<Stream> GetPdf(Guid id, bool useStandartXslt)
        {
            return await flurlClient.Request($"/v2/inboxinvoice/{id}/pdf/{useStandartXslt}")
                .GetStreamAsync();
        }

        public async Task<byte[]> GetPdfList(InvoicePdfModel model)
        {
            var reponse = await flurlClient.Request($"/v1/inboxinvoice/pdflist")
            .PostJsonAsync(model);
            return await reponse.Content.ReadAsByteArrayAsync();
        }

        public async Task<Stream> GetUbl(Guid id)
        {
            return await flurlClient.Request($"/v2/inboxinvoice/{id}/ubl")
                .GetStreamAsync();
        }

        public async Task<Stream> GetUbl(Guid[] ids)
        {
            return await flurlClient.Request($"/v2/inboxinvoice/ubl")
                .PostJsonAsync(new { Selected = ids })
                .ReceiveStream();
        }

        public async Task<byte[]> GetUblList(Guid[] ids)
        {
            var reponse = await flurlClient.Request($"/v1/inboxinvoice/ubllist")
            .PostJsonAsync(ids);
            return await reponse.Content.ReadAsByteArrayAsync();
        }

        public async Task<ApproveRejectInvoiceModel> GetInvoiceResponse(Guid id)
        {
            return await flurlClient.Request($"/v1/invoiceresponse/getbyinvoiceid/{id}")
                .GetJsonAsync<ApproveRejectInvoiceModel>();
        }

        public async Task<DocumentResponseModel> ApproveReject(ApproveRejectInvoiceModel model)
        {
            var reponseModel = await flurlClient.Request($"/v1/invoiceresponse")
                .PostJsonAsync(model)
                .ReceiveJson<DocumentResponseModel>();
            return reponseModel;
        }
    }
}
