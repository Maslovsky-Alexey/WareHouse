using System.Threading.Tasks;
using WareHouse.Domain.Model;

namespace WareHouse.Domain.ServiceInterfaces
{
    public interface IProviderService : IService<Provider, Data.Model.Provider>
    {
        Task<Provider> GetProviderByName(string name, bool ignoreCase);

        Task AddWithoutRepetition(Provider value);

        Task RemoveProviderByName(Provider value);
    }
}