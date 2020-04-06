using EVSoft.Covid19.Backend.Dominio;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace EVSoft.Covid19.Backend.Services
{
    public class ServicesCovid19 : IServicesCovid19
    {
        public async Task<All> GetAllAsync()
        {
            try
            {
                var uri = $"{ResourceString.Covid19All}";
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpRequestMessage request = new HttpRequestMessage()
                    {
                        RequestUri = new Uri(uri),
                        Method = HttpMethod.Get
                    };

                    var response = await httpClient.SendAsync(request).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var all = JsonConvert.DeserializeObject<All>(content);
                        return all;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(@"\tError {0}", ex.Message);
                return null;
            }
        }
        public async Task<ObservableCollection<Countrie>> GetCountriesAsync()
        {
            try
            {

               var uri = $"{ResourceString.Covid19Countries}";

                
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpRequestMessage request = new HttpRequestMessage()
                    {
                        RequestUri = new Uri(uri),
                        Method = HttpMethod.Get
                    };

                    var response = await httpClient.SendAsync(request).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var countries = JsonConvert.DeserializeObject<ObservableCollection<Countrie>>(content);
                        return countries;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(@"\tError {0}", ex.Message);
                return null;
            }
        }

        public async Task<Countrie> GetCountrieAsync(string countrie) 
        {
            try
            {

                var uri = $"{ResourceString.Covid19Countries}/{countrie}";
                

                using (HttpClient httpClient = new HttpClient())
                {
                    HttpRequestMessage request = new HttpRequestMessage()
                    {
                        RequestUri = new Uri(uri),
                        Method = HttpMethod.Get
                    };

                    var response = await httpClient.SendAsync(request).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var countri = JsonConvert.DeserializeObject<Countrie>(content);
                        return countri;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(@"\tError {0}", ex.Message);
                return null;
            }
        }

        public async Task<Historical> GetHistoricalAsync(string countrie = "")
        {
            try
            {
                var uri = "";
                if (String.IsNullOrEmpty(countrie))
                {
                    uri = $"{ResourceString.Covid19Historical}";
                }
                else
                {
                    uri = $"{ResourceString.Covid19Historical}/{countrie}";
                }

                using (HttpClient httpClient = new HttpClient())
                {
                    HttpRequestMessage request = new HttpRequestMessage()
                    {
                        RequestUri = new Uri(uri),
                        Method = HttpMethod.Get
                    };

                    var response = await httpClient.SendAsync(request).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var historical = JsonConvert.DeserializeObject<Historical>(content, Converter.Settings);
                        return historical;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(@"\tError {0}", ex.Message);
                return null;
            }
        }

        //https://app.quicktype.io/
        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
                {
                    new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
                },
            };
        }
    }
}
