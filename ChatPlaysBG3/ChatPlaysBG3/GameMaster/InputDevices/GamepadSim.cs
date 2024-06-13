using SimWinInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatPlaysBG3.GameMaster.InputDevices
{
    internal class GamepadSim
    {
        public GamepadSim() 
        {
            SimGamePad.Instance.Initialize();
        }

        public void PluginGamepad()
        {
            SimGamePad.Instance.PlugIn();
        }

        public void UnplugGamepad()
        {
            SimGamePad.Instance.Unplug();
        }
    }
}
