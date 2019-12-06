using System;
using System.Collections.Generic;

namespace ePlatform.Api.eBelge.Invoice.Models
{
    public class BaseInvoiceModel
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid? EnvelopeId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime? ExecutionDate { get; set; }
        public InvoiceStatus Status { get; set; }
        public InvoiceTypes Type { get; set; }
        public InvoiceTipType TipType { get; set; }
        public int LineNumber { get; set; }
        public string TargetTitle { get; set; }
        public string TargetVknTckn { get; set; }
        public string TargetAlias { get; set; }
        public bool IsArchived { get; set; }
        public bool IsAgentNew { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PayableAmount { get; set; }
        public string Currency { get; set; }
        public decimal? TaxTotal { get; set; }
        public string TableOperations { get; set; }
        public DateTime? SentDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public InboxEnvelopeModel Envelope { get; set; }
        public List<BaseEnvelopeModel> Envelopes { get; set; } 
    }
}
