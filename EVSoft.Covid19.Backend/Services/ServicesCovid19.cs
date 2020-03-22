﻿using EVSoft.Covid19.Backend.Dominio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
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
    }
}
