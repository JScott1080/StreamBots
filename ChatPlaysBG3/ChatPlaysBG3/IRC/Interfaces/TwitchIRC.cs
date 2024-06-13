using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChatPlaysBG3.ChatIRC.Interfaces
{
    class TwitchIRC
    {
        private string _userName;
        private string _channel;
        private TcpClient tcpClient;
        public StreamReader reader;
        private StreamWriter writer;

        public TwitchIRC(string userName, string password, string channel)
        {

            Console.WriteLine("Starting IRC Connection");
            _userName = userName;
            _channel = channel;

            tcpClient = new TcpClient("irc.chat.twitch.tv", 6667);

            NetworkStream networkStream = tcpClient.GetStream();
            reader = new StreamReader(networkStream);
            writer = new StreamWriter(networkStream);

            writer.WriteLine($"PASS {password}");
            writer.WriteLine($"NICK {_userName}");
            writer.Flush();


        }

        public void JoinChannel()
        {

            writer.WriteLine($"JOIN #{_channel}");
            writer.Flush();
        }


        public string ReadMessage()
        {
            string incomingMessage = reader.ReadLine();
            if ( incomingMessage != null )
                return incomingMessage;
            return "";
        }

        public void pong()
        {
            Console.WriteLine("Returning Ping with Pong");
            writer.WriteLine("PONG :irc.twitch.tv");
            writer.Flush();
        }

        public void SendPing()
        {
            Console.WriteLine("Sending ping to keep connection");
            writer.WriteLine("PING :irc.twitch.tv");
            writer.Flush();
        }

    }


    class TwitchPing
    {
        private Thread pingSender;
        private TwitchIRC ircClient;

        public TwitchPing(TwitchIRC client)
        {
            ircClient = client;
            pingSender = new Thread(new ThreadStart(Run));
        }

        public void startPing()
        {
            pingSender.IsBackground = true;
            pingSender.Start();
        }

        public void Run()
        {
            while (true)
            {
                ircClient.SendPing();
                Thread.Sleep(30000);
            }
        }


    }
}

