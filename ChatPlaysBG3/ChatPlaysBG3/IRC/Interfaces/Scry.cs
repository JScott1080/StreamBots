using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatPlaysBG3.ChatIRC.Interfaces;
using ChatPlaysBG3.ChatIRC.Messages;
using ChatPlaysBG3.GameMaster;
using ChatPlaysBG3.GameMaster.InputDevices;
using ChatPlaysBG3.IRC;
using ChatPlaysBG3.IRC.Events;

namespace ChatPlaysBG3.IRC.Interfaces
{
    internal class Scry
    {
        private Thread messageReader;
        private TwitchIRC ircClient;
        //Parcer for messages
        MessageParcer messageParcer;
        
        public delegate void MessageRecievedHandler(object sender, IRCMessageArgs e);
        public event MessageRecievedHandler MessageRecieved;

        public Scry(TwitchIRC client)
        {
            ircClient = client;
            messageReader = new Thread(new ThreadStart(Run));
            messageParcer = new MessageParcer();   
        }

        public void startListening()
        {
            messageReader.IsBackground = true;
            messageReader.Start();
        }

        public async void Run()
        {
            while (true)
            {
                string message = ircClient.ReadMessage();
                if (message != null)
                {
                    //todo: parse the message and return a TwitchMessage
                    TwitchMessage parcedMessage;
                    messageParcer.ParseMessage(message);

                }
            }
        }
    }
} 
