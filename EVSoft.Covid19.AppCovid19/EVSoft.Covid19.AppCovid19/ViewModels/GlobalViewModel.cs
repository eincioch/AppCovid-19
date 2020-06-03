using EVSoft.Covid19.Backend.Dominio;
using EVSoft.Covid19.Backend.Services;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EVSoft.Covid19.AppCovid19.ViewModels
{
    public class GlobalViewModel : BaseViewModel
    {
        private readonly IServicesCovid19 _servicesCovid19;
        private All _all;

        public All All
        {
            get { return _all; }
            set
            {
                _all = value;
                OnPropertyChanged();
            }
        }

        private string _fecha;

        public string fecha
        {
            get { return _fecha; }
            set
            {
                _fecha = value;
                OnPropertyChanged();
            }
        }


        public Command LoadItemsCommand { get; set; }

        public GlobalViewModel()
        {
            _servicesCovid19 = new ServicesCovid19();
            All = new All();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand().ConfigureAwait(true));

        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {

                All = await _servicesCovid19.GetAllAsync().ConfigureAwait(true);
                System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                dtDateTime = dtDateTime.AddMilliseconds(All.get_Update()).ToLocalTime();

                //DateTime dt = new DateTime(All.updated);
                fecha = dtDateTime.ToString();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
