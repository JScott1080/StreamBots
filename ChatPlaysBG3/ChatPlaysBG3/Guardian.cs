using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ChatPlaysBG3
{
    public class Guardian
    {

        public event EventHandler DisableChatPlays;
        public event EventHandler EnableChatPlays;

        void startGame()
        {
            try
            {
                string appPath = @"D:\SteamLibrary\steamapps\common\Baldurs Gate 3\bin\bg3_dx11.exe";

                string arguments = " --skip-launcher";

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = appPath,
                    Arguments = arguments,
                    UseShellExecute = false
                };

                Process.Start(appPath);

                Thread.Sleep(TimeSpan.FromSeconds(30));
                //start game
     
                if (EnableChatPlays != null)
                {
                    EnableChatPlays(this, EventArgs.Empty);
                }
                else { Console.WriteLine("unable to enable chats"); }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error launching the app: {ex.Message}");
            }
        }

        internal void guardianInit()
        {
             const string targetAppName = "bg3_dx11";

            while (true)
            {
                try
                {
                    var targetProcess = Process.GetProcessesByName(targetAppName).FirstOrDefault();
                    if (targetProcess == null || targetProcess.HasExited || !targetProcess.Responding)
                    {
                        Console.WriteLine($"Restarting {targetAppName} at time: {DateTime.Now.ToString("h:mm:ss tt")}");

                        if (DisableChatPlays != null)
                        {
                            DisableChatPlays(this, EventArgs.Empty);
                        }
                        else { Console.WriteLine("unable to diable chats"); }

                        startGame();
                    }

                    //check every 3 seconds
                    Thread.Sleep(TimeSpan.FromSeconds(3));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
