using EVSoft.Covid19.Backend.Dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace EVSoft.Covid19.AppCovid19.ViewModels
{
    public class CountrieDetailViewModel : BaseViewModel
    {
        private Countrie _countrie;

        private string _titleCountrie;

        public string titleCountrie
        {
            get { return _titleCountrie; }
            set { _titleCountrie = value;
                OnPropertyChanged();
            }
        }

        public Countrie Countrie
        {
            get { return _countrie; }
            set { _countrie = value;
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
        public INavigation Navigation { get; set; }

        public CountrieDetailViewModel(Countrie countrie, INavigation navigation)
        {
            try
            {
                IsBusy = true;
                Navigation = navigation;

                titleCountrie = $"Countrie {countrie.Country}";

                System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                dtDateTime = dtDateTime.AddMilliseconds(countrie.get_Update()).ToLocalTime();

                //DateTime dt = new DateTime(All.updated);
                fecha = dtDateTime.ToString();

                Countrie = countrie;


            }
            catch (Exception ex)
            {

                Debug.WriteLine(@"\tError {0}", ex.Message);
            }
            finally {
                IsBusy = false;
            }

        }

    }
}
