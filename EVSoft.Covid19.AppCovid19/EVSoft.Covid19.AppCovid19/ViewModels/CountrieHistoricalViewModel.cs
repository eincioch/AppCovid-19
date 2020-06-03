using EVSoft.Covid19.Backend.Dominio;
using EVSoft.Covid19.Backend.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EVSoft.Covid19.AppCovid19.ViewModels
{
    public class CountrieHistoricalViewModel : BaseViewModel
    {
        private readonly IServicesCovid19 _servicesCovid19;

        private Historical _historicals;
        public INavigation Navigation { get; set; }

        public Historical Historicals
        {
            get { return _historicals; }
            set { _historicals = value;
                OnPropertyChanged();
            }
        }

        private Countrie _countrie;

        public Countrie Countrie
        {
            get { return _countrie; }
            set { _countrie = value;
                OnPropertyChanged();
            }
        }


        public CountrieHistoricalViewModel(Countrie countrie, INavigation navigation)
        {
            Navigation = navigation;

            _servicesCovid19 = new ServicesCovid19();

            _ = LoadDataAsync(countrie);
        }

        async Task LoadDataAsync(Countrie countrie)
        {
            Countrie = countrie;
            Historicals = await _servicesCovid19.GetHistoricalAsync(countrie.Country).ConfigureAwait(true);
        }
    }
}
