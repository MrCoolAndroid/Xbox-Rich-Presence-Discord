using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xbox_Discord_Presence.Models
{
    public partial class GameInfo
    {
        [JsonProperty("content")]
        public Content Content { get; set; }
    }

    public partial class Content
    {
        [JsonProperty("Products")]
        public Product[] Products { get; set; }
    }

    public partial class Product
    {
        [JsonProperty("ProductFamily")]
        public string ProductFamily { get; set; }

        [JsonProperty("LocalizedProperties")]
        public ProductLocalizedProperty[] LocalizedProperties { get; set; }
    }

    public partial class ProductLocalizedProperty
    {
        [JsonProperty("ProductTitle")]
        public string ProductTitle { get; set; }

        [JsonProperty("PublisherWebsiteUri")]
        public string PublisherWebsiteUri { get; set; }

        [JsonProperty("Images")]
        public Image[] Images { get; set; }
    }

    public partial class Image
    {
        [JsonProperty("Height")]
        public long Height { get; set; }

        [JsonProperty("Width")]
        public long Width { get; set; }

        [JsonProperty("ImagePurpose")]
        public string ImagePurpose { get; set; }

        [JsonProperty("Uri")]
        public string Uri { get; set; }
    }
}
