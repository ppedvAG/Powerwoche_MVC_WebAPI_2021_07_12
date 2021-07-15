using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_WebAPI.Models
{
    public class LocalizationRecord
    {
        [JsonIgnore]
        public long? Id { get; set; }

        [JsonProperty(PropertyName = "CustomKeyName")]
        public string Key { get; set; }

        public string Text { get; set; }

        public string LocalizationCulture { get; set; }

        public string ResourceKey { get; set; }
        public string ResourceValue { get;  set; }
    }
}
