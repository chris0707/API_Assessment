using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.WebPages;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Vino_API_Assessment.Models;

namespace Vino_API_Assessment.API
{
    public class InventoryProcess
    {

        public static async Task<List<InventoryModel>> LoadOrder()
        {
            string apiUrl = @"https://ct.soa-gw.canadapost.ca/rs/ship/price";
            HttpContent body = new StringContent(@"<?xml version=""1.0"" encoding=""utf-8""?><mailing-scenario xmlns = ""http://www.canadapost.ca/ws/ship/rate-v4"" ><customer-number>4008838</customer-number><parcel-characteristics><weight>1</weight></parcel-characteristics><origin-postal-code>K2B8J6</origin-postal-code><destination><domestic><postal-code>J0E1X0</postal-code></domestic></destination></mailing-scenario>",
                Encoding.UTF8, "application/vnd.cpc.ship.rate-v4+xml");


            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync(apiUrl, body))
            {
                InventoryModel inventory;
                XmlNode node;
                var a = await response.Content.ReadAsStringAsync();
                var xmlFile = XElement.Parse(a);

                var reader = xmlFile.CreateReader();
                reader.MoveToContent();

                var test1 = reader.ReadInnerXml();
                var test2 = "<wrapper>" + test1 + "</wrapper>";
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(test2);


                XmlNodeList xnl = doc.SelectNodes(string.Format("/wrapper"));

                List<InventoryModel> inventoryList = new List<InventoryModel>();

                foreach (XmlNode nnn in xnl)
                {
                    foreach (XmlNode item1 in nnn.ChildNodes)
                    {
                        inventory = new InventoryModel();
                        if ((item1).NodeType == XmlNodeType.Element)
                        {
                            var firstChild = item1.ChildNodes;

                            foreach (XmlNode item2 in firstChild)
                            {
                                if (item2.Name == "service-name")
                                {
                                    string testfield = item2.InnerText;
                                    inventory.ServiceName = testfield;
                                }
                                else if (item2.Name == "price-details")
                                {
                                    var secondChild = item2.ChildNodes;
                                    foreach (XmlNode item3 in secondChild)
                                    {
                                        if (item3.Name == "base")
                                        {
                                            string testBasePrice = item3.InnerText;
                                            inventory.Price = testBasePrice;
                                        }
                                    }
                                }
                                else if (item2.Name == "service-standard")
                                {
                                    var secondChild = item2.ChildNodes;
                                    foreach (XmlNode item3 in secondChild)
                                    {
                                        if(item3.Name == "expected-transit-time")
                                        {
                                            string testTransitTime = item3.InnerText;
                                            inventory.ExpectedDay = Int32.Parse(testTransitTime);
                                        }
                                    }

                                }
                            }
                        }
                        inventoryList.Add(inventory);
                    }
                }
                return inventoryList;
            }
        }
    }
}