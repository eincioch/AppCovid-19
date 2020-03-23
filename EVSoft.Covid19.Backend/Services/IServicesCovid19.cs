using EVSoft.Covid19.Backend.Dominio;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace EVSoft.Covid19.Backend.Services
{
    public interface IServicesCovid19
    {
        Task<All> GetAllAsync();
        Task<ObservableCollection<Countrie>> GetCountrieAsync(string countrie = "");
    }
}
