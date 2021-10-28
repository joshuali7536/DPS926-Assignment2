using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFXIVMountTracker
{
    public class SourceClass
    {
        /*[JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("related_type")]
        public string RelatedType { get; set; }

        [JsonProperty("related_id")]
        public int RelatedId { get; set; }*/

        public string type { get; set; }
        public string text { get; set; }
        public string related_type { get; set; }
        public int? related_id { get; set; }
    }
}