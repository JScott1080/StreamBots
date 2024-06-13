using ChatPlaysBG3;
using ChatPlaysBG3.ChatIRC;
using ChatPlaysBG3.GameMaster;
using ChatPlaysBG3.TwitchAPI;


class ChatPlays_BG3
{


    static void Main(string[] args)
    {
        var mindFlayer = new MindFlayer();
    }
}

class MindFlayer
{

    public Guardian guardian;
    public Commander commander;
    public Overlord overlord;
    public Paladin paladin;
    public Archive archive;

    public MindFlayer()
    {
        Console.WriteLine("Initializing Guardian and subscribing to Event Dispatchers");
        guardian = new Guardian();
        guardian.DisableChatPlays += diableChatPlaysCommands;
        guardian.EnableChatPlays += enableChatPlaysCommands;

        Console.WriteLine("Getting the Archive for stream information");
        archive = new Archive();

        Console.WriteLine("Connecting to Twitch via Overlord");
        overlord = new Overlord(archive);
        overlord.OnAuthRecieved += verifyOauth;
       

        Console.WriteLine("Waking the Paladin for Moderation and Admin");
        paladin = new Paladin(archive);

        Console.WriteLine("Getting Commander for Twitch chat IRC");
        commander = new Commander(archive);

        Thread.Sleep(3000);
        Console.WriteLine("Lets PLay!!!");
        letsPlay();
    }

    private void verifyOauth(object? sender, EventArgs e)
    {
    }

    public void letsPlay()
    {
        guardian.guardianInit();
        paladin.DeclareArival();
    }

    void enableChatPlaysCommands(object? sender, EventArgs e)
    {

        Console.WriteLine("Enableing ChatPlays commands");
    }

    void diableChatPlaysCommands(object? sender, EventArgs e)
    {
        Console.WriteLine("Disableing ChatPlays commands");
    }

    

    private static async Task QuestLine()
    {
        var alive = true;
        while (alive)
        {
            await Task.Delay(1000);
        }
    }
}