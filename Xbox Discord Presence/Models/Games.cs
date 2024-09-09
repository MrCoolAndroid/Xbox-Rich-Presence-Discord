using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xbox_Discord_Presence.Models
{
    public partial class Games
    {
        [JsonProperty("Games List")]
        public List<GamesList> GamesList { get; set; }
    }

    public partial class GamesList
    {
        [JsonProperty("Games")]
        public List<Game> Games { get; set; }
    }

    public partial class Game
    {
        [JsonProperty("titlename")]
        public string Titlename { get; set; }

        [JsonProperty("titleimage")]
        public string Titleimage { get; set; }

        [JsonProperty("titleicon", NullValueHandling = NullValueHandling.Ignore)]
        public string Titleicon { get; set; }

        [JsonProperty("titlebackground", NullValueHandling = NullValueHandling.Ignore)]
        public string Titlebackground { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public long? Type { get; set; }
    }
}
