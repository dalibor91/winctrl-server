using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Newtonsoft.Json;


namespace RemoteController.Services.Parser
{

    class MouseClickInput
    {
        [JsonProperty("type")]
        public string type;
    }

    // {"command":"mouse_move","data":{"tyle": "left"}}
    class MouseClickCommand : CommandExecutor<MouseInfoResult, MouseClickInput>
    {
        protected MouseClickInput input;

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        // Mouse actions
        // see https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-mouse_event
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public MouseInfoResult Execute()
        {

            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;

            switch (input.type) {
                case "left":
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
                    break;
                case "double_left":
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
                    break;
                case "right":
                    mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, X, Y, 0, 0);
                    break;
            }

            MouseInfoResult mouseInfo = new MouseInfoCommand().Execute();

            return mouseInfo;
        }

        public void SetData(MouseClickInput input)
        {
            this.input = input;
        }
    }
}
