using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvas.Clients.Models
{
    public class UserProfile
    {
        [JsonProperty(PropertyName = "primary_email")]
        public string PrimaryEmail { get; set; }

        [JsonProperty(PropertyName = "avatar_url")]
        public string AvatarUrl { get; set; }
    }
}
