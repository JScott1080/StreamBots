using ChatPlaysBG3;
using System;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading;


class ChatPlays_BG3
{
    static void Main(string[] args)
    {
        var mindFlayer = new MindFlayer();
    }
}

class MindFlayer
{

    private Guardian guardian;
    private Commander commander;
    private Overlord overlord;
    private Paladin paladin;
    private Archive archive;
    private String auth;

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


        Console.WriteLine("Waking Paladin for Moderation and Admin");
        paladin = new Paladin();

        Console.WriteLine("Getting Commander for Twitch chat IRC");
        commander = new Commander(archive);


        letsPlay();
    }

    private void verifyOauth(object? sender, EventArgs e)
    {
        Console.WriteLine(archive.Authorization);
    }

    public void letsPlay()
    {
        guardian.guardianInit();

    }

    void enableChatPlaysCommands(object? sender, EventArgs e)
    {

        Console.WriteLine("Enableing ChatPlays commands");
    }

    void diableChatPlaysCommands(object? sender, EventArgs e)
    {
        Console.WriteLine("Disableing ChatPlays commands");
    }

    
}