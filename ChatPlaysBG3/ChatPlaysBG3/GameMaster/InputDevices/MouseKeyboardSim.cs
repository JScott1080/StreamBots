using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;


namespace ChatPlaysBG3.GameMaster.InputDevices
{
    internal class MouseKeyboardSim
    {
        private InputSimulator simulator;

        public MouseKeyboardSim()
        {
            simulator = new InputSimulator();
            
        }

        public async void InputGameCommand(string input)
        {
            await InputGameButtonCommand(input);
        }

        private Task InputGameButtonCommand(string input)
        {
            switch (input)
            {
                case "w" or "a" or "s" or "d":
                    SimWinInput.SimKeyboard.Press(Encoding.ASCII.GetBytes(input)[0], 1000);
                    break;
                case "mup":
                    simulator.Mouse.MoveMouseBy(0, -100);
                    break;
                case "mle":
                    simulator.Mouse.MoveMouseBy(-100, 0);
                    break;
                case "mwd":
                    simulator.Mouse.MoveMouseBy(0, 100);
                    break;
                case "mri":
                    simulator.Mouse.MoveMouseBy(100, 0);
                    break;
                case "z" or "v" or "x" or "f" or "r" or "u" or "n" or "i" or "k" or "b" or "l" or "j" or "m" or "p" or "h" or "y" or "g":
                    SimWinInput.SimKeyboard.Press(Encoding.ASCII.GetBytes(input)[0]);
                    break;
                case "ttc":
                    SimWinInput.SimKeyboard.Press((byte)'O');
                    break;
                case "crl":
                    SimWinInput.SimKeyboard.Press((byte)'Q', 250);
                    break;
                case "crr":
                    SimWinInput.SimKeyboard.Press((byte)'E', 250);
                    break;
                case "czi":
                    simulator.Keyboard.KeyDown(VirtualKeyCode.PRIOR);
                    simulator.Keyboard.Sleep(250);
                    simulator.Keyboard.KeyUp(VirtualKeyCode.PRIOR);
                    break;
                case "czo":
                    simulator.Keyboard.KeyDown(VirtualKeyCode.NEXT);
                    simulator.Keyboard.Sleep(250);
                    simulator.Keyboard.KeyUp(VirtualKeyCode.NEXT);
                    break;
                case "ccc":
                    simulator.Keyboard.KeyPress(VirtualKeyCode.HOME);
                    break;
                case "lmb":
                    simulator.Mouse.LeftButtonClick();
                    break;
                case "hlc":
                    simulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.SHIFT, VirtualKeyCode.VK_1);
                    break;
                case "sil":
                    simulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.SHIFT, VirtualKeyCode.VK_2);
                    break;
                case "ssc" or "tc":
                    simulator.Keyboard.KeyPress(VirtualKeyCode.RSHIFT);
                    break;
                case "pma" or "et":
                    simulator.Keyboard.KeyPress(VirtualKeyCode.MENU);
                    break;
                case "tgh":
                    simulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.SHIFT, VirtualKeyCode.VK_C);
                    break;
                case "th":
                    SimWinInput.SimKeyboard.Press((byte)'c');
                    break;
                case "jump":
                    SimWinInput.SimKeyboard.Press((byte)'z');
                    break;
                case "shove":
                    SimWinInput.SimKeyboard.Press((byte)'v');
                    break;
                case "throw":
                    SimWinInput.SimKeyboard.Press((byte)'x');
                    break;
                case "tws":
                    SimWinInput.SimKeyboard.Press((byte)'f');
                    break;
                case "tdw":
                    SimWinInput.SimKeyboard.Press((byte)'r');
                    break;
                case "suw":
                    SimWinInput.SimKeyboard.Press((byte)'u');
                    break;
                case "end" or "cet" or "skip" or "ta":
                    simulator.Keyboard.KeyPress(VirtualKeyCode.SPACE);
                    break;
                case "tbm" or "run":
                    simulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.SHIFT, VirtualKeyCode.SPACE);
                    break;
                case "sr":
                    SimWinInput.SimKeyboard.Press((byte)'y');
                    break;
                case "tgm":
                    SimWinInput.SimKeyboard.Press((byte)'g');
                    break;
                case "cs":
                    SimWinInput.SimKeyboard.Press((byte)'n');
                    break;
                case "inv":
                    SimWinInput.SimKeyboard.Press((byte)'i');
                    break;
                case "pv":
                    SimWinInput.SimKeyboard.Press((byte)';');
                    break;
                case "sb":
                    SimWinInput.SimKeyboard.Press((byte)'k');
                    break;
                case "ip":
                    SimWinInput.SimKeyboard.Press((byte)'b');
                    break;
                case "reac":
                    SimWinInput.SimKeyboard.Press((byte)'l');
                    break;
                case "journal":
                    SimWinInput.SimKeyboard.Press((byte)'j');
                    break;
                case "map":
                    SimWinInput.SimKeyboard.Press((byte)'m');
                    break;
                case "ins":
                    SimWinInput.SimKeyboard.Press((byte)'p');
                    break;
                case "alch":
                    SimWinInput.SimKeyboard.Press((byte)'h');
                    break;
                case "quicksave":
                    simulator.Keyboard.KeyPress(VirtualKeyCode.F5);
                    break;
                case "quickload":
                    simulator.Keyboard.KeyPress(VirtualKeyCode.F8);
                    break;
                case "rmb" or "cm" or "ca":
                    simulator.Mouse.RightButtonClick();
                    break;
                case "cw":
                    SimWinInput.SimKeyboard.Press((byte)'"');
                    break;
                case "ept":
                    SimWinInput.SimKeyboard.Press((byte)'t');
                    break;
                case "cp1":
                    simulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.MENU, VirtualKeyCode.VK_1);
                    break;
                case "cp2":
                    simulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.MENU, VirtualKeyCode.VK_2);
                    break;
                case "cp3":
                    simulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.MENU, VirtualKeyCode.VK_3);
                    break;
                case "cp4":
                    simulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.MENU, VirtualKeyCode.VK_4);
                    break;
                case "snc":
                    SimWinInput.SimKeyboard.Press((byte)']');
                    break;
                case "spc":
                    SimWinInput.SimKeyboard.Press((byte)'[');
                    break;
                case "ui":
                    simulator.Keyboard.KeyPress(VirtualKeyCode.F18);
                    break;
                default:
                    Console.WriteLine($"Invalid command '{input}' parsed");
                    break; 
            }
            return Task.CompletedTask;
        }
    }
}
