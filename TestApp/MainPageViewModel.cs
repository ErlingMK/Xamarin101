using System.ComponentModel;
using System.Windows.Input;
using DIPS.Xamarin.UI.Extensions;
using Xamarin.Forms;

namespace TestApp
{
    public class MainPageViewModel : IMainPageViewModel
    {
        private readonly ILoginService _loginService;
        private string _someText;
        private string _input;

        public MainPageViewModel(ILoginService loginService)
        {
            _loginService = loginService;
            SomeText = "HEo";
            LoginCommand = new Command(Login);
        }

        private void Login()
        {
            _loginService.Authenticate();
        }

        public string SomeText
        {
            get => _someText;
            set => PropertyChanged.RaiseWhenSet(ref _someText, value);
        }

        public string Input
        {
            get => _input;
            set => PropertyChanged.RaiseWhenSet(ref _input, value);
        }

        public ICommand LoginCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }



    public interface IMainPageViewModel : INotifyPropertyChanged
    {
        string SomeText { get; set; }
        string Input { get; set; }
        ICommand LoginCommand { get; }
    }
}