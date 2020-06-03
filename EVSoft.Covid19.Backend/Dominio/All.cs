using Newtonsoft.Json;
using System;
using System.Runtime.CompilerServices;

namespace EVSoft.Covid19.Backend.Dominio
{
    public class All
    {

        [JsonProperty("updated")]
        public string Updated { get; set; }

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
        public double DeathsPerOneMillion { get; set; }

        [JsonProperty("tests")]
        public long Tests { get; set; }

        [JsonProperty("testsPerOneMillion")]
        public double TestsPerOneMillion { get; set; }

        [JsonProperty("population")]
        public long Population { get; set; }

        [JsonProperty("activePerOneMillion")]
        public double ActivePerOneMillion { get; set; }

        [JsonProperty("recoveredPerOneMillion")]
        public double RecoveredPerOneMillion { get; set; }

        public double get_Update()
        {
            return Convert.ToDouble(Updated);
        }

        [JsonProperty("criticalPerOneMillion")]
        public double CriticalPerOneMillion { get; set; }

        [JsonProperty("affectedCountries")]
        public long AffectedCountries { get; set; }

        //public long updated { get; set; }
        //public int cases { get; set; }
        //public int todayCases { get; set; }
        //public double? casesPerOneMillion { get; set; }
        //public int deaths { get; set; }
        //public int todayDeaths { get; set; }
        //public double? deathsPerOneMillion { get; set; }
        //public int recovered { get; set; }
        //public int active { get; set; }
        //public int  critical{ get; set; }
        //public int affectedCountries { get; set; }
        //public int tests { get; set; }
        //public double? testsPerOneMillion { get; set; }

    }
}
