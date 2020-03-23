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
			set { _selectcountrie = value; }
		}


		public ICommand ReloadCommand =>
			_reloadCommand ??
			(_reloadCommand = new Command(async () => await LoadDataAsync().ConfigureAwait(true)));

		
		public CountriesViewModel()
		{
			_servicesCovid19 = new ServicesCovid19();

			_ = LoadDataAsync();
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
