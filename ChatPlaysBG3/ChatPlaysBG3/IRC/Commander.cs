using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatPlaysBG3.ChatIRC.Interfaces;
using ChatPlaysBG3.IRC.Interfaces;

namespace ChatPlaysBG3.ChatIRC
{
    internal class Commander
    {

        private Archive _localArchive;
        private Scry scryer;
        private TwitchPing pinger;
        private TwitchIRC twitchIRC;

        public Commander(Archive archive)
        {
            this._localArchive = archive;

            if (_localArchive != null)
            {
                twitchIRC = new TwitchIRC(_localArchive.Username, _localArchive.Password, _localArchive.ChannelName);

                pinger = new TwitchPing(twitchIRC);
                pinger.startPing();

                scryer = new Scry(twitchIRC);
                twitchIRC.JoinChannel();
                
                StartListener();
            }
            
        }

        

        public async void StartListener() 
        {
           scryer.startListening();
        }

    }
}
