namespace ePlatform.Api.eBelge.Invoice.Models
{
    /// <summary>
    /// 
    /// </summary>
    public enum InvoiceTypes
    {
        /// <summary>
        ///Temel
        /// </summary>
        BaseInvoice = 0,
        /// <summary>
        ///Ticari
        /// </summary>
        CommercialInvoice = 1,
        /// <summary>
        ///İhracat
        /// </summary>
        ExportInvoice = 2,
        /// <summary>
        ///Yolcu Beraberinde
        /// </summary>
        PassengerInvoice = 3,
        /// <summary>
        ///e-Arşiv
        /// </summary>
        EArchiveInvoice = 4
    }
}
