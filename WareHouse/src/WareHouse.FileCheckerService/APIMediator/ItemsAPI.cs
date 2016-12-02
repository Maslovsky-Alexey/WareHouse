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
    public class ItemsAPI : IItemsAPI
    {
        private readonly IWebRequestHelper webRequestHelper;
        private string authToken;


        public ItemsAPI(IWebRequestHelper webRequestHelper, string authToken)
        {
            this.webRequestHelper = webRequestHelper;
            this.authToken = authToken;
        }


        public void AddItem(ItemAPIModel model)
        {
            var response = webRequestHelper.Post("/api/operations/items", JsonConvert.SerializeObject(model), "application/json; charset=UTF-8", authToken);
        }
    }
}
