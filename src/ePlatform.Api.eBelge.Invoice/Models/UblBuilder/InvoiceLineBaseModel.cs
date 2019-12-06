using System;
using System.Collections.Generic;

namespace ePlatform.Api.eBelge.Invoice.Models
{
    public class InvoiceLineBaseModel<TTax> where TTax : InvoiceLineTaxBaseModel
    {
        public long InventoryServiceType { get; set; }
        public string InventoryCard { get; set; }
        public bool SerialNoEnabled { get; set; }
        public Decimal Amount { get; set; }
        public long UnitCodeId { get; set; }
        public string UnitCode { get; set; }
        public Decimal UnitPrice { get; set; }
        public Decimal DiscountRate { get; set; }
        public Decimal DiscountAmount { get; set; }
        public Decimal VatRate { get; set; }
        public Decimal VatAmount { get; set; }
        public string VatExemptionReasonCode { get; set; }
        public string VatExemptionReason { get; set; }
        public virtual List<TTax> Taxes { get; set; }
        public InvoiceLineDeliveryInfoBaseModel InvoiceLineDeliveryInfoModel { get; set; }
        public List<string> SerialNumberList { get; set; }

        public InvoiceLineBaseModel()
        {
            this.Taxes = new List<TTax>();
            this.SerialNumberList = new List<string>();
            this.InvoiceLineDeliveryInfoModel = new InvoiceLineDeliveryInfoBaseModel();
        }
    }
}