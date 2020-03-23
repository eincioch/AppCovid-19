using CommonServiceLocator;
using EVSoft.Covid19.AppCovid19.Services;
using EVSoft.Covid19.Backend.Services;
using Unity;
using Unity.ServiceLocation;
using Xamarin.Forms;

namespace EVSoft.Covid19.AppCovid19
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();

            //Register Interface
            UnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterType<IServicesCovid19, ServicesCovid19>();


            UnityServiceLocator unityServiceLocator = new UnityServiceLocator(unityContainer);
            ServiceLocator.SetLocatorProvider(() => unityServiceLocator);

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
