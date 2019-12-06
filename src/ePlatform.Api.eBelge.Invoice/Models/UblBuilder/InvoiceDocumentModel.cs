using System;

namespace ePlatform.Api.eBelge.Invoice.Models
{
    public class InvoiceDocumentModel
    {
        public string InvoiceId { get; set; }
        public string DocumentId { get; set; }
        public string DocumentType { get; set; }
        public string DocumentBase64 { get; set; }
        public byte[] Bytes { get; set; }
        public string FileName { get; set; }
        public DateTime? DocumentDate { get; set; }
        public bool IsFileExist { get; set; }
    }
}