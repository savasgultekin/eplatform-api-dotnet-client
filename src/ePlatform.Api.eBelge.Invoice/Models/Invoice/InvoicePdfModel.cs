using System;

namespace ePlatform.Api.eBelge.Invoice.Models
{
    public class InvoicePdfModel
    {
        public Guid[] Ids { get; set; }
        public bool IsStandartXslt { get; set; }
    }
}