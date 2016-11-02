using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.FileCheckerService.APIMediator.Interfaces;
using WareHouse.FileCheckerService.Models.APIModel;

namespace WareHouse.FileCheckerService.APIMediator
{
    public class OrdersAPIMediator : BaseMediator<OrderAPIModel>, IOrdersMediator
    {
        public OrdersAPIMediator() : base("http://localhost:33649", "api/operations/order")
        {

        }
    }
}
