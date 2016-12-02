using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.Model;
using WareHouse.Data.Repository;

namespace WareHouse.Domain.ServiceInterfaces.Unsafe
{
    public interface IUnsafeService<ServiceModel, EFModel>
        where EFModel : BaseModel
        where ServiceModel : Model.BaseModel
    {
        Task<OperationStatus> Add(ServiceModel item);

        Task<OperationStatus> Remove(ServiceModel item);
    }
}
