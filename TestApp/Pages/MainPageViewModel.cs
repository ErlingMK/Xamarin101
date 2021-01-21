using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using DIPS.Xamarin.UI.Commands;
using DIPS.Xamarin.UI.Extensions;
using TestApp.Services;
using TestApp.Services.PlatformServices;
using Xamarin.Forms;

namespace TestApp.Pages
{
    public class MainPageViewModel : IMainPageViewModel
    {
        private readonly ILoginService _loginService;
        private readonly INavigationService _navigationService;
        private string _greetings;
        private string _result;

        public MainPageViewModel(ILoginService loginService, INavigationService navigationService)
        {
            _loginService = loginService;
            _navigationService = navigationService;

            Greetings = "HELLO THERE!";

            AuthenticateCommand = new AsyncCommand(Login);
            NavigateCommand = new AsyncCommand(Navigate);
        }

        private async Task Navigate()
        {
            await _navigationService.PushPage<AnotherPage, IAnotherPageViewModel>(context => context.Init());
        }

        private async Task Login()
        {
            var result = await _loginService.Authenticate();
            Result = $"Result from platform: {result}";
        }

        public IAsyncCommand AuthenticateCommand { get; }
        public IAsyncCommand NavigateCommand { get; }

        public string Greetings
        {
            get => _greetings;
            set => PropertyChanged.RaiseWhenSet(ref _greetings, value);
        }

        public string Result
        {
            get => _result;
            set => PropertyChanged.RaiseWhenSet(ref _result, value);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }



    public interface IMainPageViewModel : INotifyPropertyChanged
    {
        IAsyncCommand AuthenticateCommand { get; }
        IAsyncCommand NavigateCommand { get; }
        string Greetings { get; }
        string Result { get; }
    }
}