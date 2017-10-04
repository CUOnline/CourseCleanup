using Canvas.Clients.Models.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvas.Clients.Models
{
    public class Role
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "role")]
        [JsonConverter(typeof(RoleNamesConverter))]
        public RoleNames Name { get; set; }

        [JsonProperty(PropertyName = "role_id")]
        public string RoleId { get; set; }

        [JsonProperty(PropertyName = "workflow_state")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WorkflowState WorkflowState { get; set; }
    }
}
