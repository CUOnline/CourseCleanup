using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvas.Clients.Models
{
    public class Account
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "parent_account_id")]
        public string ParentAccountId { get; set; }

        [JsonProperty(PropertyName = "root_account_id")]
        public string RootAccountId { get; set; }

        [JsonProperty(PropertyName = "uuid")]
        public string Uuid { get; set; }

        [JsonProperty(PropertyName = "sis_account_id")]
        public string SisAccountId { get; set; }
    }
}
