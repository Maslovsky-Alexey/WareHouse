using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WareHouse.Data.Repository;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.Domain.Service.ConcreteServices;
using WareHouse.Domain.ServiceInterfaces;
using WareHouse.Domain.ServiceInterfaces.Safe;

namespace WareHouse.Domain.Service.ProxyServices
{
    public class OperationProxyService : ISafeOperationService
    {
        private ISafeOperationService safeOperationService;


        public OperationProxyService(ISafeOperationService safeOperationService)
        {
            this.safeOperationService = safeOperationService;
        }
    }
}
