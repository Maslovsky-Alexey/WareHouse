using System.Collections.Generic;
using System.Threading.Tasks;
using WareHouse.Data.Model;
using WareHouse.Data.Repository;

namespace WareHouse.Domain.ServiceInterfaces
{
    public interface IService<ServiceModel, EFModel>
        where EFModel : BaseModel
        where ServiceModel : Model.BaseModel
    {
        Task<IEnumerable<ServiceModel>> GetAll();

        Task<OperationStatus> Add(ServiceModel item);

        Task<OperationStatus> Remove(ServiceModel item);

        Task<ServiceModel> GetItem(int id);

        Task<int> Count();
    }
}