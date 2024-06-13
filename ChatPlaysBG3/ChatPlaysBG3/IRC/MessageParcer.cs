using ChatPlaysBG3.ChatIRC.Messages;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChatPlaysBG3.IRC
{
    class MessageParcer
    {
        public TwitchMessage ParseMessage(string message)
        {
            TwitchMessage parcedMessage = new TwitchMessage();

            int idx = 0;
            int endIdx = 1;

            string rawTagsComponent = null;
            string rawSourceComponent = null;
            string rawCommandComponent = null;
            string rawParametersCompoent = null;


            //get the tags as raw data
            if (message[idx] == '@')
            {
                endIdx = message.IndexOf(' ');
                rawTagsComponent = message.Substring(1, endIdx);
                idx = endIdx + 1;
            }

            //get the source (host and username) of the message
            //if not pointed at the source, this is a PING
            if (message[idx] == ':')
            {
                idx += 1;
                endIdx = message.IndexOf(' ', idx);
                rawSourceComponent = message.Substring(idx, endIdx);
                idx = endIdx + 1;
            }

            //get the command component of the message
            endIdx = message.IndexOf(':', idx);
            if (endIdx == -1)
            {
                endIdx = message.Length;
            }

            //Console.WriteLine($"Message Lenght: {message.Length}\nendIdx: {endIdx}");

            
            rawCommandComponent = message.Substring(idx).Trim();
            
            //get the parameters
            if (endIdx != message.Length)
            {
                idx = endIdx + 1;
                rawParametersCompoent = message.Substring(idx);
            }

            parcedMessage.Command = parseCommand(rawCommandComponent);

            if (parcedMessage.Command == null) 
            {
                Console.WriteLine(message);
                return null;
            }
            else
            {
                if(rawParametersCompoent != null)
                {
                    parcedMessage.Tags = parseTags(rawTagsComponent);
                }
                
                parcedMessage.Source = parseSource(rawSourceComponent);

                parcedMessage.Parameters = rawParametersCompoent;

                if(rawParametersCompoent != null && rawParametersCompoent[0] == '!' || rawParametersCompoent[0] == '~0')
                {
                    parcedMessage.Command = parseParameters(rawParametersCompoent, parcedMessage.Command);
                }
            }
            

            return parcedMessage;
        }

        public Dictionary<string, string> parseTags(string rawTags)
        {
            return null;
        }

        //parse the command
        public Dictionary<string, string> parseCommand(string rawCommand)
        {
            Dictionary<string, string> parcedCommand = new Dictionary<string, string>();
            string[] commandParts = rawCommand.Split(' ');

            switch (commandParts[0])
            {
                case "JOIN":
                    return null;
                case "PART":
                    return null;
                case "NOTICE":
                    return null;
                case "CLEARCHAT":
                    return null;
                case "HOSTTARGET":
                    return null;
                case "PRIVMSG":
                    parcedCommand.Add("command", commandParts[0]);
                    parcedCommand.Add("channel", commandParts[1]);
                    break;
                case "PING":
                    parcedCommand.Add("command", commandParts[0]);
                    break;
                case "PONG":
                    parcedCommand.Add("command", commandParts[0]);
                    break;
                case "CAP":
                    parcedCommand.Add("command", commandParts[0]);
                    parcedCommand.Add("isCapRequestEnabled", commandParts[2]);
                    break;
                case "GLOBALUSERSTATE":
                    parcedCommand.Add("command", commandParts[0]);
                    break;
                case "USERSTATE":
                    return null;
                case "ROOMSTATE":
                    parcedCommand.Add("command", commandParts[0]);
                    parcedCommand.Add("channel", commandParts[1]);
                    break;
                case "RECONNECET":
                    parcedCommand.Add("command", commandParts[0]);
                    break;
                case "421":
                    Console.WriteLine($"Unsupported IRC command: {commandParts[2]}");
                    return null;
                case "001":
                    parcedCommand.Add("command", commandParts[0]);
                    parcedCommand.Add("channel", commandParts[1]);
                    break;
                case "002":
                    return null;
                case "003":
                    return null;
                case "004":
                    return null;
                case "353": //who else is in the chat
                    return null;
                case "366":
                    return null;
                case "372":
                    return null;
                case "375":
                    return null;
                case "376":
                    return null;
                default:
                    Console.WriteLine($"\nUnexpected Command: {commandParts[0]}\n");
                    return null;
            }
            return parcedCommand;
        }

        public string parseSource(string rawSource)
        {
            if (rawSource == null) { return null; }
            else
            {
                string[] sourceParts = rawSource.Split('!');
                return sourceParts[0];
            }    
        }

        public string parseParameters(string rawParameters, Dictionary<string, string> command) 
        {  
            return " "; 
        }
    }
}
