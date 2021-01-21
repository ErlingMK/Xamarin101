using System;
using System.Threading.Tasks;
using LightInject;
using Xamarin.Forms;

namespace TestApp.Services
{
    internal class NavigationService : INavigationService
    {
        private readonly IServiceContainer _container;

        public NavigationService(IServiceContainer container)
        {
            _container = container;
        }

        public INavigation Navigation { get; set; }

        public async Task PushPage<TPage, T>(Action<T> beforeNavigation = null) where TPage : Page
        {
            var page = _container.GetInstance<TPage>();
            if (page.BindingContext is T context) beforeNavigation?.Invoke(context);
            await Navigation.PushAsync(page);
        }
    }

    public interface INavigationService
    {
        Task PushPage<TPage, T>(Action<T> beforeNavigation = null) where TPage : Page;
        INavigation Navigation { get; set; }

    }
}