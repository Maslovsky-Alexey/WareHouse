using System.Threading.Tasks;
using WareHouse.Data.Model;

namespace WareHouse.Data.Repository
{
    public interface IProviderRepository : IRepository<Provider>
    {
        Task<Provider> GetProviderByName(string name, bool ignoreCose);
    }
}