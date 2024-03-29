﻿
namespace ePlatform.Api.eBelge.Invoice.Models
{
    public enum InvoiceTipType
    {
        /// <summary>
        /// Satış
        /// </summary>
        Sale = 1,
        /// <summary>
        /// İade
        /// </summary>
        Return = 2,
        /// <summary>
        /// İstisna
        /// </summary>
        Istisna = 3,
        /// <summary>
        /// Özel Matrah
        /// </summary>
        OzelMatrah = 4,
        /// <summary>
        /// Tevkifat
        /// </summary>
        Tevkifat = 5,
        /// <summary>
        /// Araç Tescil
        /// </summary>
        AracTescil = 6,
        /// <summary>
        /// İhraç Kayıtlı
        /// </summary>
        IhracKayitli = 7,
        /// <summary>
        /// SGK
        /// </summary>
        SGK = 8
    }
}