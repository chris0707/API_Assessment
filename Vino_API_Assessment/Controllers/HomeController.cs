using Newegg.Marketplace.SDK;
using Newegg.Marketplace.SDK.Base;
using Newegg.Marketplace.SDK.Order;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using Vino_API_Assessment.API;
using Vino_API_Assessment.Models;
using Vino_API_Assessment.NewEgg;

namespace Vino_API_Assessment.Controllers
{
    public class HomeController : Controller
    {
        //CanadaPost
        public async Task<ActionResult> Index()
        {

            ApiHelper.InitializeClient();
            List<InventoryModel> a = await InventoryProcess.LoadOrder();
            return View(a);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //NewEgg
        public static async Task<NewEggItem> LoadOrder()
        {
            APIConfig config = APIConfig.FromJsonFile(@"D:\Projects\API_Project\Vino_API_Assessment\Vino_API_Assessment\Scripts\settings.json");
            //var fakeUSAClientXML = new APIClient(USA_Config_XML) { SimulationEnabled = true };
            //APIConfig config = new APIConfig("****", "********************************", "********-****-****-****-************");


            APIClient client = new APIClient(config) { SimulationEnabled = true };

            OrderCall orderCall = new OrderCall(client);

            var orderstatus = await orderCall.GetOrderStatus("105137040", 304);


            NewEggItem newEgg = new NewEggItem();
            return newEgg;
        }








       
        
    }
}