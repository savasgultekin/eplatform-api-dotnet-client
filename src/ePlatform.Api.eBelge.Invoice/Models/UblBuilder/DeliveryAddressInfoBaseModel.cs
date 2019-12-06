namespace ePlatform.Api.eBelge.Invoice.Models
{
    public class DeliveryAddressInfoBaseModel
    {
        public string Street { get; set; }
        public string DoorNumber { get; set; }
        public string City { get; set; }
        public string BuildingName { get; set; }
        public string SmallTown { get; set; }
        public string ZipCode { get; set; }
        public string BuildingNo { get; set; }
        public string District { get; set; }
        public string CountryName { get; set; }
        public int CountryId { get; set; }
    }
}