using ePlatform.Api.Core;
using ePlatform.Api.Core.Http;
using ePlatform.Api.eBelge.Invoice.Models;
using Flurl.Http;
using Flurl.Http.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ePlatform.Api.eBelge.Invoice
{
    public class OutboxInvoiceClient
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

        public OutboxInvoiceClient(ClientOptions clientOptions, IFlurlClientFactory flurlClientFac)
        {
            this.clientOptions = clientOptions;
            flurlClient = flurlClientFac.Get(this.clientOptions.InvoiceServiceUrl).SetDefaultSettings();
        }

        /// <summary>
        /// Faturanın özet bilgilerini çeker
        /// </summary>

        public async Task<OutboxInvoiceGetModel> Get(Guid id)
        {
            return await flurlClient.Request($"/v1/outboxinvoice/{id}")
                .GetJsonAsync<OutboxInvoiceGetModel>();
        }

        /// <summary>
        /// Faturanın UBLModel halini çeker.
        /// </summary>
        public async Task<UblBuilderModel> GetInvoice(Guid id)
        {
            return await flurlClient.Request($"/v1/outboxinvoice/getinvoice")
                .SetQueryParam("guid", id)
                .GetJsonAsync<UblBuilderModel>();
        }

        /// <summary>
        /// Get Filtered Outbox Invoice
        /// </summary>
        public async Task<PagedList<OutboxInvoiceGetModel>> GetList(PagingModel model)
        {
            return await flurlClient.Request($"/v1/outboxinvoice/list")
                .SetQueryParams(model)
                .GetJsonAsync<PagedList<OutboxInvoiceGetModel>>();
        }

        public async Task<CreateInvoiceResponseModel> Post(UblBuilderModel model)
        {
            return await flurlClient.Request($"/v1/outboxinvoice/create")
                .PostJsonAsync(model)
                .ReceiveJson<CreateInvoiceResponseModel>();
        }

        public async Task<CreateInvoiceResponseModel> Update(Guid id, UblBuilderModel model)
        {
            return await flurlClient.Request($"/v1/outboxinvoice/update/{id.ToString()}")
                .PutJsonAsync(model)
                .ReceiveJson<CreateInvoiceResponseModel>();
        }

        public async Task<CreateInvoiceResponseModel> PostUBL(CreateInvoiceModel model)
        {
            return await flurlClient.Request($"/v1/outboxinvoice")
                .PostJsonAsync(model)
                .ReceiveJson<CreateInvoiceResponseModel>();
        }

        public async Task<CreateInvoiceResponseModel> UpdateUBL(CreateInvoiceModel model)
        {
            return await flurlClient.Request($"/v1/outboxinvoice")
                .PutJsonAsync(model)
                .ReceiveJson<CreateInvoiceResponseModel>();
        }

        public async Task<bool> UpdateStatusList(UpdateInvoiceModel model)
        {
            var response = await flurlClient.Request($"/v1/outboxinvoice/updatestatuslist")
                .PutJsonAsync(model);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> SendorRemoveArchiveList(UpdateInvoiceModel model)
        {
            var response = await flurlClient.Request($"/v1/outboxinvoice/sendorremovearchivelist")
                .PutJsonAsync(model);
            return response.IsSuccessStatusCode;
        }

        public async Task<Stream> GetUbl(Guid id)
        {
            return await flurlClient.Request($"/v2/outboxinvoice/{id}/ubl")
                .GetStreamAsync();
        }

        public async Task<Stream> GetUbl(Guid[] ids)
        {
            return await flurlClient.Request($"/v2/outboxinvoice/ubl")
                .PostJsonAsync(new { Selected = ids })
                .ReceiveStream();
        }

        public async Task<byte[]> GetUblList(InvoiceXmlModel model)
        {
            var response = await flurlClient.Request($"/v1/outboxinvoice/ubllist")
                .PostJsonAsync(model)
                .ReceiveBytes();
            return response;
        }

        public async Task<Stream> GetPdf(Guid id, bool useStandartXslt = false)
        {
            return await flurlClient.Request($"/v2/outboxinvoice/{id}/pdf/{useStandartXslt}")
                 .GetStreamAsync();
        }

        public async Task<byte[]> GetPdfList(InvoicePdfModel model)
        {
            var response = await flurlClient.Request($"/v1/outboxinvoice/pdflist")
                .PostJsonAsync(model)
                .ReceiveBytes();
            return response;
        }

        public async Task<Stream> GetHtml(Guid id, bool useStandartXslt = false)
        {
            return await flurlClient.Request($"/v2/outboxinvoice/{id}/html/{useStandartXslt}")
                .GetStreamAsync();
        }

        public async Task<PagedList<AdditionalDocumentreferenceModel>> GetAdditionalDocumentList(Guid id, PagingModel model)
        {
            var response = await flurlClient.Request($"/v1/outboxinvoice/getadditionaldocumentlist/{id}")
                .SetQueryParams(model)
                .GetJsonAsync<PagedList<AdditionalDocumentreferenceModel>>();
            return response;
        }

        public async Task<byte[]> DownloadAdditionalDocument(Guid id, string xsltId)
        {
            var response = await flurlClient.Request($"/v1/outboxinvoice/downloadadditionaldocument/{id}")
                .SetQueryParam(xsltId)
                .GetBytesAsync();
            return response;
        }

        public async Task<bool> ResetInvoiceList(Guid[] ids)
        {
            var response = await flurlClient.Request($"/v1/outboxinvoice/resetinvoicelist")
                .SetQueryParams(ids)
                .GetAsync();
            return response.IsSuccessStatusCode;
        }

        public async Task<OutboxInvoiceModel> GetWithEnvelopes(Guid id)
        {
            return await flurlClient.Request($"/v1/outboxinvoice/getwithenvelopes/{id}")
                .GetJsonAsync<OutboxInvoiceModel>();
        }

        public async Task<ApproveRejectInvoiceModel> GetInvoiceResponse(Guid id)
        {
            return await flurlClient.Request($"/v1/invoiceresponse/getbyinvoiceid/{id}")
                .GetJsonAsync<ApproveRejectInvoiceModel>();
        }
    }
}
