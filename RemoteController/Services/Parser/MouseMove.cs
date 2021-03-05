using System;
using Newtonsoft.Json;
using WindowsInput;

namespace RemoteController.Services.Parser
{
    class MouseMoveInput {
        [JsonProperty("cursorX")]
        public int CursorX;

        [JsonProperty("cursorY")]
        public int CursorY;

        [JsonProperty("type")]
        public string Type;
    }

    // {"command":"mouse_move","data":{"cursorX": 50,"cursorY": 50}}
    class MouseMoveCommand : CommandExecutor<MouseMoveInput>
    {
        protected MouseMoveInput input;

        protected InputSimulator simulator;

        public MouseMoveCommand(InputSimulator simulator) {
            this.simulator = simulator;
        }

        public MouseInfoResult Execute()
        {
            if (this.input.Type == "relative_mouse_move") {
                simulator.Mouse.MoveMouseBy(this.input.CursorX, this.input.CursorY);
            } else
            {
                simulator.Mouse.MoveMouseTo(this.input.CursorX, this.input.CursorY);
            }
            return new MouseInfoCommand().Execute();
        }

        public void SetData(MouseMoveInput input)
        {
            this.input = input;
        }
    }
}
