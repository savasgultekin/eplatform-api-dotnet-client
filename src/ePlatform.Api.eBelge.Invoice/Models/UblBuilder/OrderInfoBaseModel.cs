using System;

namespace ePlatform.Api.eBelge.Invoice.Models
{
    public class OrderInfoBaseModel
    {
        public string OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public InvoiceDocumentModel InvoiceDocumentModel { get; set; }

        // irsaliye
        public string DispatcherNameSurname { get; set; }
        public DateTime? ShipmentDate { get; set; }

        public OrderInfoBaseModel()
        {
            this.InvoiceDocumentModel = new InvoiceDocumentModel();
        }
    }
}