using EVSoft.Covid19.Backend.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EVSoft.Covid19.Backend.Services
{
    public interface IServicesCovid19
    {
        Task<All> GetAllAsync();
    }
}
