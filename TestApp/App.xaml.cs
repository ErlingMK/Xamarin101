using System;
using LightInject;
using TestApp.Pages;
using TestApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp
{
    public partial class App : Application
    {
        public IServiceContainer ServiceContainer { get; }

        public App(IServiceContainer serviceContainer)
        {
            ServiceContainer = serviceContainer;

            InitializeComponent();
            var navigationPage = ServiceContainer.GetInstance<NavigationPage>();
            ServiceContainer.GetInstance<INavigationService>().Navigation = navigationPage.Navigation;
            MainPage = navigationPage;
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
}
