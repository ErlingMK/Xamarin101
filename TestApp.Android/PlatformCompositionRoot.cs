using LightInject;
using TestApp.Services.PlatformServices;

namespace TestApp.Droid
{
    internal class PlatformCompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<ILoginService, LoginService>();
        }
    }
}