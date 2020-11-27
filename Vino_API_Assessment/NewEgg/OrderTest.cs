
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Newegg.Marketplace.SDK.Base.Util;
using Newegg.Marketplace.SDK.Order;
using Newegg.Marketplace.SDK.Order.Model;
using Newegg.Marketplace.SDK.Item;
using Newegg.Marketplace.SDK.Seller;
using Newegg.Marketplace.SDK.DataFeed;
using Newegg.Marketplace.SDK.RMA;
using Newegg.Marketplace.SDK.Shipping.Model;
using Newegg.Marketplace.SDK.Report.Model;
using Newegg.Marketplace.SDK.Other;
using Newegg.Marketplace.SDK.Base;
using Newegg.Marketplace.SDK;

namespace Vino_API_Assessment.NewEgg
{
    public class OrderTest
    {
        private OrderCall ordercall;
        private ItemCall itemCall;
        private SellerCall sellerCall;
        private DatafeedCall datafeedCall;
        private RMACall rmaCall;
        private ShippingCall shippingCall;
        private ReportCall reportCall;
        private OtherCall otherCall;

        public OrderTest()
        {
            //Construct an APIConfig with SellerID,  APIKey(Authorization) and SecretKey.
            APIConfig config = new APIConfig("****", "********************************", "********-****-****-****-************");
            // or load the config file to get it.
            //APIConfig config = APIConfig.FromJsonFile("setting.json");

            //Create a APIClient with the config
            APIClient client = new APIClient(config) { SimulationEnabled=true};

            //Create the Api Call object with he client.
            ordercall = new OrderCall(client);
            itemCall = new ItemCall(client);
            sellerCall = new SellerCall(client);
            datafeedCall = new DatafeedCall(client);
            rmaCall = new RMACall(client);
            shippingCall = new ShippingCall(client);
            reportCall = new ReportCall(client);
            otherCall = new OtherCall(client);
        }

        #region Order API Demo

        /// <summary>
        /// Get Unshipped Order during a time period.
        /// </summary>
        public void GetOrderInfo()
        {
            Console.WriteLine("GetOrderInfo");

            // Create Request
            var orderreq = new GetOrderInformationRequest(new GetOrderInformationRequestCriteria()
            {
                Status = Newegg.Marketplace.SDK.Order.Model.OrderStatus.Unshipped,
                Type = OrderInfoType.All,
                OrderDateFrom = "2016-01-01 09:30:47",
                OrderDateTo = "2017-12-17 09:30:47",
                OrderDownloaded = 0
            });

            // Send your request and get response
            var response = ordercall.GetOrderInformation(null, orderreq).Result;

            // Get data from the response
            GetOrderInformationResponseBody info = response.GetResponseBody();

            // Use the data pre you business
            Console.WriteLine(string.Format("There are {0} order(s) in the result.", info.OrderInfoList.Count.ToString()));

        }

        /// <summary>
        /// Get the status of special order
        /// </summary>
        public void GetOrderStatus()
        {
            Console.WriteLine("GetOrderStatus");

            // Send your request and get response
            var orderstatus = ordercall.GetOrderStatus("105137040").Result;

            // Use the data pre you business
            Console.WriteLine(string.Format("There order status is {0}.", orderstatus.OrderStatusName));
        }

        /// <summary>
        /// Get addtional Information of order.
        /// </summary>
        public void GetAddOrderInfo()
        {
            Console.WriteLine("GetAddOrderInfo");

            // Create Request
            var addorderreq = new GetAdditionalOrderInformationRequest(new GetAdditionalOrderInformationRequestCriteria()
            {
                OrderDateFrom = "2019-01-11 00:30:47",
                OrderDateTo = "2019-1-31 09:30:47",
                CountryCode = "USA"
            });

            // Send your request and get response
            var result = ordercall.GetAdditionalOrderInformation(addorderreq).Result;

            // Use the data pre you business
            Console.WriteLine(string.Format("There are {0} orders infomation responsed.", result.GetResponseBody().AddOrderInfoList.Count));
        }

        #endregion
    }
}