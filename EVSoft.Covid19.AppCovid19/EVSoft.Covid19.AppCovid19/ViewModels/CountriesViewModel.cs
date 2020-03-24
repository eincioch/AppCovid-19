using EVSoft.Covid19.Backend.Dominio;
using EVSoft.Covid19.Backend.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EVSoft.Covid19.AppCovid19.ViewModels
{
    public class CountriesViewModel : BaseViewModel
    {
		private readonly IServicesCovid19 _servicesCovid19;
		private ICommand _reloadCommand;
		public INavigation Navigation { get; set; }

		private ObservableCollection<Countrie> _countries;

		public ObservableCollection<Countrie> Countries
		{
			get { return _countries; }
			set { _countries = value;
				OnPropertyChanged();
			}
		}

		private Countrie _selectcountrie;

		public Countrie SelectCountrie
		{
			get { return _selectcountrie; }
			set { _selectcountrie = value;
				OnPropertyChanged();
			}
		}


		public ICommand ReloadCommand =>
			_reloadCommand ??
			(_reloadCommand = new Command(async () => await LoadDataAsync().ConfigureAwait(true)));


		private Command _navigateCommand; 
		public Command CommandDetail { get { return _navigateCommand; } set { _navigateCommand = value; OnPropertyChanged(); } }

		public CountriesViewModel(INavigation navigation)
		{
			Navigation = navigation;

			_servicesCovid19 = new ServicesCovid19();

			CommandDetail = new Command<Countrie>(async (model) => await ViewDetail(model).ConfigureAwait(true));

			_ = LoadDataAsync();

			
		}

		async Task ViewDetail(Countrie countrie)
		{
			await Navigation.PushAsync(new Views.CountrieDetailPage(new CountrieDetailViewModel(countrie, Navigation))).ConfigureAwait(true);
			//await Application.Current.MainPage.DisplayAlert("Tapped", countrie.country, "OK").ConfigureAwait(true);
		}

		async Task LoadDataAsync()
		{
			try
			{
				IsBusy = true;

				Countries = await _servicesCovid19.GetCountrieAsync().ConfigureAwait(true);

			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}
