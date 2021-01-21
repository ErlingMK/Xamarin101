using LightInject;
using TestApp.Pages;
using TestApp.Services;
using Xamarin.Forms;

namespace TestApp
{
    public class SharedCompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            RegisterPages(serviceRegistry);
            RegisterViewModels(serviceRegistry);
            RegisterServices(serviceRegistry);
        }

        private static void RegisterServices(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<INavigationService>(factory => new NavigationService(factory.GetInstance<IServiceContainer>()), new PerContainerLifetime());

            //for services that doesn't need to be platform specific.
        }

        private static void RegisterViewModels(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IMainPageViewModel, MainPageViewModel>();
            serviceRegistry.Register<IAnotherPageViewModel, AnotherPageViewModel>();
        }

        private static void RegisterPages(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register(factory => new NavigationPage(factory.GetInstance<MainPage>()));
            serviceRegistry.Register(factory => new MainPage
            {
                BindingContext = factory.GetInstance<IMainPageViewModel>()
            });

            serviceRegistry.Register(factory => new AnotherPage
            {
                BindingContext = factory.GetInstance<IAnotherPageViewModel>()
            });
        }
    }
}