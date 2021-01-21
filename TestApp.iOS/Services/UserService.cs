using TestApp.Models;
using TestApp.Services.PlatformServices;

namespace TestApp.iOS.Services
{
    internal class UserService : IUserService
    {
        public User CurrentUser { get; set; }
    }
}