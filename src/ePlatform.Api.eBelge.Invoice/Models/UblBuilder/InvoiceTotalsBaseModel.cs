namespace ePlatform.Api.eBelge.Invoice.Models
{
    public class InvoiceTotalsBaseModel
    {
        public string LineExtensionAmount { get; set; }

        public string TaxExclusiveAmount { get; set; }

        public string TaxInclusiveAmount { get; set; }

        public string AllowanceTotalAmount { get; set; }

        public string PayableAmount { get; set; }

        public string AmountInWords { get; set; }

        public InvoiceTotalsBaseModel()
        {
        }
    }
}
