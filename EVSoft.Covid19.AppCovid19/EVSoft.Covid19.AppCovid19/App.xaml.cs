using CommonServiceLocator;
using EVSoft.Covid19.AppCovid19.Services;
using EVSoft.Covid19.Backend.Services;
using Unity;
using Unity.ServiceLocation;
using Xamarin.Forms;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Push;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

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

        protected override async void OnStart()
        {
            // Handle when your app starts
            //Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;

            // This should come before AppCenter.Start() is called
            // Avoid duplicate event registration:
            if (!AppCenter.Configured)
            {
                Push.PushNotificationReceived += (sender, e) =>
                {
                    // Add the notification message and title to the message
                    var summary = $"Push notification received:" +
                                        $"\n\tNotification title: {e.Title}" +
                                        $"\n\tMessage: {e.Message}";

                    // If there is custom data associated with the notification,
                    // print the entries
                    if (e.CustomData != null)
                    {
                        summary += "\n\tCustom data:\n";
                        foreach (var key in e.CustomData.Keys)
                        {
                            summary += $"\t\t{key} : {e.CustomData[key]}\n";
                        }
                    }

                    // Send the notification summary to debug output
                    System.Diagnostics.Debug.WriteLine(summary);
                };
            }

            /* cuenta EV
             * AppCenter.Start("android=6a447223-8111-4af9-ae59-25d2a256ddab;" +
                  "uwp={Your UWP App secret here};" +
                  "ios={Your iOS App secret here}",
                  typeof(Analytics), typeof(Crashes), typeof(Push));*/

            AppCenter.Start("android=584f5ff0-2b90-493e-a068-17bd66165672;" +
                  "uwp={Your UWP App secret here};" +
                  "ios={Your iOS App secret here}",
                  typeof(Analytics), typeof(Crashes), typeof(Push));

            //Identificar instalaciones
            System.Guid? installId = await AppCenter.GetInstallIdAsync().ConfigureAwait(true);
            //await SecureStorage.SetAsync("IdDeviceKey", installId.ToString()).ConfigureAwait(true);

            AppCenter.SetUserId(installId.ToString());

            //Compruebe si App Center está habilitado
            bool enabled = await AppCenter.IsEnabledAsync().ConfigureAwait(true);
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
