using EVSoft.Covid19.Backend.Dominio;
using System;
using System.Collections.Generic;
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

        public INavigation Navigation { get; set; }

        public CountrieDetailViewModel(Countrie countrie, INavigation navigation)
        {
            Navigation = navigation;

            titleCountrie = $"Countrie {countrie.country}";
            Countrie = countrie;

        }

    }
}
