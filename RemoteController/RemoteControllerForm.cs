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

        private delegate void MessageFromWorker(string message);
        private MessageFromWorker displayWorkerMessage;

        public RemoteControllerForm() {
            InitializeComponent();
            this.formService = new Services.FormService(this);
            this.helpService = formService.HelpService();
            this.displayWorkerMessage = new MessageFromWorker(this.HandleWorkerMessage);
        }

        private void HandleWorkerMessage(string message) {
            this.helpService.LogToDebugControl(message);
        }

        private void RemoteControlFormLoaded(object sender, EventArgs e)
        {
            this.helpService.LogToDebugControl("Form Loaded. Debug output should be saved on exit in some file...");
        }

        private void RemoteControlFormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void StartRemoteClick(object sender, EventArgs e)
        {
            TextBox location = this.formService.ServerLocation();
            Button startServer = this.formService.StartRemoteServer();
            Button stopServer = this.formService.StopRemoteServer();

            //this.helpService.LogToDebugControl(String.Format("Start Server at location: {0}", location.Text));

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

        /*private void startRemoteServer(object sender, EventArgs e)
        {
            int screenW = Screen.PrimaryScreen.Bounds.Width;
            int screenH = Screen.PrimaryScreen.Bounds.Height;

            int mouseX = Cursor.Position.X;
            int mouseY = Cursor.Position.Y;

            this.helpService.LogToDebugControl("Screen w: " + screenW.ToString() + " Screen h: " + screenH.ToString());
            this.helpService.LogToDebugControl("Mouse x: " + mouseX.ToString() + " Mouse Y: " + mouseY.ToString());
            
            var server = new WebSocketServer("ws://0.0.0.0:8181");
            server.Start(socket =>
            {
                socket.OnOpen = () => this.helpService.LogToDebugControl("Open!");
                socket.OnClose = () => this.helpService.LogToDebugControl("Close!");
                socket.OnMessage = (message) => {
                    socket.Send(message);
                    this.helpService.LogToDebugControl(message);
                };
            });
        }

        private void stopRemoteServer(object sender, EventArgs e)
        {

        }*/
    }
}
