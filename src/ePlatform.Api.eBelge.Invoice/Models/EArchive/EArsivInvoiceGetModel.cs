namespace ePlatform.Api.eBelge.Invoice.Models
{
    public class EArsivInvoiceGetModel
    {
        public bool IsInternetSale { get; set; }
        public int EMailStatus { get; set; }
        public bool SendEmail { get; set; }
        public int SendType { get; set; }
    }
}