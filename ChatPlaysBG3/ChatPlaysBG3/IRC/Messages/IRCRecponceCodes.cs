using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatPlaysBG3.ChatIRC.Messages
{
    public enum IRCResponceCodes
    {
        Unknown,
        PrivMsg,
        Notice,
        Ping,
        Pong,
        Join,
        Part,
        ClearChat,
        ClearMsg,
        UserState,
        GlobalUserState,
        Nick,
        Pass,
        Cap,
        RPL_001,
        RPL_002,
        RPL_003,
        RPL_004,
        RPL_353,
        RPL_366,
        RPL_372,
        RPL_375,
        RPL_376,
        Whisper,
        RoomState,
        Reconnect,
        ServerChange,
        UserNotice,
        Mode
    }
}
