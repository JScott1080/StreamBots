using Newtonsoft.Json;

namespace ChatPlaysBG3
{

    public class ConfigLibrary
    {
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string client_url { get; set; }

        public string broadcast_id { get; set; }
        public string bot_id { get; set; }

        public string channelName { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string access_token { get; set; }
        public string bot_access_token { get; set; }
        public string authorization { get; set; }
        public string refresh_token { get; set; }
    }


    class Archive
    {
        private string client_id = "";
        private string client_secret = "";
        private string client_url = "";

        private string broadcast_id = "";
        private string bot_id = "";

        private string channel_name = "";
        private string username = "";
        private string password = "";
        private string access_token = "";
        private string bot_access_token = "";
        private string authorization = "";
        private string refresh_token = "";

        public Archive() { loadConfigJSON(); }

        private void loadConfigJSON()
        { 
            string file = Path.Combine(Environment.CurrentDirectory, "config.json");
            string jsonFilePath = File.ReadAllText(file);
            try
            {
                ConfigLibrary library = JsonConvert.DeserializeObject<ConfigLibrary>(jsonFilePath);

                this.client_id = library.client_id;
                this.client_secret = library.client_secret;
                this.client_url = library.client_url;

                this.broadcast_id = library.broadcast_id;
                this.bot_id = library.bot_id;

                this.channel_name = library.channelName;
                this.username = library.username;
                this.password = library.password;
                this.access_token = library.access_token;
                this.bot_access_token = library.bot_access_token;
                this.authorization = library.authorization;
                this.refresh_token = library.refresh_token;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            
        }

        public void updateConfigJSON(string key, string value)
        {

        }

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
        public string RefreshToken { get { return refresh_token; } set { refresh_token = value; } }
    }
}
