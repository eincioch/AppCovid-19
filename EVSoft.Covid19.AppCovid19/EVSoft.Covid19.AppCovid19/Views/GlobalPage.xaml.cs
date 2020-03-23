using EVSoft.Covid19.AppCovid19.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EVSoft.Covid19.AppCovid19.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GlobalPage : ContentPage
    {
        GlobalViewModel viewModel;

        public GlobalPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new GlobalViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.All != null)
                viewModel.IsBusy = true;
        }
    }
}