using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vino_API_Assessment.Models
{
    public class NewEggItem
    {
        public string OrderNumber { get; set; }
        public string ShipToFirstName { get; set; }
        public string ShipToAddress1 { get; set; }
        public string ShipToZipCode { get; set; }
        public string ShipToCountryCode { get; set; }
    }
}