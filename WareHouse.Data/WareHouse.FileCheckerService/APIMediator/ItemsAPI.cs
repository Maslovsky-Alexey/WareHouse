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
    public class ItemsAPI : IItemsAPI
    {
        private readonly IBaseMediator baseMediator;
        private string authToken;


        public ItemsAPI(IBaseMediator baseMediator, string authToken)
        {
            this.baseMediator = baseMediator;
            this.authToken = authToken;
        }


        public void AddItem(ItemAPIModel model)
        {
            baseMediator.SendRequest("http://localhost:33649/api/operations/item", "post", JsonConvert.SerializeObject(model), "application/json; charset=UTF-8", authToken);
        }
    }
}
