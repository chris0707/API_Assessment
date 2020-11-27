using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Vino_API_Assessment.Models
{
    /**
     * Please ignore the comments, those were added 
     * when I had issue with converting string xml to xml.
     */
    //[Serializable, XmlRoot("price-quotes")]
    public class InventoryModel
    {
        //[XmlElement(ElementName = "service-name")]
        public string ServiceName { get; set; }

        //[XmlElement(ElementName = "expected-transit-time")]
        public int ExpectedDay { get; set; }

        //[XmlElement(ElementName = "base")]
        public string Price { get; set; }
    }
}