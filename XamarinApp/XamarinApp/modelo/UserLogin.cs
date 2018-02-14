using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinApp.modelo
{
    public class UserLogin
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("Correo")]
        public string Correo { get; set; }
        [JsonProperty("Pass")]
        public string Pass { get; set; }
        [JsonProperty("Nombre")]
        public string Nombre { get; set; }
    }
}
