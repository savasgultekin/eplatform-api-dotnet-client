namespace ePlatform.Api.eBelge.Invoice.Models
{
    public enum EnvelopeStatus
    {
        
        /// <summary>
        /// 
        /// </summary>
        a=0,
        /// <summary>
        ///Test
        /// </summary>
        Test = 1,
        /// <summary>
        ///Hazırlanıyor
        /// </summary>
        Preparing = 100,
        /// <summary>
        ///Kuyruğa Eklendi
        /// </summary>
        EnvelopIsQueued = 1000,
        /// <summary>
        ///İşleniyor
        /// </summary>
        EnvelopIsProcessing = 1100,
        /// <summary>
        ///Zip Dosyası Değil
        /// </summary>
        FileIsNotZip = 1110,
        /// <summary>
        ///Id Uzunluğu Geçersiz
        /// </summary>
        InvalidEnvelopIdLength = 1111,
        /// <summary>
        ///Arşivden Kopyalanamadı
        /// </summary>
        EnvelopCouldNotCopiedFromArchive = 1120,
        /// <summary>
        ///Zip Açılamadı
        /// </summary>
        CouldNotOpenZip = 1130,
        /// <summary>
        ///Zip Boş
        /// </summary>
        ZipIsEmpty = 1131,
        /// <summary>
        ///Xml Dosyası Değil
        /// </summary>
        FileIsNotXml = 1132,
        /// <summary>
        ///Zarf Id ve Xml Dosya Adı Aynı Değil
        /// </summary>
        EnvelopeIdAndXmlNameMustBeSame = 1133,
        /// <summary>
        ///Döküman Ayrıştırılamadı
        /// </summary>
        CouldNotParseDocument = 1140,
        /// <summary>
        ///Zarf Id Yok
        /// </summary>
        EnvelopeIdNotFound = 1141,
        /// <summary>
        ///Zarf Id ve Zip Dosya Adı Aynı Değil
        /// </summary>
        EnvelopeIdAndZipNameMustBeSame = 1142,
        /// <summary>
        ///Geçersiz Versiyon
        /// </summary>
        InvalidVersion = 1143,
        /// <summary>
        ///Schematron Kontrolü Hatalı
        /// </summary>
        SchematronCheckFailed = 1150,
        /// <summary>
        ///Şema Kontrolü Hatalı
        /// </summary>
        XmlSchemaCheckFailed = 1160,
        /// <summary>
        ///İmza Sahibi Tck Vkn Alınamadı
        /// </summary>
        CouldNotTakeTcknVknForSigner = 1161,
        /// <summary>
        ///İmza Kaydedilemedi
        /// </summary>
        CouldNotSaveSigniture = 1162,
        /// <summary>
        ///Gönderilen Zarf Sistemde Daha Önce Kayıtlı Bir Fatura İçeriyor
        /// </summary>
        EnvelopeIdIsAlreadyUsed = 1163,
        /// <summary>
        ///İmza Yetkisi Kontrol Edilemedi
        /// </summary>
        CouldNotCheckPermission = 1170,
        /// <summary>
        ///Gönderici Birim Yetkisi Yok
        /// </summary>
        DoesNotHaveSenderUnitPermission = 1171,
        /// <summary>
        ///Posta Kutusu Yetkisi Yok
        /// </summary>
        DoesNotHavePostBoxPermission = 1172,
        /// <summary>
        ///İmza Yetkisi Kontrol Edilemedi
        /// </summary>
        CouldNotCheckSignPermission = 1175,
        /// <summary>
        ///İmza Sahibi Yetkisiz
        /// </summary>
        SignerHasNoPermission = 1176,
        /// <summary>
        ///Adres Kontrol Edilemedi
        /// </summary>
        CouldNotCheckAddress = 1180,
        /// <summary>
        ///Adres Bulunamadı
        /// </summary>
        AddressNotFound = 1181,
        /// <summary>
        ///Özel Entegratör Başvurusu Yok
        /// </summary>
        DoesNotHaveEntegratorApplication = 1182,
        /// <summary>
        ///Sistem Yanıtı Hazırlanamadı
        /// </summary>
        CouldNotPrepareSystemResponse = 1190,
        /// <summary>
        ///Sistem Hatası
        /// </summary>
        SystemError = 1195,
        /// <summary>
        ///Zarf Başarıyla İşlendi
        /// </summary>
        EnvelopedProcessSuccessfully = 1200,
        /// <summary>
        ///Döküman Bulunan Adrese Gönderilemedi
        /// </summary>
        CouldNotSendDocumentToTheAddress = 1210,
        /// <summary>
        ///Döküman Gönderimi Başarısız. Tekrar Gönderme Sonlandı
        /// </summary>
        DocumentSendingFailedWillNotRetry = 1215,
        /// <summary>
        ///Hedeften Sistem Yanıtı Gelmedi
        /// </summary>
        TargetDoesNotSendSystemResponse = 1220,
        /// <summary>
        ///Hedeften Sistem Yanıtı Başarısız Geldi
        /// </summary>
        TargetSendFailedSystemResponse = 1230,
        /// <summary>
        ///Başarıyla Tamamlandı
        /// </summary>
        CompletedSuccessfully = 1300
    }
}
