using ePlatform.Api.eBelge.Invoice.Models;
using System;
using System.Collections.Generic;

namespace ePlatform.Api.eBelge.Invoice.Tests
{
    public static class FillUblModel
    {
        public static UblBuilderModel fillUblModel()
        {
            var ublModel = new UblBuilderModel();
            var invoiceLines = new List<InvoiceLineBaseModel<InvoiceLineTaxBaseModel>>();

            var generalInfo = new GeneralInfoBaseModel()
            {
                Ettn = Guid.NewGuid(),
                Prefix = null,
                InvoiceNumber = null,
                InvoiceProfileType = InvoiceProfileType.TEMELFATURA,
                IssueDate = DateTime.Now,
                Type = InvoiceType.SATIS,
                CurrencyCode = "TRY"
            };

            var addressBook = new AddressBookModel()
            {
                Alias = "urn:mail:defaulttest11pk@medyasoft.com.tr",
                IdentificationNumber = "1234567801",
                ReceiverPersonSurName = "Medyasoft Test",
                Name = "Test Kurum Üç",
                ReceiverCity = "İstanbul",
                ReceiverDistrict = "Üsküdar",
                ReceiverCountry = "Türkiye"
                // ReceiverCountryId = 1
            };

            var invoiceLine = new InvoiceLineBaseModel<InvoiceLineTaxBaseModel>()
            {
                Amount = 1,
                InventoryCard = "Test",
                DiscountAmount = 0,
                UnitCode = "C62",
                UnitPrice = 100,
                VatRate = 10,
                VatExemptionReasonCode = "201"
            };
            invoiceLines.Add(invoiceLine);

            ublModel.Status = (int)InvoiceStatus.Queued;
            // ublModel.Status = (int)InvoiceStatus.Draft; // Taslak olarak kayıt etmek isterseniz.
            ublModel.XsltCode = null;
            ublModel.UseManualInvoiceId = false;
            ublModel.GeneralInfoModel = generalInfo;
            ublModel.AddressBook = addressBook;
            ublModel.InvoiceLines = invoiceLines;
            ublModel.RecordType = (int)RecordType.Invoice;

            ublModel.GeneralInfoModel = generalInfo;
            ublModel.AddressBook = addressBook;
            ublModel.InvoiceLines = invoiceLines;

            return ublModel;
        }
    }
}