using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EVSoft.Covid19.AppCovid19.Services;
using EVSoft.Covid19.AppCovid19.Views;

namespace EVSoft.Covid19.AppCovid19
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
