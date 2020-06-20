using Newtonsoft.Json;

namespace WebApp.Models
{
    public class InfuraRequest
    {
        [JsonProperty("jsonrpc")]
        public string JsonRPC { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("params")]
        public object[] Params { get; set; }
    }
}
