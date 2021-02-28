using System;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace RemoteController.Services.Parser
{
    class MouseInfoCommand : CommandExecutor<MouseInfoResult, object>
    {
        //{"command":"mouse_info","data":null}
        public MouseInfoResult Execute()
        {
            MouseInfoResult result = new MouseInfoResult();

            result.CursorX = Cursor.Position.X;
            result.CursorY = Cursor.Position.Y;
            result.ScreenWidth = Screen.PrimaryScreen.Bounds.Width;
            result.ScreenHeight = Screen.PrimaryScreen.Bounds.Height;
            return result;
        }

        public void SetData(object a) {
            throw new NotImplementedException();
        } 
    }

    class MouseInfoResult
    {
        [JsonProperty("screenWidth")]
        public int ScreenWidth;

        [JsonProperty("screenHeight")]
        public int ScreenHeight;

        [JsonProperty("cursorX")]
        public int CursorX;

        [JsonProperty("cursorY")]
        public int CursorY;
    }
}
