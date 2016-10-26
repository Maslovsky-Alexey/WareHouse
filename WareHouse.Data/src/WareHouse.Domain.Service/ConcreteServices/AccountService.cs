using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using WareHouse.Data.Model;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.Domain.ServiceInterfaces;
using Employee = WareHouse.Domain.Model.Employee;
using WareHouse.Domain.ServiceInterfaces.Safe;
using WareHouse.Domain.ServiceInterfaces.Unsafe;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class AccountService : IAccountService
    {
        private readonly ISafeClientService safeClientService;
        private readonly IUnsafeClientService unsafeClientService;

        private readonly ISafeEmployeeService safeEmployeeService;
        private readonly IUnsafeEmployeeService unsafeEmployeeService;

        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ISafeUserService safeUserService;

        public AccountService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ISafeUserService safeUserService,
            ISafeClientService safeClientService, IUnsafeClientService unsafeClientService,
            ISafeEmployeeService safeEmployeeService, IUnsafeEmployeeService unsafeEmployeeService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;

            this.safeClientService = safeClientService;
            this.unsafeClientService = unsafeClientService;

            this.safeEmployeeService = safeEmployeeService;
            this.unsafeEmployeeService = unsafeEmployeeService;

            this.safeUserService = safeUserService;
        }

        public async Task<UserModel> GetCurrentUser(HttpContext httpContext)
        {
            var user = await safeUserService.GetUserByName(httpContext.User.Identity.Name, false);

            if (user == null)
                return null;

            return await MapToUserModel(user);
        }

        public async Task<bool> Login(LoginModel model)
        {
            await EnsureAddDefauleUser();

            return (await signInManager.PasswordSignInAsync(model.Username, model.Password, false, false)).Succeeded;
        }

        public async Task<UserModel> RegisterClient(RegisterModel model)
        {
            var client = await safeClientService.GetClientByName(model.Username, true);

            if (client != null && !string.IsNullOrEmpty(client.UserId))
                return null;

            var user = await RegisterUserWithRole(model, "client");

            if (client == null)
                await unsafeClientService.Add(new Domain.Model.Client {Name = model.Username, UserId = user.Id});   
            else
                await unsafeClientService.AssignWithApplicationUser(client.Id, user.Id);
            
            return await MapToUserModel(user);
        }

        public async Task<UserModel> RegisterEmployee(RegisterModel model)
        {
            var employee = await safeEmployeeService.GetEmployeeByName(model.Username, true);

            if (employee != null && !string.IsNullOrEmpty(employee.UserId))
                return null;

            var user = await RegisterUserWithRole(model, "employee");

            if (employee == null)
                await unsafeEmployeeService.Add(new Domain.Model.Employee { Name = model.Username, UserId = user.Id });
            else
                await unsafeEmployeeService.AssignWithApplicationUser(employee.Id, user.Id);

            return await MapToUserModel(user);
        }

        public async Task<UserModel> GetUserByName(string username)
        {
            return await MapToUserModel(await safeUserService.GetUserByName(username, false));
        }


        private async Task EnsureAddDefauleUser()
        {
            if (await userManager.FindByNameAsync("admin") == null)
            {
                await userManager.CreateAsync(new ApplicationUser {UserName = "admin"}, "admin");
                await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "employee");
            }

            await unsafeEmployeeService.Add(new Employee
            {
                Name = "Administrator",
                UserId = (await safeUserService.GetUserByName("admin", false)).Id
            });
        }

        private async Task<ApplicationUser> RegisterUserWithRole(RegisterModel model, string role)
        {
            var user = new ApplicationUser {UserName = model.Username};
            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return null;

            await userManager.AddToRoleAsync(await userManager.FindByNameAsync(model.Username), role);

            return await safeUserService.GetUserByName(model.Username, false);
        }

        private async Task<UserModel> MapToUserModel(ApplicationUser user)
        {
            return new UserModel
            {
                isEmployee = await UserHasRole(user, "employee"),
                Login = user.UserName,
                Name = await GetUserName(user)
            };
        }

        private async Task<string> GetUserName(ApplicationUser user)
        {
            if (await UserHasRole(user, "employee"))
                return (await safeEmployeeService.GetEmployeeByIdentityId(user.Id)).Name;
            if (await UserHasRole(user, "client"))
                return (await safeClientService.GetClientByIdentityId(user.Id)).Name;

            return null;
        }

        private async Task<bool> UserHasRole(ApplicationUser user, string role)
        {
            return (await userManager.GetRolesAsync(user)).FirstOrDefault(x => x == role) != null;
        }
    }
}