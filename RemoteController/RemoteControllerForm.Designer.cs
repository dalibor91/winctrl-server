
namespace RemoteController
{
    partial class RemoteControllerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.startRemote = new System.Windows.Forms.Button();
            this.debugOutput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.serverLocation = new System.Windows.Forms.TextBox();
            this.stopRemote = new System.Windows.Forms.Button();
            this.serviceWorker = new System.ComponentModel.BackgroundWorker();
            this.label3 = new System.Windows.Forms.Label();
            this.authenticationKey = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // startRemote
            // 
            this.startRemote.Location = new System.Drawing.Point(12, 380);
            this.startRemote.Name = "startRemote";
            this.startRemote.Size = new System.Drawing.Size(106, 23);
            this.startRemote.TabIndex = 0;
            this.startRemote.Text = "Start Remote Worker";
            this.startRemote.UseVisualStyleBackColor = true;
            this.startRemote.Click += new System.EventHandler(this.StartRemoteClick);
            // 
            // debugOutput
            // 
            this.debugOutput.Location = new System.Drawing.Point(12, 72);
            this.debugOutput.Multiline = true;
            this.debugOutput.Name = "debugOutput";
            this.debugOutput.Size = new System.Drawing.Size(594, 302);
            this.debugOutput.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Url to websocket controller";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Debug output";
            // 
            // serverLocation
            // 
            this.serverLocation.Location = new System.Drawing.Point(15, 26);
            this.serverLocation.Name = "serverLocation";
            this.serverLocation.Size = new System.Drawing.Size(290, 20);
            this.serverLocation.TabIndex = 4;
            this.serverLocation.Text = "0.0.0.0:8181";
            // 
            // stopRemote
            // 
            this.stopRemote.Enabled = false;
            this.stopRemote.Location = new System.Drawing.Point(512, 380);
            this.stopRemote.Name = "stopRemote";
            this.stopRemote.Size = new System.Drawing.Size(94, 23);
            this.stopRemote.TabIndex = 5;
            this.stopRemote.Text = "Stop Remote";
            this.stopRemote.UseVisualStyleBackColor = true;
            this.stopRemote.Click += new System.EventHandler(this.StopRemoteClick);
            // 
            // serviceWorker
            // 
            this.serviceWorker.WorkerSupportsCancellation = true;
            this.serviceWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ServiceWorkerDoWork);
            this.serviceWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ServiceWorkerRunWorkerCompleted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(308, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Key to authenticate";
            this.label3.Visible = false;
            // 
            // authenticationKey
            // 
            this.authenticationKey.Location = new System.Drawing.Point(311, 25);
            this.authenticationKey.Name = "authenticationKey";
            this.authenticationKey.Size = new System.Drawing.Size(295, 20);
            this.authenticationKey.TabIndex = 7;
            this.authenticationKey.Visible = false;
            // 
            // RemoteControllerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 415);
            this.Controls.Add(this.authenticationKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.stopRemote);
            this.Controls.Add(this.serverLocation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.debugOutput);
            this.Controls.Add(this.startRemote);
            this.MaximizeBox = false;
            this.Name = "RemoteControllerForm";
            this.Text = "Remote Control ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startRemote;
        private System.Windows.Forms.TextBox debugOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox serverLocation;
        private System.Windows.Forms.Button stopRemote;
        private System.ComponentModel.BackgroundWorker serviceWorker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox authenticationKey;
    }
}

