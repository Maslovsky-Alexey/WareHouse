using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;

namespace WareHouse.Domain.Service.ElasticSearchProviders
{
    public interface IElasticSearchtemProvider : IElasticSearchProvider<WarehouseItemViewModel>
    {
        
    }
}
