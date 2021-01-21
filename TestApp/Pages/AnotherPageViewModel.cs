using System.ComponentModel;

namespace TestApp.Pages
{
    public class AnotherPageViewModel : IAnotherPageViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void Init()
        {
            //do something maybe
        }
    }

    internal interface IAnotherPageViewModel : INotifyPropertyChanged
    {
        void Init();
    }
}
