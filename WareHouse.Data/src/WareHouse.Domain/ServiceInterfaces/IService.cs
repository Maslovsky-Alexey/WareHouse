using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.Domain.ServiceInterfaces
{
    public interface IService<ServiceModel, EFModel> 
        where EFModel : Data.Model.BaseModel
        where ServiceModel : Domain.Model.BaseModel
    {
        Task<IEnumerable<ServiceModel>> GetAll();

        Task Add(ServiceModel item);

        Task Remove(ServiceModel item);

        Task<ServiceModel> GetItem(int id);

        Task<int> Count();
    }
}
