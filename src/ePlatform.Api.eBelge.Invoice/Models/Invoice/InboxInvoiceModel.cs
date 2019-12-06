using System;
using System.Collections.Generic;

namespace ePlatform.Api.eBelge.Invoice.Models
{
    public class InboxInvoiceModel : BaseInvoiceModel
    {
        public string IdString { get; set; }
        public bool IsNew { get; set; }
        public bool IsRead { get; set; }
        public bool IsVerified { get; set; }
        public DateTime? SigningDate { get; set; }
        public string VerificationResult { get; set; }
        public List<InvoiceTaxModel> EfaturaInboxInvoiceTax { get; set; }
    }
}
