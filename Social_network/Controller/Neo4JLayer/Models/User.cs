using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Social_network.Neo4JLayer.Models
{
    class User
    {
        [JsonProperty(PropertyName = "<id>")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
    }
}
