using TestApp.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(LoginService))]
namespace TestApp.iOS
{
    internal class LoginService : ILoginService
    {
        public bool Authenticate()
        {

            return true;
        }
    }
}