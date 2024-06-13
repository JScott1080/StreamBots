using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace ChatPlaysBG3.ChatIRC.Messages
{
    public class TwitchMessage
    {
        [JsonProperty("tags")]
        public Dictionary<string, string> Tags { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("command")]
        public Dictionary<string, string> Command { get; set; }

        [JsonProperty("parameters")]
        public string Parameters { get; set; }

    }
}
