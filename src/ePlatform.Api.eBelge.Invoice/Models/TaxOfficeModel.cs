namespace ePlatform.Api.eBelge.Invoice.Models
{
    public class TaxOfficeModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public long CityId { get; set; }
        public string CityName { get; set; }
    }
}