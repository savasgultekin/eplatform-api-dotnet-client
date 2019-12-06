namespace ePlatform.Api.eBelge.Invoice.Models
{
    public class TaxTypeCodeModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsProrata { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsCalculationBaseOnLineAmount { get; set; }
        public bool IsNegative { get; set; }
    }
}