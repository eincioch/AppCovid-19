using EVSoft.Covid19.Backend.Dominio;
using EVSoft.Covid19.Backend.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

		private Countrie _countrie;

		public Countrie Countrie
		{
			get { return _countrie; }
			set { _countrie = value;
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

		public ICommand PerformSearch => new Command<string>(async (string query) =>
		{
			try
			{
				if (string.IsNullOrWhiteSpace(query)) {
					_ = LoadDataAsync();
				} else
				{
					Countrie = await _servicesCovid19.GetCountrieAsync(query).ConfigureAwait(true);
					if(Countrie != null)
					{
						Countries = new ObservableCollection<Countrie>() { new Countrie() { country=Countrie.country,
																							countryInfo = new Countryinfo(){  flag = Countrie.countryInfo.flag},
																							cases =Countrie.cases,
																							todayCases =Countrie.todayCases,
																							deaths=Countrie.deaths,
																							todayDeaths=Countrie.todayDeaths ,
																							recovered=Countrie.recovered ,
																							active =Countrie.active,
																							critical=Countrie.critical,
																							casesPerOneMillion=Countrie.casesPerOneMillion,
																							deathsPerOneMillion=Countrie.deathsPerOneMillion ,
																							updated=Countrie.updated
																							} };
					}
					else
					{
						await Application.Current.MainPage.DisplayAlert("😟 Mensaje", "No se encontro información. Verifique!", "Aceptar").ConfigureAwait(true);
					}
					
				}
				
			}
			catch (Exception ex)
			{
				throw ex;
			}

		});

		public ICommand ReloadCommand =>
			_reloadCommand ??
			(_reloadCommand = new Command(async () => await LoadDataAsync().ConfigureAwait(true)));


		private Command _navigateCommand;
		private Command _navigateCommand2;
		public Command CommandDetail { get { return _navigateCommand; } set { _navigateCommand = value; OnPropertyChanged(); } }

		public Command CommandHistorical { get { return _navigateCommand2; } set { _navigateCommand2 = value; OnPropertyChanged(); } }

		public CountriesViewModel(INavigation navigation)
		{

			try
			{
				IsBusy = true;
				Navigation = navigation;

				_servicesCovid19 = new ServicesCovid19();

				CommandDetail = new Command<Countrie>(async (model) => await ViewDetail(model).ConfigureAwait(true));

				CommandHistorical = new Command<Countrie>(async (model) => await ViewHistorical(model).ConfigureAwait(true));

				_ = LoadDataAsync();
			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				IsBusy = false;
			}

		}

		async Task ViewHistorical(Countrie countrie)
		{
			await Navigation.PushAsync(new Views.CountrieHistoricalPage(new CountrieHistoricalViewModel(countrie, Navigation))).ConfigureAwait(true);
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
				
				Countries = await _servicesCovid19.GetCountriesAsync().ConfigureAwait(true);
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
