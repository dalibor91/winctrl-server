using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using Newtonsoft.Json;


namespace RemoteController.Services.Parser
{
    class MouseMoveInput {
        [JsonProperty("cursorX")]
        public int CursorX;

        [JsonProperty("cursorY")]
        public int CursorY;
    }

    // {"command":"mouse_move","data":{"cursorX": 50,"cursorY": 50}}
    class MouseMoveCommand : CommandExecutor<MouseInfoResult, MouseMoveInput>
    {
        protected MouseMoveInput input;

        public MouseInfoResult Execute()
        {

            Cursor _cur = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(this.input.CursorX, this.input.CursorY);
           // Cursor.Clip = new Rectangle(Cur, this.Size);

            MouseInfoResult mouseInfo = new MouseInfoCommand().Execute();

            return mouseInfo;
        }

        public void SetData(MouseMoveInput input)
        {
            this.input = input;
        }
    }
}
