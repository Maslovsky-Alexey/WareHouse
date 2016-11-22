using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.Model;

namespace WareHouse.Domain.ServiceInterfaces.Safe
{
    public interface ISafeService<ServiceModel, EFModel>
        where EFModel : BaseModel
        where ServiceModel : Model.BaseModel
    {
        Task<IEnumerable<ServiceModel>> GetAll();

        Task<ServiceModel> GetItem(int id);

        Task<int> Count();
    }
}
