using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fleck;

namespace RemoteController
{
    public partial class RemoteControllerForm : Form {
        public readonly Services.FormService formService;
        public readonly Services.HelpService helpService;

        public string[] ServerArguments;

        private delegate void MessageFromWorker(string message);
        private MessageFromWorker displayWorkerMessage;

        public RemoteControllerForm() {
            InitializeComponent();
            Load += AfterFormLoaded;
            this.formService = new Services.FormService(this);
            this.helpService = formService.HelpService();
            this.displayWorkerMessage = new MessageFromWorker(this.HandleWorkerMessage);
        }

        private void HandleWorkerMessage(string message) {
            this.helpService.LogToDebugControl(message);
        }

        private void AfterFormLoaded(object sender, EventArgs e) {
            this.helpService.LogToDebugControl("Form Loaded. Debug output should be saved on exit in some file...");
            if (ServerArguments.Length > 0)
            {
                formService.ServerLocation().Text = ServerArguments[0];
                formService.StartRemoteServer().PerformClick();
            }
        }

        private void StartRemoteClick(object sender, EventArgs e)
        {
            TextBox location = this.formService.ServerLocation();
            Button startServer = this.formService.StartRemoteServer();
            Button stopServer = this.formService.StopRemoteServer();


            startServer.Enabled = !startServer.Enabled;
            location.Enabled = !location.Enabled;
            stopServer.Enabled = !stopServer.Enabled;
            serviceWorker.RunWorkerAsync(location.Text);
        }

        private void StopRemoteClick(object sender, EventArgs e)
        {

            TextBox location = this.formService.ServerLocation();
            Button startServer = this.formService.StartRemoteServer();
            Button stopServer = this.formService.StopRemoteServer();

            //this.helpService.LogToDebugControl(String.Format("Stoping Server at location: {0}", location.Text));

            startServer.Enabled = !startServer.Enabled;
            location.Enabled = !location.Enabled;
            stopServer.Enabled = !stopServer.Enabled;

            serviceWorker.CancelAsync();
        }

        private void ServiceWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            Services.WebsocketService service = new Services.WebsocketService(e.Argument.ToString(), (string message) => {
                this.Invoke(this.displayWorkerMessage, message);
            });

            service.Start();

            while (true)
            {
                System.Threading.Thread.Sleep(500);

                if (worker.CancellationPending)
                {
                    service.Stop();
                    break;
                }
            }
        }

        private void ServiceWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.helpService.LogToDebugControl("ServiceWorkerRunWorkerCompleted");
        }
    }
}
