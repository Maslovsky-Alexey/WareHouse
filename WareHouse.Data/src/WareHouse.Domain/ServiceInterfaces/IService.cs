using System.Collections.Generic;
using System.Threading.Tasks;
using WareHouse.Data.Model;
using WareHouse.Data.Repository;
using WareHouse.Domain.ServiceInterfaces.Safe;
using WareHouse.Domain.ServiceInterfaces.Unsafe;

namespace WareHouse.Domain.ServiceInterfaces
{

    public interface IService<ServiceModel, EFModel> : ISafeService<ServiceModel, EFModel>, IUnsafeService<ServiceModel, EFModel>
        where EFModel : BaseModel
        where ServiceModel : Model.BaseModel 
    {
      

    }
}