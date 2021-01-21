using LightInject;
using TestApp.iOS.Services;
using TestApp.Services.PlatformServices;

namespace TestApp.iOS
{
    public class PlatformCompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<ILoginService, LoginService>(new PerContainerLifetime()); // Singleton, just as an example
            serviceRegistry.Register<IUserService, UserService>();
            // Register more platform specific services.
        }
    }
}