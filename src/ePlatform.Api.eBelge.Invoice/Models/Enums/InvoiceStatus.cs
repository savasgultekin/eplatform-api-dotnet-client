
namespace ePlatform.Api.eBelge.Invoice.Models
{
    public enum InvoiceStatus
    {
        /// <summary>
        ///Hepsi
        /// </summary>
        All = 999,
        /// <summary>
        ///Taslak
        /// </summary>
        Draft = 0,
        /// <summary>
        ///Test
        /// </summary>
        Test = 5,
        /// <summary>
        ///İptal
        /// </summary>
        Canceled = 10,
        /// <summary>
        ///Kuyrukta
        /// </summary>
        Queued = 20,
        /// <summary>
        ///Gönderim Bekliyor
        /// </summary>
        Running = 30,
        /// <summary>
        ///Hata
        /// </summary>
        Error = 40,
        /// <summary>
        ///GIB'e İletildi
        /// </summary>
        SentToGib = 50,
        /// <summary>
        ///Onaylandı
        /// </summary>
        Approved = 60,
        /// <summary>
        ///Onaylanıyor
        /// </summary>
        WaitingApprove = 61,
        /// <summary>
        ///Onaylama Hatası
        /// </summary>
        FailedApprove = 62,
        /// <summary>
        ///Otomatik Onaylandı
        /// </summary>
        AutomaticApproved = 65,
        /// <summary>
        ///Onay Bekliyor
        /// </summary>
        WaitingForAprovement = 70,
        /// <summary>
        ///Reddedildi
        /// </summary>
        Declined = 80,
        /// <summary>
        ///Reddediliyor
        /// </summary>
        WaitingDecline = 81,
        /// <summary>
        ///Reddetme Hatası
        /// </summary>
        FailedDecline = 82,
        /// <summary>
        ///İade
        /// </summary>
        Return = 90,
        /// <summary>
        ///İade ediliyor
        /// </summary>
        WaitingReturn = 91,
        /// <summary>
        ///İade Hatası
        /// </summary>
        FailedReturn = 92,
        /// <summary>
        ///e-Arşiv İptal
        /// </summary>
        EArsivCanceled = 100
    }
}
