using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xbox_Discord_Presence.Models
{
    public partial class SearchAccount
    {
        [JsonProperty("content")]
        public Content Content { get; set; }

        [JsonProperty("code")]
        public long Code { get; set; }
    }

    public partial class Content
    {
        [JsonProperty("profileUsers")]
        public ProfileUser[] ProfileUsers { get; set; }
    }

    public partial class ProfileUser
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("hostId")]
        public string HostId { get; set; }

        [JsonProperty("settings")]
        public Setting[] Settings { get; set; }

        [JsonProperty("isSponsoredUser")]
        public bool IsSponsoredUser { get; set; }
    }

    public partial class Setting
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
