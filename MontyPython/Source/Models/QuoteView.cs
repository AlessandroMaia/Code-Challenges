using System;
using Newtonsoft.Json;

namespace Source.Models
{
    public class QuoteView
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("actor")]
        public string Actor { get; set; }

        [JsonProperty("quote")]
        public string Detail { get; set; }

    }
}
