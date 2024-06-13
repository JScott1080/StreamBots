using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatPlaysBG3.GameMaster
{
    internal interface GameInputs
    {
       Dictionary<string, WindowsInput.Native.VirtualKeyCode> Keys { get; }
    }
}
