using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xbox_Discord_Presence.Models
{
    public partial class Ignore
    {
        [JsonProperty("Ignore List")]
        public List<IgnoreList> IgnoreList { get; set; }
    }

    public partial class IgnoreList
    {
        [JsonProperty("titlename")]
        public string Titlename { get; set; }

        [JsonProperty("ignore")]
        public List<string> Ignore { get; set; }
    }
}
