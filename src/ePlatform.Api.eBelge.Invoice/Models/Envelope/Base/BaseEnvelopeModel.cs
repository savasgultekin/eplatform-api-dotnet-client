using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ePlatform.Api.eBelge.Invoice.Models
{
    public class BaseEnvelopeModel
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public EnvelopeStatus Status { get; set; }
        public EnvelopeType Type { get; set; }
        public PackageType PackageType { get; set; }
        public int TargetSystemUserId { get; set; }
        public int FileSize { get; set; }
        public int TryCount { get; set; }
        public DateTime? LastTryDate { get; set; }
        public string Message { get; set; }
        public string ObjectStorageKey { get; set; }
        public DateTime CreatedDate { get; set; }


        [XmlIgnore]
        [IgnoreDataMember]
        [NotMapped]
        public string TableOperations { get; set; }

        public string GibStatus { get; set; }

        public string GibDescription { get; set; }

        [XmlIgnore]
        [IgnoreDataMember]
        [NotMapped]
        public string IdString2 { get; set; }
    }
}
