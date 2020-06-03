using Newtonsoft.Json;
using System;

namespace EVSoft.Covid19.Backend.Dominio
{
    public class Countrie
    {
        [JsonProperty("updated")]
        public long Updated { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("countryInfo")]
        public CountryInfo CountryInfo { get; set; }

        [JsonProperty("cases")]
        public long Cases { get; set; }

        [JsonProperty("todayCases")]
        public long TodayCases { get; set; }

        [JsonProperty("deaths")]
        public long Deaths { get; set; }

        [JsonProperty("todayDeaths")]
        public long TodayDeaths { get; set; }

        [JsonProperty("recovered")]
        public long Recovered { get; set; }

        [JsonProperty("todayRecovered")]
        public long TodayRecovered { get; set; }

        [JsonProperty("active")]
        public long Active { get; set; }

        [JsonProperty("critical")]
        public long Critical { get; set; }

        [JsonProperty("casesPerOneMillion")]
        public long CasesPerOneMillion { get; set; }

        [JsonProperty("deathsPerOneMillion")]
        public long DeathsPerOneMillion { get; set; }

        [JsonProperty("tests")]
        public long Tests { get; set; }

        [JsonProperty("testsPerOneMillion")]
        public long TestsPerOneMillion { get; set; }

        [JsonProperty("population")]
        public long Population { get; set; }

        [JsonProperty("continent")]
        public string Continent { get; set; }

        [JsonProperty("oneCasePerPeople")]
        public long OneCasePerPeople { get; set; }

        [JsonProperty("oneDeathPerPeople")]
        public long OneDeathPerPeople { get; set; }

        [JsonProperty("oneTestPerPeople")]
        public long OneTestPerPeople { get; set; }

        [JsonProperty("activePerOneMillion")]
        public double ActivePerOneMillion { get; set; }

        [JsonProperty("recoveredPerOneMillion")]
        public double RecoveredPerOneMillion { get; set; }

        [JsonProperty("criticalPerOneMillion")]
        public double CriticalPerOneMillion { get; set; }

        public double get_Update()
        {
            return Convert.ToDouble(Updated);
        }

    }

    public class CountryInfo
    {
        //[JsonProperty("_id")]
        //public string Id { get; set; }

        [JsonProperty("iso2")]
        public string Iso2 { get; set; }

        [JsonProperty("iso3")]
        public string Iso3 { get; set; }

        [JsonProperty("lat")]
        public long Lat { get; set; }

        [JsonProperty("long")]
        public long Long { get; set; }

        [JsonProperty("flag")]
        public string Flag { get; set; }

    }

}
