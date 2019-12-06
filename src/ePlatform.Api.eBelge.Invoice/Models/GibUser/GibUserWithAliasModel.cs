using System.Collections.Generic;

namespace ePlatform.Api.eBelge.Invoice.Models
{
    public class GibUserWithAliasModel
    {
        public GibTokenModel Definition { get; set; }
        public List<GibUserAliasModel> ReceiverboxAliases { get; set; }
        public List<GibUserAliasModel> SenderboxAliases { get; set; }
    }
}
