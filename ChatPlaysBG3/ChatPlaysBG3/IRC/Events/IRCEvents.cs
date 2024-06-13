using ChatPlaysBG3.ChatIRC.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatPlaysBG3.IRC.Events
{
    class IRCMessageArgs : EventArgs
    {
        public TwitchMessage ircMessage { get; set; }

        public IRCMessageArgs(TwitchMessage message)
        {
            ircMessage = message;
        }
    }

}
