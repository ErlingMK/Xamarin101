using System.Threading.Tasks;

namespace TestApp.Services.PlatformServices
{
    public interface ILoginService
    {
        Task<bool> Authenticate();
    }
}