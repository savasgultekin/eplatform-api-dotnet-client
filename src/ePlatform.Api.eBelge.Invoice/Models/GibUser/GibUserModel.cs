using System;

namespace ePlatform.Api.eBelge.Invoice.Models
{
    public class GibTokenModel
    {
        public int Id { get; set; }

        public string Identifier { get; set; }

        public string Title { get; set; }

        public GibUserType GibUserType { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
