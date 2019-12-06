using System;

namespace ePlatform.Api.eBelge.Invoice.Models
{
    public class UpdateInvoiceModel
    {
        public Guid[] Ids { get; set; }
        public bool IsArchived { get; set; }
        public InvoiceStatus Status { get; set; }
    }
}