using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Web.Mvc;
using ePlatform.Api.eBelge.Invoice.Models;
using Newtonsoft.Json;

namespace ePlatform.Api.eBelge.Invoice.Sample.Mvc.Controllers
{
    public class GibUserController : Controller
    {
        // GET: GibUser
        private readonly CommonClient commonClient;

        public GibUserController(CommonClient commonClient)
        {
            this.commonClient = commonClient;
        }
        public async Task<ActionResult> Index()
        {
            return View(await commonClient.GetUserAliasListZip());
        }
    }
}
