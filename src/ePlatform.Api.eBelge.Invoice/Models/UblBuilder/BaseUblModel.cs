using System.Collections.Generic;

namespace ePlatform.Api.eBelge.Invoice.Models
{
    public class BaseUblModel<TGeneral, TLine, TTax, TTotals, TPaymentMeans, TPaymentTerms, TOrderInfo, TArchiveInfo, TRelatedDespatch, TBuyerCustomerInfo, TTaxRepresentativePartyInfo>
        where TGeneral : GeneralInfoBaseModel, new()
        where TLine : InvoiceLineBaseModel<TTax>
        where TTax : InvoiceLineTaxBaseModel
        where TTotals : InvoiceTotalsBaseModel, new()
        where TPaymentMeans : PaymentMeansBaseModel, new()
        where TPaymentTerms : PaymentTermsBaseModel, new()
        where TOrderInfo : OrderInfoBaseModel, new()
        where TArchiveInfo : ArchiveInfoBaseModel, new()
        where TRelatedDespatch : RelatedDespatchBaseModel
        where TBuyerCustomerInfo : BuyerCustomerInfoBaseModel, new()
        where TTaxRepresentativePartyInfo : TaxRepresentativePartyInfoBaseModel, new()
    {
        public bool isSend { get; set; }
        public int RecordType { get; set; }
        public string Note { get; set; }
        public virtual TGeneral GeneralInfoModel { get; set; }
        public virtual List<TLine> InvoiceLines { get; set; }
        public virtual TTotals InvoiceTotalsModel { get; set; }
        public virtual TPaymentMeans PaymentMeansModel { get; set; }
        public virtual TPaymentTerms PaymentTermsModel { get; set; }
        public virtual TOrderInfo OrderInfoModel { get; set; }
        public virtual TArchiveInfo ArchiveInfoModel { get; set; }
        public virtual List<TRelatedDespatch> RelatedDespatchList { get; set; }
        public List<CustomDocumentReferenceModel> CustomDocumentReferenceList { get; set; }
        public AdditionalInvoiceTypeBaseModel AdditionalInvoiceTypeInfo { get; set; }

        #region Ihracat ve YolcuBeraberinde
        public virtual TBuyerCustomerInfo BuyerCustomerInfoModel { get; set; }
        public virtual TTaxRepresentativePartyInfo TaxRepresentativePartyInfoModel { get; set; }
        #endregion

        public BaseUblModel()
        {
            this.GeneralInfoModel = new TGeneral();
            this.InvoiceLines = new List<TLine>();
            this.InvoiceTotalsModel = new TTotals();
            this.PaymentMeansModel = new TPaymentMeans();
            this.PaymentTermsModel = new TPaymentTerms();
            this.OrderInfoModel = new TOrderInfo();
            this.ArchiveInfoModel = new TArchiveInfo();
            this.RelatedDespatchList = new List<TRelatedDespatch>();
            this.BuyerCustomerInfoModel = new TBuyerCustomerInfo();
            this.TaxRepresentativePartyInfoModel = new TTaxRepresentativePartyInfo();
            this.AdditionalInvoiceTypeInfo = new AdditionalInvoiceTypeBaseModel();
            this.CustomDocumentReferenceList = new List<CustomDocumentReferenceModel>();
        }
    }
}