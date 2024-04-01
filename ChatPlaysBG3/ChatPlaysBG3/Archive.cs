using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatPlaysBG3
{
    class Archive
    {
        private string client_id = "lq1tzm68ep4qvipym40apgizf45sr6";
        private string client_secret = "22i9hawqpws4s4k3q99via9vtywbr0";
        private string client_url = "http://localhost:3000/";

        private string broadcast_id = "89697687";
        private string bot_id = "1048673136";

        private string channel_name = "xzeroprimex";
        private string username = "primalchatplays";
        private string password = "Oauth:kvw8io034awi4o6333dxrlf7k363ir";
        private string access_token = "Bearer n13h88l1jlvojrwog861xe0c4b5wpd";
        private string bot_access_token = "Bearer wvftr7291h10hgccx1wzdx72gjudi1";
        private string authorization = "";

        public string ClientId { get { return client_id; } }
        public string ClientSecret {  get { return client_secret; } }
        public string ClientUrl { get { return client_url; } }
        public string BroadcastId { get { return broadcast_id; } }
        public string BotId { get { return bot_id; } }
        public string ChannelName { get { return channel_name; } }
        public string Username { get { return username; } }
        public string Password { get { return password; } }
        public string AccessToken { get { return access_token; } }
        public string BotAccessToken { get {  return bot_access_token; } }
        public string Authorization { get { return authorization; } set { authorization = value; } }
    }
}
