using System;
using WindowsInput.Native;
using Newtonsoft.Json;
using WindowsInput;

namespace RemoteController.Services.Parser
{
    class KeyboardInputInput
    {
        [JsonProperty("message")]
        public string message;
    }

    //{"command":"mouse_info","data":{"input": "foo,bar,baz"}}
    class KeyboardInputCommand : CommandExecutor<KeyboardInputInput>
    {
        protected KeyboardInputInput input;

        protected InputSimulator simulator;

        // see https://docs.microsoft.com/en-gb/windows/win32/inputdev/virtual-key-codes?redirectedfrom=MSDN
        // see https://www.codeproject.com/Articles/7305/Keyboard-Events-Simulation-using-keybd-event-funct
        // see https://archive.codeplex.com/?p=inputsimulator
        public KeyboardInputCommand(InputSimulator simulator)
        {
            this.simulator = simulator;
        }

        public MouseInfoResult Execute()
        {

            this.ParseText();
            return new MouseInfoCommand().Execute(); ;
        }

        public void SetData(KeyboardInputInput input)
        {
            this.input = input;
        }

        protected void ParseText()
        {
            string message = this.input.message;

            switch (message.ToLower())
            {
                case "{enter}":
                    simulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);
                    break;
                case "{backspace}":
                case "{bksp}":
                    simulator.Keyboard.KeyPress(VirtualKeyCode.BACK);
                    break;
                case "{escape}":
                    simulator.Keyboard.KeyPress(VirtualKeyCode.ESCAPE);
                    break;
                case "{capslock}":
                case "{lock}":
                    simulator.Keyboard.KeyPress(VirtualKeyCode.CAPITAL);
                    break;
                case "{tab}":
                    simulator.Keyboard.KeyPress(VirtualKeyCode.TAB);
                    break;
                case "{lwin}":
                    simulator.Keyboard.KeyPress(VirtualKeyCode.LWIN);
                    break;
                case "{rwin}":
                    simulator.Keyboard.KeyPress(VirtualKeyCode.RWIN);
                    break;
                case "{space}":
                    simulator.Keyboard.KeyPress(VirtualKeyCode.SPACE);
                    break;
                case "{arrow_left}":
                    simulator.Keyboard.KeyPress(VirtualKeyCode.LEFT);
                    break;
                case "{arrow_right}":
                    simulator.Keyboard.KeyPress(VirtualKeyCode.RIGHT);
                    break;
                case "{arrow_up}":
                    simulator.Keyboard.KeyPress(VirtualKeyCode.UP);
                    break;
                case "{arrow_down}":
                    simulator.Keyboard.KeyPress(VirtualKeyCode.DOWN);
                    break;
                case "{vol_up}":
                    simulator.Keyboard.KeyPress(VirtualKeyCode.VOLUME_UP);
                    break;
                case "{vol_down}":
                    simulator.Keyboard.KeyPress(VirtualKeyCode.VOLUME_DOWN);
                    break;
                case "{shift}":
                    simulator.Keyboard.KeyPress(VirtualKeyCode.SHIFT);
                    break;
                default:
                    simulator.Keyboard.TextEntry(message);
                    break;
            }
        }
    }
}
