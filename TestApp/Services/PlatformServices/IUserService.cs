using TestApp.Models;

namespace TestApp.Services.PlatformServices
{
    public interface IUserService
    {
        User CurrentUser { get; set; }
    }
}