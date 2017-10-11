using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvas.Clients.Models
{
    public class User : BaseModel
    {
        [JsonProperty(PropertyName = "sortable_name")]
        public string SortableName { get; set; }
        
        [JsonProperty(PropertyName = "short_name")]
        public string ShortName { get; set; }

        [JsonProperty(PropertyName = "sis_user_id")]
        public string SisUserId { get; set; }

        [JsonProperty(PropertyName = "integration_id")]
        public string IntegrationId { get; set; }

        [JsonProperty(PropertyName = "sis_login_id")]
        public string SisLoginId { get; set; }

        [JsonProperty(PropertyName = "sis_import_id")]
        public string SisImportId { get; set; }

        [JsonProperty(PropertyName = "root_account")]
        public string RootAccount { get; set; }

        [JsonProperty(PropertyName = "login_id")]
        public string LoginId { get; set; }
    }
}
