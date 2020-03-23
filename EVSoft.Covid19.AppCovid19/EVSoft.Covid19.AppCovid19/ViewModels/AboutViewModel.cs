using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace EVSoft.Covid19.AppCovid19.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "Acerca";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("http://evsoftconsultores.com"));
        }

        public ICommand OpenWebCommand { get; }
    }
}