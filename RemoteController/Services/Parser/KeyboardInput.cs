using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
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
    class KeyboardInputCommand : CommandExecutor<MouseInfoResult, KeyboardInputInput>
    {
        protected KeyboardInputInput input;

        protected InputSimulator simulator;

        // see https://docs.microsoft.com/en-gb/windows/win32/inputdev/virtual-key-codes?redirectedfrom=MSDN
        // see https://www.codeproject.com/Articles/7305/Keyboard-Events-Simulation-using-keybd-event-funct
        // see https://archive.codeplex.com/?p=inputsimulator

        public KeyboardInputCommand() {
            simulator = new InputSimulator();
        }

        public MouseInfoResult Execute()
        {
            simulator.Keyboard.TextEntry(this.input.message);
            //todo 
            return new MouseInfoCommand().Execute(); ;
        }

        public void SetData(KeyboardInputInput input) {
            this.input = input;
        } 
    }
}
