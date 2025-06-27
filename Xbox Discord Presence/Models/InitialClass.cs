using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xbox_Discord_Presence.Models
{
    public class InitialClass
    {
        public string Gamertag { get; set; }
        public string APIKey { get; set; }
        public string SteamGridDBKey { get; set; }
        public bool IsLimitedTo150 { get; set; }
        public bool IsUsingSteamGridDB { get; set; }
        public bool IsUsingImagesAPI { get; set; }
        public string Language { get; set; }
        public long Device { get; set; }
        public string additionalAPIKey { get; set; }
    }
}
