using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteController.Services
{
    public class HelpService
    {

        protected FormService formService;

        public HelpService(FormService formService)
        {
            this.formService = formService;
        }

        public void LogToDebugControl(string msg)
        {
            ((TextBox)this.formService.GetControl("debugOutput")).AppendText(String.Format("[{0}] {1}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), msg));
        }
    }
}
