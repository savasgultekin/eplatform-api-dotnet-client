using System;

namespace ePlatform.Api.eBelge.Invoice.Models
{
    public class DocumentResponseModel
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid InvoiceId { get; set; }
        public Guid? EnvelopeId { get; set; }
        public int Status { get; set; }
        public int ResponseStatus { get; set; }
        public string Reason { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}