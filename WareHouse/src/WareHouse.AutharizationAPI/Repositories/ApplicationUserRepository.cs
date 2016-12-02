using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.AutharizationAPI.Context;
using WareHouse.AutharizationAPI.Context.Models;
using WareHouse.AutharizationAPI.Repositories.Interfaces;
using WareHouse.AutharizationAPI.Repositories.Models;

namespace WareHouse.AutharizationAPI.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly UsersContext context;
        private readonly IEncryptor encrypter;

        public ApplicationUserRepository(UsersContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
        }

        public async Task<UserModel> GetUserByName(string username)
        {
            var user = await GetApplicationUserByName(username);

            if (user == null)
            {
                return null;
            }

            return await MapToUserModel(user);
        }

        public async Task<UserModel> GetUserById(string id)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return null;
            }

            return await MapToUserModel(user);
        }

        public async Task<OperationStatus> Login(LoginModel model)
        {
            var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

            return result.Succeeded ? OperationStatus.OK : OperationStatus.Failed;
        }

        public async Task<UserModel> Register(RegisterModel model)
        {
            var roles = model.Roles != null && model.Roles.Count() > 0 ? model.Roles : null;

            return await MapToUserModel(await RegisterUserWithRoles(model, roles));
        }

        private async Task<ApplicationUser> RegisterUserWithRoles(RegisterModel model, IEnumerable<string> roles)
        {
            var user = new ApplicationUser { UserName = model.Username };
            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return null;

            if (roles != null)
                await userManager.AddToRolesAsync(await userManager.FindByNameAsync(model.Username), roles);

            return await GetApplicationUserByName(model.Username);
        }

        private async Task<UserModel> MapToUserModel(ApplicationUser user)
        {
            var a = (await userManager.GetRolesAsync(user));

            return new UserModel
            {
                UserName = user.UserName,
                Roles = (await userManager.GetRolesAsync(user)),
                Id = user.Id
            };
        }

        public async Task<OperationStatus> AddRole(string username, string role)
        {
            var user = await GetApplicationUserByName(username);
            var roleId = context.Roles.FirstOrDefault(x => x.Name.ToLower() == role)?.Id;

            if (string.IsNullOrEmpty(roleId) || user == null)
                return OperationStatus.Failed;

            try
            {
                context.UserRoles.Add(new Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string> { RoleId = roleId, UserId = user.Id });
                var result = await context.SaveChangesAsync();
                return result <= 0  ? OperationStatus.Failed : OperationStatus.OK;
            }
            catch(Exception e)
            {
                return OperationStatus.Failed;
            }      
        }

        public async Task<OperationStatus> RemoveRole(string username, string role)
        {
            var result = await userManager.RemoveFromRoleAsync(await GetApplicationUserByName(username), role);

            return result.Succeeded ? OperationStatus.Failed : OperationStatus.Failed;
        }

        private async Task<ApplicationUser> GetApplicationUserByName(string username)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.UserName == username);
        }


    }
}
