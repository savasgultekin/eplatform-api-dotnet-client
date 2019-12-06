namespace ePlatform.Api.eBelge.Invoice.Models
{
    public class EArsivInfoModel
    {
        public bool SendEMail { get; set; }
        public string EMailAddress { get; set; }
        public bool? AllowOldEArsivCustomer { get; set; }
    }
}