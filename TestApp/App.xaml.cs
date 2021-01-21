using System;
using LightInject;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var serviceContainer = new ServiceContainer();
            serviceContainer.RegisterFrom<CompositionRoot>();

            MainPage = new MainPage()
            {
                BindingContext = serviceContainer.GetInstance<IMainPageViewModel>()
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }

    public class CompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IMainPageViewModel, MainPageViewModel>();
            serviceRegistry.Register(factory => DependencyService.Get<ILoginService>());
        }
    }
}
