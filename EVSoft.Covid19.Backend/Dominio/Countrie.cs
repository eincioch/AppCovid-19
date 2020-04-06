using Newtonsoft.Json;

namespace EVSoft.Covid19.Backend.Dominio
{
    public class Countrie
    {
        public string country { get; set; }
        public Countryinfo countryInfo { get; set; }
        public int cases { get; set; }
        public int todayCases { get; set; }
        public int deaths { get; set; }
        public int? todayDeaths { get; set; }
        public int? recovered { get; set; }
        public int? active { get; set; }
        public int? critical { get; set; }
        public double? casesPerOneMillion { get; set; }
        public double? deathsPerOneMillion { get; set; }
        public long updated { get; set; }
    }

    public class Countryinfo
    {
        public string iso2 { get; set; }
        public string iso3 { get; set; }
        public string _id { get; set; }
        public double? lat { get; set; }
        [JsonProperty("long")]
        public double? _long { get; set; }
        public string flag { get; set; }
    }

}
