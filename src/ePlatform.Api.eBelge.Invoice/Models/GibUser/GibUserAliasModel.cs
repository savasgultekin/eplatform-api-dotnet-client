
namespace ePlatform.Api.eBelge.Invoice.Models
{
    public class GibUserAliasModel
    {

        public int Id { get; set; }

        public int GibUserId { get; set; }

        public string Alias { get; set; }
        public int? AppType { get; set; }
        public GibAliasType GibAliasType { get; set; }
        public string Identifier { get; set; }
        public string Title { get; set; }
        public int GibUserType { get; set; }

        public System.DateTime FirstCreationTime { get; set; }

        public System.DateTime AliasCreationTime { get; set; }

        public bool IsActive { get; set; }

        public System.DateTime CreatedDate { get; set; }

        public System.DateTime UpdatedDate { get; set; }
    }
}
