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
        private ILdapHelper ldapHelper;

        private IRolesMapper rolesMapper;

        private IApplicationUserRepository userRepository;

        public LdapRepository(ILdapHelper ldapHelper, IRolesMapper rolesMapper, IApplicationUserRepository userRepository)
        {
            this.ldapHelper = ldapHelper;
            this.rolesMapper = rolesMapper;
            this.userRepository = userRepository;
        }

        public async Task<OperationStatus> Login(LoginModel model)
        {
            var user = ldapHelper.Login(model.Username, model.Password);

            if (user == null)
            {
                return OperationStatus.Failed;
            }

            if (await userRepository.GetUserByName(model.Username.Remove(model.Username.IndexOf("@"))) != null)
            {
                return OperationStatus.OK;
            }
            else
            {
                await userRepository.Register(new RegisterModel
                {
                    Username = model.Username.Substring(0, model.Username.IndexOf("@")),
                    Password = model.Password,
                    Roles = rolesMapper.MapToWebRoles(user.Roles)
                });

                return OperationStatus.OK;
            }
        }
    }
}
