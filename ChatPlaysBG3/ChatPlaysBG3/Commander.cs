using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;

namespace ChatPlaysBG3
{
    internal class Commander
    {

        Archive localArchive;

        public Commander(Archive lcalArchive)
        {
            this.localArchive = lcalArchive;

        }

        private void Client_onConnectionError(object? sender, OnConnectionErrorArgs e)
        {
            Console.WriteLine($"Connection Error: {e.Error}");
        }

        private void Client_onConnected(object? sender, OnConnectedArgs e)
        {
            Console.WriteLine($"Connected to {e.AutoJoinChannel}");
        }

    }
}
