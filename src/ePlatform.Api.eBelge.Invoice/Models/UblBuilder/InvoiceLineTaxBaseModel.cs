using System;

namespace ePlatform.Api.eBelge.Invoice.Models
{
    public class InvoiceLineTaxBaseModel
    {
        public string TaxTypeCode { get; set; }
        public string TaxName { get; set; }
        public Decimal? TaxRate { get; set; }
        public Decimal TaxAmount { get; set; }
        public string VatExemptionReasonCode { get; set; }
        public string VatExemptionReason { get; set; }

        public bool IsWithHolding
        {
            get
            {
                if (TaxTypeCode == "9015")
                    return true;
                else
                    return false;
            }
        }

        public bool IsNegative
        {
            get
            {
                if (TaxTypeCode == "0003" || TaxTypeCode == "0011" || TaxTypeCode == "9015" || TaxTypeCode == "4171")
                    return true;
                else
                    return false;
            }
        }

        public long? WithHoldingId { get; set; }
        public string WithHoldingCode { get; set; }
        public decimal TaxableAmount { get; set; }

        internal InvoiceLineTaxBaseModel Clone()
        {
            return new InvoiceLineTaxBaseModel
            {
                TaxTypeCode = this.TaxTypeCode,
                TaxName = this.TaxName,
                TaxRate = this.TaxRate,
                TaxAmount = this.TaxAmount,
                TaxableAmount = this.TaxableAmount,
                VatExemptionReasonCode = this.VatExemptionReasonCode,
                VatExemptionReason = this.VatExemptionReason,
                WithHoldingId = this.WithHoldingId,
                WithHoldingCode = this.WithHoldingCode
            };
        }
    }
}