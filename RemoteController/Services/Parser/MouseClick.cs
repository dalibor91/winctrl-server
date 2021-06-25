using System;
using Newtonsoft.Json;
using WindowsInput;

namespace RemoteController.Services.Parser
{

    class MouseClickInput
    {
        [JsonProperty("type")]
        public string type;
    }

    // {"command":"mouse_move","data":{"tyle": "left"}}
    class MouseClickCommand : CommandExecutor<MouseClickInput, MouseInfoResult>
    {
        protected MouseClickInput input;

        protected InputSimulator simulator;

        public MouseClickCommand(IInputSimulator simulator) {
            this.simulator = new InputSimulator();
        }

        public MouseInfoResult Execute()
        {
            switch (input.type) {
                case "left":
                    simulator.Mouse.LeftButtonClick();
                    break;
                case "double_left":
                    simulator.Mouse.LeftButtonDoubleClick();
                    break;
                case "right":
                    simulator.Mouse.RightButtonClick();
                    break;
                case "double_right":
                    simulator.Mouse.RightButtonDoubleClick();
                    break;
            }

            return new MouseInfoCommand().Execute();
        }

        public void SetData(MouseClickInput input)
        {
            this.input = input;
        }
    }
}
