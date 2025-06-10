using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xbox_Discord_Presence.Models
{
    public class Settings
    {
        [JsonProperty("Gamertag", NullValueHandling = NullValueHandling.Ignore)]
        public string Gamertag { get; set; }

        [JsonProperty("OXBL_API", NullValueHandling = NullValueHandling.Ignore)]
        public string OXBLAPI { get; set; }
        [JsonProperty("OfflineLookup", NullValueHandling = NullValueHandling.Ignore)]
        public bool OfflineLookup { get; set; }

        [JsonProperty("RateLimit", NullValueHandling = NullValueHandling.Ignore)]
        public bool RateLimit { get; set; }

        [JsonProperty("Language", NullValueHandling = NullValueHandling.Ignore)]
        public string Language { get; set; }

        [JsonProperty("Device", NullValueHandling = NullValueHandling.Ignore)]
        public string? Device { get; set; }

        [JsonProperty("IconMethod", NullValueHandling = NullValueHandling.Ignore)]
        public long? IconMethod { get; set; }

        [JsonProperty("SGDB_API", NullValueHandling = NullValueHandling.Ignore)]
        public string SGDBAPI { get; set; }

        [JsonProperty("QuietMode", NullValueHandling = NullValueHandling.Ignore)]
        public bool QuietMode { get; set; }
    }
}
