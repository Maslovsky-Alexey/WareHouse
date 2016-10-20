using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using WareHouse.Data.Model;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.Domain.ServiceInterfaces;
using Employee = WareHouse.Domain.Model.Employee;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class AccountService : IAccountService
    {
        private readonly IClientService clientService;
        private readonly IEmployeeService employeeService;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserService userService;

        public AccountService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IUserService userService,
            IClientService clientService,
            IEmployeeService employeeService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;

            this.clientService = clientService;
            this.employeeService = employeeService;
            this.userService = userService;
        }

        public async Task<UserModel> GetCurrentUser(HttpContext httpContext)
        {
            var user = await userService.GetUserByName(httpContext.User.Identity.Name, false);

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
            return await MapToUserModel(await RegisterUserWithRole(model, "client"));
        }

        public async Task<UserModel> RegisterEmployee(RegisterModel model)
        {
            return await MapToUserModel(await RegisterUserWithRole(model, "employee"));
        }

        public async Task<UserModel> GetUserByName(string username)
        {
            return await MapToUserModel(await userService.GetUserByName(username, false));
        }


        private async Task EnsureAddDefauleUser()
        {
            if (await userManager.FindByNameAsync("admin") == null)
            {
                await userManager.CreateAsync(new ApplicationUser {UserName = "admin"}, "admin");
                await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "employee");
            }

            await employeeService.Add(new Employee
            {
                Name = "Administrator",
                UserId = (await userService.GetUserByName("admin", false)).Id
            });
        }

        private async Task<ApplicationUser> RegisterUserWithRole(RegisterModel model, string role)
        {
            var user = new ApplicationUser {UserName = model.Username};
            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return null;

            await userManager.AddToRoleAsync(await userManager.FindByNameAsync(model.Username), role);

            return await userService.GetUserByName(model.Username, false);
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
                return (await employeeService.GetEmployeeByIdentityId(user.Id)).Name;
            if (await UserHasRole(user, "client"))
                return (await clientService.GetClientByIdentityId(user.Id)).Name;

            return null;
        }

        private async Task<bool> UserHasRole(ApplicationUser user, string role)
        {
            return (await userManager.GetRolesAsync(user)).FirstOrDefault(x => x == role) != null;
        }
    }
}