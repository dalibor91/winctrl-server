using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace RemoteController.Services.Parser
{
    class ProcessInput {
        [JsonProperty("type")]
        public string type;

        [JsonProperty("name")]
        public string name;
    }

    class ProcessCommand: CommandExecutor<ProcessInput, MouseInfoResult>
    {
        protected ProcessInput input;

        public ProcessCommand() { 

        }

        public MouseInfoResult Execute() {
            throw new NotImplementedException();
        }

        public void SetData(ProcessInput data)
        {
            throw new NotImplementedException();
        }
    }
}
