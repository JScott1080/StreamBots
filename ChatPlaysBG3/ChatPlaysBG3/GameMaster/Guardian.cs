using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ChatPlaysBG3.GameMaster
{
    public class Guardian
    {

        public event EventHandler DisableChatPlays;
        public event EventHandler EnableChatPlays;

        private Thread gameWacher;

        internal void guardianInit()
        {
            Console.WriteLine("Eyes up Guardian");
            gameWacher = new Thread(new ThreadStart(watchGame));
            gameWacher.Start();
        }

        public void watchGame()
        {
            while (true)
            {
                try
                {
                    var targetProcess = Process.GetProcessesByName("bg3_dx11").FirstOrDefault();
                    if (targetProcess == null || targetProcess.HasExited || !targetProcess.Responding)
                    {
                        Console.WriteLine($"Restarting {"bg3_dx11"} at time: {DateTime.Now.ToString("h:mm:ss tt")}");

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


    }
}
