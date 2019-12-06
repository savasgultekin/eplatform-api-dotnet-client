using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ePlatform.Api.eBelge.Invoice.Models
{
    public class BuyerCustomerInfoBaseModel
    {
        #region YolcuBeraberinde

        [DisplayName("Adı")]
        public string FirstName { get; set; }

        [DisplayName("Soyad")]
        public string FamilyName { get; set; }

        [DisplayName("Uyruk")]
        public string Nationality { get; set; }

        [DisplayName("Turist'in Ülkesi")]
        public string TouristCountry { get; set; }

        [DisplayName("Turist'in Şehri")]
        public string TouristCity { get; set; }

        [DisplayName("Turist'in İlçesi")]
        public string TouristDistrict { get; set; }

        [DisplayName("Finans Kurumu Adı")]
        public string FinancialInstitutionName { get; set; }

        [DisplayName("Pasaport Numarası")]
        public string PassportNumber { get; set; }

        [DisplayName("Hesap Numarası")]
        public string FinancialAccountId { get; set; }

        [DisplayName("Para Birimi")]
        public string CurrencyCode { get; set; }

        [DisplayName("Ödeme Notu")]
        public string PaymentNote { get; set; }

        [Display(Name = "İşlem Tarihi")]
        public DateTime IssueDate { get; set; }

        #endregion

        #region İhracat

        //[Required(ErrorMessage = "Malı alan kurumun ülkesindeki vergi numarası zorunludur.")]
        [DisplayName("Vergi Numarası")]
        public string CompanyId { get; set; }

        //[Required(ErrorMessage = "Malı alan kurumun ünvanı zorunludur.")]
        [DisplayName("Kurumun Resmi Ünvanı")]
        public string RegistrationName { get; set; }

        //[Required(ErrorMessage = "Lütfen ithalat yapan yabancı kurumun ünvanını giriniz.")]
        [DisplayName("Kurum Ünvanı")]
        public string PartyName { get; set; }

        [DisplayName("Cadde/Sokak")]
        public string BuyerStreet { get; set; }

        [DisplayName("Bina Adı")]
        public string BuyerBuildingName { get; set; }

        [DisplayName("Bina No")]
        public string BuyerBuildingNumber { get; set; }

        [DisplayName("Kapı No")]
        public string BuyerDoorNumber { get; set; }

        [DisplayName("Kasaba/Köy")]
        public string BuyerSmallTown { get; set; }

        [DisplayName("İlçe")]
        public string BuyerDistrict { get; set; }

        [DisplayName("Posta Kodu")]
        public string BuyerZipCode { get; set; }

        //[Required(ErrorMessage = "Lütfen şehir giriniz.")]
        [DisplayName("Şehir")]
        public string BuyerCity { get; set; }

        //[Required(ErrorMessage = "Lütfen ülke giriniz.")]
        [DisplayName("Ülke")]
        public string BuyerCountry { get; set; }

        [DisplayName("Tel")]
        public string BuyerPhoneNumber { get; set; }

        [DisplayName("Fax")]
        public string BuyerFaxNumber { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Geçersiz mail adresi.")]
        [DisplayName("E-posta")]
        public string BuyerEmail { get; set; }

        [DisplayName("Websitesi")]
        public string BuyerWebSite { get; set; }

        [Display(Name = "Vergi Dairesi")]
        public string BuyerTaxOffice { get; set; }

        #endregion
    }
}
