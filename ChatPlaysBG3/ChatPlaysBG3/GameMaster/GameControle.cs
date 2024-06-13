using ChatPlaysBG3.GameMaster.InputDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;


namespace ChatPlaysBG3.GameMaster
{
    internal class GameControle
    {
        private GamepadSim vGamePad;
        private MouseKeyboardSim vMouseKeyboard;

        public GameControle()
        {
            //Create a new virtual Gamepad and Mouse & Keyboard
            vGamePad = new GamepadSim();
            vMouseKeyboard = new MouseKeyboardSim();

            //Determin if we want to use gamepad or K&M

            //Start up whatever listener we need to. 
        }

        public void GameCommand(string input)
        {
            //todo determin intended input type and send the appropriate command
        }

        private void GamepadInput(string input) 
        {
        }
        
        private void keyboardInput(string input) 
        { 
        }

        private void MouseInput(string input) 
        {
        }

    }
}
