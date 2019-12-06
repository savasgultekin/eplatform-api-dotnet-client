using System;

namespace ePlatform.Api.eBelge.Invoice.Models
{
    public class ArchiveInfoBaseModel
    {
        public bool IsInternetSale { get; set; }
        public string WebsiteUrl { get; set; }
        public string ShipmentSenderTcknVkn { get; set; }
        public string ShipmentSendType { get; set; }
        public string ShipmentSenderName { get; set; }
        public string ShipmentSenderSurname { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public bool HideDespatchMessage { get; set; }
        public string SubscriptionType { get; set; }
        public string SubscriptionTypeNumber { get; set; }
    }
}