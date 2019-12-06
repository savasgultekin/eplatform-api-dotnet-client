namespace ePlatform.Api.eBelge.Invoice.Models
{
    public class AdditionalInvoiceTypeBaseModel
    {
        public string AccountingCostType { get; set; }
        public string TaxPayerCode { get; set; }
        public string TaxPayerName { get; set; }
        public string DocumentNumber { get; set; }
    }
}