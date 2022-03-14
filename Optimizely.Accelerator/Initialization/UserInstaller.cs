using EPiServer.Authorization;
using EPiServer.Shell.Security;
using EPiServer.Web;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optimizely.Web.Initialization
{
    public class UserInstaller : IBlockingFirstRequestInitializer
    {
        private readonly UIUserProvider _uiUserProvider;
        private readonly UISignInManager _signInManager;
        private readonly UIRoleProvider _uiRoleProvider;

        public UserInstaller(UIUserProvider uiUserProvider, UISignInManager signInManager, UIRoleProvider uiRoleProvider)
        {
            _uiUserProvider = uiUserProvider;
            _signInManager = signInManager;
            _uiRoleProvider = uiRoleProvider;
        }

        public bool CanRunInParallel => false;

        public async Task InitializeAsync(HttpContext httpContext)
        {
            if (await IsAnyUserRegistered())
            {
                return;
            }

            await CreateUser("epiadmin", "admin@example.com", "Episerver123!", new[] { Roles.Administrators, Roles.WebAdmins });
        }


        private async Task<bool> IsAnyUserRegistered()
        {
            var res = await _uiUserProvider.GetAllUsersAsync(0, 1).CountAsync();
            return res > 0;
        }
        private async Task CreateUser(string username, string email, string password, IEnumerable<string> roles)
        {
            var result = await _uiUserProvider.CreateUserAsync(username, password, email, null, null, true);
            if (result.Status == UIUserCreateStatus.Success)
            {
                foreach (var role in roles)
                {
                    var exists = await _uiRoleProvider.RoleExistsAsync(role);
                    if (!exists)
                    {
                        await _uiRoleProvider.CreateRoleAsync(role);
                    }
                }

                await _uiRoleProvider.AddUserToRolesAsync(result.User.Username, roles);
                var resFromSignIn = await _signInManager.SignInAsync(username, password);
            }
        }
    }
}
