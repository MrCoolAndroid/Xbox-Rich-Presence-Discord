using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xbox_Discord_Presence.Models
{
    public partial class Presence
    {
        [JsonProperty("content")]
        public Content Content { get; set; }

        [JsonProperty("code")]
        public long Code { get; set; }
    }

    public partial class Content
    {
        [JsonProperty("xuid")]
        public string Xuid { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("devices")]
        public Device[] Devices { get; set; }
    }

    public partial class Device
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("titles")]
        public Title[] Titles { get; set; }
    }

    public partial class Title
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("activity")]
        public Activity Activity { get; set; }
    }

    public partial class Activity
    {
        [JsonProperty("richPresence")]
        public string RichPresence { get; set; }
    }
}
