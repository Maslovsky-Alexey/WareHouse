using System.Threading.Tasks;
using WareHouse.Data.Model;
using WareHouse.Data.Repository;
using WareHouse.Domain.ServiceInterfaces;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<ApplicationUser> GetUserByName(string name, bool ignoreCase)
        {
            return await userRepository.GetUserByName(name, ignoreCase);
        }
    }
}