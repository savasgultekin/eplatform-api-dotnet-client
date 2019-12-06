namespace ePlatform.Api.eBelge.Invoice.Models
{
    public class CreateInvoiceModel
    {
        public string InvoiceZip { get; set; }
        public int Status { get; set; }
        public string LocalReferenceId { get; set; }
        public string Prefix { get; set; }
        public bool UseManualInvoiceId { get; set; }
        public bool? CheckLocalReferenceId { get; set; }
        public string TargetAlias { get; set; }
        public string XsltCode { get; set; }

        public int AppType { get; set; }
        public EArsivInfoModel EArsivInfo { get; set; }
    }
}