using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.AutharizationAPI.Repositories.Interfaces;
using WareHouse.AutharizationAPI.Repositories.Models;
using WareHouse.AutharizationAPI.LdapHelper;
using WareHouse.AutharizationAPI.RolesMapper;
using WareHouse.AutharizationAPI.RolesMapper.Models;


namespace WareHouse.AutharizationAPI.Repositories
{
    public class LdapRepository : ILdapRepository
    {
        private ILdapHelper ldpaHelper;

        private IRolesMapper rolesMapper;


        public LdapRepository(ILdapHelper ldpaHelper, IRolesMapper rolesMapper)
        {
            this.ldpaHelper = ldpaHelper;
            this.rolesMapper = rolesMapper;
        }

        public Task<UserModel> GetUserByName(string username)
        {
            return null;
        }

        public Task<OperationStatus> Login(LoginModel model)
        {
            return null;
        }
    }
}
