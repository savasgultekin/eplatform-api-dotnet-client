using System;

namespace ePlatform.Api.eBelge.Invoice.Models
{
    public class InboxEnvelopeModel : BaseEnvelopeModel
    {
        public string IdString { get; set; }
        public DateTime? EnvelopeCreationDateAndTime { get; set; }

    }
}
