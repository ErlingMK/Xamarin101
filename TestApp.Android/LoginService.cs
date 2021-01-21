using TestApp.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(LoginService))]
namespace TestApp.Droid
{
    internal class LoginService : ILoginService
    {
        public bool Authenticate()
        {
            return true;
        }
    }
}