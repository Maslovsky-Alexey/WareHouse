using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.FileCheckerService.APIMediator.Interfaces;
using WareHouse.FileCheckerService.Models.APIModel;

namespace WareHouse.FileCheckerService.APIMediator
{
    public class OrdersAPI : IOrdersAPI
    {
        private readonly IBaseMediator baseMediator;
        private string authToken;

        public OrdersAPI(IBaseMediator baseMediator, string authToken)
        {
            this.baseMediator = baseMediator;
            this.authToken = authToken;
        }

        public void AddItem(OrderAPIModel model)
        {
            baseMediator.SendRequest("http://localhost:33649/api/operations/order", "post", JsonConvert.SerializeObject(model), "application/json; charset=UTF-8", authToken);
        }
    }
}
