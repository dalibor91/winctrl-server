using System;
using Newtonsoft.Json;

namespace RemoteController.Services.Parser
{

    interface CommandExecutor<InputForExecution, ExecuteResult>
    {
        ExecuteResult Execute();

        void SetData(InputForExecution data);
    }

    public class ParsedCommand
    {
     
        [JsonProperty("command")]
        public string Command { get; set; }

        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        [JsonProperty("data")]
        public object Data { get; set; }
        public ExecutedCommand Execute()
        {

            ExecutedCommand cmd = new ExecutedCommand();
            cmd.Uuid = this.Uuid;

            WindowsInput.InputSimulator simulator = new WindowsInput.InputSimulator();

            cmd.Success = true;

            switch (Command)
            {
                case "mouse_info":
                    cmd.Result = new MouseInfoCommand().Execute();
                    break;
                case "mouse_click":
                    MouseClickCommand _cmdClick = new MouseClickCommand(simulator);
                    _cmdClick.SetData(ConvertObject<MouseClickInput>(Data));
                    cmd.Result = _cmdClick.Execute();
                    break;
                case "mouse_move":
                    MouseMoveCommand _cmdMove = new MouseMoveCommand(simulator);
                    _cmdMove.SetData(ConvertObject<MouseMoveInput>(Data));
                    cmd.Result = _cmdMove.Execute();
                    break;
                case "keyboard_input":
                    KeyboardInputCommand _keyboardCommand = new KeyboardInputCommand(simulator);
                    _keyboardCommand.SetData(ConvertObject<KeyboardInputInput>(Data));
                    cmd.Result = _keyboardCommand.Execute();
                    break;
                case "process_list":
                    ProcessCommand _processCommand = new ProcessCommand();
                    _processCommand.SetData(ConvertObject<ProcessInput>(Data));
                    cmd.Result = _processCommand.Execute();
                    break;
                default:
                    cmd.ErrorMessage = "Command not found";
                    cmd.Success = false;

                    break;
            }

            return cmd;
        }

        private static T ConvertObject<T>(object source)
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source));
        }
    }

    public class ExecutedCommand 
    { 
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("error")]
        public string ErrorMessage { get; set; }

        [JsonProperty("result")]
        public object Result { get; set; }

        [JsonProperty("uuid")]
        public object Uuid { get; set; }

        public static ExecutedCommand Error(string message)
        {
            ExecutedCommand exec = new ExecutedCommand();
            exec.Success = false;
            exec.ErrorMessage = message;

            return exec;
        }

        public string Serialized()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class Command
    {
        protected readonly string rawMessage;

        public Command(string message)
        {
            // ignore for now  :) 
            rawMessage = message;
        }

        public static ParsedCommand Decode(string message) {
            return new Command(message).Convert();
        }

        private ParsedCommand Convert() {
            return JsonConvert.DeserializeObject<ParsedCommand>(rawMessage);
        }
    }
}
