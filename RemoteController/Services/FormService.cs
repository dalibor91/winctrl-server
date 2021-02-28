using System;
using System.Net;
using System.ComponentModel;
using System.Windows.Forms;

namespace RemoteController.Services
{
    public class FormService
    {
        protected readonly Form TargetForm;

        public FormService(Form form)
        {
            this.TargetForm = form;
        }

        public Control[] FindControls(string key)
        {
            return TargetForm.Controls.Find(key, true);
        }

        public Control GetControl(string key)
        {
            Control[] c = FindControls(key);

            if (c.Length < 1)
            {
                throw new Exception(String.Format("Unable to find id: '{0}'", key));
            }

            return c[0];
        }

        public HelpService HelpService()
        {
            return new HelpService(this);
        }

        public TextBox DebugOutput()
        {
            return (TextBox)GetControl("debugOutput");
        }        
        
        public TextBox AuthenticationKey()
        {
            return (TextBox)GetControl("authenticationKey");
        }

        public TextBox ServerLocation()
        {
            return (TextBox)GetControl("serverLocation");
        }

        public Button StartRemoteServer()
        {
            return (Button)GetControl("startRemote");
        }
        public Button StopRemoteServer()
        {
            return (Button)GetControl("stopRemote");
        }
    }
}
