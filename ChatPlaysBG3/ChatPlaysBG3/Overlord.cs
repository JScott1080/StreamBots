using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Api;
using TwitchLib.Api.Auth;
using TwitchLib.Api.Core.Exceptions;
using TwitchLib.Api.Helix.Models.Bits;

namespace ChatPlaysBG3
{
    internal class Overlord
    {
        private Archive localArchive;

        public event EventHandler OnAuthRecieved;

        public Overlord(Archive archive) 
        {
            localArchive = archive;
            getAuth();
        }

        internal async void getAuth()
        {
            using var httpClient = new HttpClient();
            var tokenUrl = "https://id.twitch.tv/oauth2/token";
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("client_id", localArchive.ClientId),
                new KeyValuePair<string, string>("client_secret", localArchive.ClientSecret),
                new KeyValuePair<string, string>("grant_type", "client_credentials")
            });

            try
            {
                var responce = await httpClient.PostAsync(tokenUrl, content);

                if (responce.IsSuccessStatusCode)
                {
                    var jsonContent = await responce.Content.ReadAsStringAsync();
                    var jObject = JObject.Parse(jsonContent);
                    var auth = (string)jObject["access_token"];
                    localArchive.Authorization = $"Bearer {auth}";
                    OnAuthRecieved(this, EventArgs.Empty);
                }
                else
                {
                    Console.WriteLine($"Error: {responce.StatusCode}");
                }
            }
            catch (Exception ex) { Console.WriteLine($" Error, auth Exception: {ex.Message}"); }


        }

    }
}
