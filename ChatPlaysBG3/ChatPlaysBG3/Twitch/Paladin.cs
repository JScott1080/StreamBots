using Newtonsoft.Json;
using System.Text;


namespace ChatPlaysBG3.TwitchAPI
{

    internal class Paladin
    {
        Archive localArchive;

        public Paladin(Archive archive)
        {
            this.localArchive = archive;
        }

        public async void DeclareArival()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", localArchive.BotAccessToken);
                httpClient.DefaultRequestHeaders.Add("Client-Id", localArchive.ClientId);

                var announcment = new {
                    broadcaster_id = localArchive.BroadcastId,
                    moderator_id = localArchive.BotId,
                    message = "ChatPlays bot is live, remember to read the rules!",
                    color = "purple"
                };

                string jsonPayload = JsonConvert.SerializeObject(announcment);

                Console.WriteLine(jsonPayload);

                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                var responce = await httpClient.PostAsync($"https://api.twitch.tv/helix/chat/announcements", content);

                if (responce.IsSuccessStatusCode)
                {
                    Console.WriteLine("Announcment Sent");
                }
                else
                {
                    Console.WriteLine($"Error sending message: {responce.StatusCode}");
                }
            }

        }
    }
}
