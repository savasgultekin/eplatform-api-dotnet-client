

namespace ePlatform.Api.eBelge.Invoice.Models
{
    public class TaxExemptionReasonModel
    {
        public long Id { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public int RelatedType { get; set; }
        public bool IsEnabled { get; set; }
    }
}
