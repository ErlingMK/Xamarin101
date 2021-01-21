using System.Threading.Tasks;
using Intents;
using TestApp.Services.PlatformServices;

namespace TestApp.iOS.Services
{
    internal class LoginService : ILoginService
    {
        private readonly IUserService _userService;

        public LoginService(IUserService userService)
        {
            _userService = userService;
        }

        public Task<bool> Authenticate()
        {
            return Task.FromResult(true);
        }
    }
}