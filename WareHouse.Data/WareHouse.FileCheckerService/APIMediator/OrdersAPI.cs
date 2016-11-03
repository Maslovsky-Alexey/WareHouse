using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.FileCheckerService.APIMediator.Interfaces;
using WareHouse.FileCheckerService.APIMediator.WebRequestHelper;
using WareHouse.FileCheckerService.Models.APIModel;

namespace WareHouse.FileCheckerService.APIMediator
{
    public class OrdersAPI : IOrdersAPI
    {
        private readonly IWebRequestHelper webRequestHelper;
        private string authToken;

        public OrdersAPI(IWebRequestHelper webRequestHelper, string authToken)
        {
            this.webRequestHelper = webRequestHelper;
            this.authToken = authToken;
        }

        public void AddItem(OrderAPIModel model)
        {
            var response = webRequestHelper.Post("/api/operations/orders", JsonConvert.SerializeObject(model), "application/json; charset=UTF-8", authToken);
        }
    }
}
