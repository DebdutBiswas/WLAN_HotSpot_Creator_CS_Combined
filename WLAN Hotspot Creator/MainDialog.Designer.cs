//INSTANT C# NOTE: Formerly VB project-level imports:
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;

using WLANHotspotCreator;
using Microsoft.Win32;
using System.Management;
using System.ComponentModel;
using IcsManagerLibrary;

namespace WLANHotspotCreator
{
	[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	public partial class MainDialog : System.Windows.Forms.Form
	{
		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;

		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.  
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDialog));
			this.VisualStyler = new SkinSoft.VisualStyler.VisualStyler(this.components);
			this.AppTray = new System.Windows.Forms.NotifyIcon(this.components);
			this.TrayMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.StartTrayMenuItm = new System.Windows.Forms.ToolStripMenuItem();
			this.StopTrayMenuItm = new System.Windows.Forms.ToolStripMenuItem();
			this.OpenAppTrayMenuItm = new System.Windows.Forms.ToolStripMenuItem();
			this.ExitTrayMenuItm = new System.Windows.Forms.ToolStripMenuItem();
			this.ConsoleThread = new System.ComponentModel.BackgroundWorker();
			this.MainDialogToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.passwordTextBox = new System.Windows.Forms.TextBox();
			this.ssidTextBox = new System.Windows.Forms.TextBox();
			this.connectionComboBox = new System.Windows.Forms.ComboBox();
			this.refreshConnectionButton = new System.Windows.Forms.Button();
			this.startButton = new System.Windows.Forms.Button();
			this.connectionLabel = new System.Windows.Forms.Label();
			this.passwordLabel = new System.Windows.Forms.Label();
			this.ssidLabel = new System.Windows.Forms.Label();
			this.ShowPasswordChkBox = new System.Windows.Forms.CheckBox();
			this.StatusLbl = new System.Windows.Forms.Label();
			this.CurrentRegistryWriteThread = new System.ComponentModel.BackgroundWorker();
			this.IcsRefreshThread = new System.ComponentModel.BackgroundWorker();
			this.IcsConnectThread = new System.ComponentModel.BackgroundWorker();
			((System.ComponentModel.ISupportInitialize)this.VisualStyler).BeginInit();
			this.TrayMenuStrip.SuspendLayout();
			this.SuspendLayout();
			//
			//VisualStyler
			//
			this.VisualStyler.HostForm = this;
			this.VisualStyler.License = (SkinSoft.VisualStyler.Licensing.VisualStylerLicense)resources.GetObject("VisualStyler.License");
			this.VisualStyler.ShadowStyle = SkinSoft.VisualStyler.ShadowStyle.Medium;
			this.VisualStyler.LoadVisualStyle(null, "XP Royale (Black).vssf");
			//
			//AppTray
			//
			this.AppTray.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.AppTray.BalloonTipText = "WLAN Hotspot Creator";
			this.AppTray.BalloonTipTitle = "WLAN Hotspot Creator";
			this.AppTray.ContextMenuStrip = this.TrayMenuStrip;
			this.AppTray.Icon = (System.Drawing.Icon)resources.GetObject("AppTray.Icon");
			this.AppTray.Text = "WLAN Hotspot Creator";
			//
			//TrayMenuStrip
			//
			this.TrayMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.StartTrayMenuItm, this.StopTrayMenuItm, this.OpenAppTrayMenuItm, this.ExitTrayMenuItm});
			this.TrayMenuStrip.Name = "TrayMenuStrip";
			this.TrayMenuStrip.ShowImageMargin = false;
			this.TrayMenuStrip.Size = new System.Drawing.Size(143, 92);
			//
			//StartTrayMenuItm
			//
			this.StartTrayMenuItm.Name = "StartTrayMenuItm";
			this.StartTrayMenuItm.Size = new System.Drawing.Size(142, 22);
			this.StartTrayMenuItm.Text = "&Start Hotspot";
			//
			//StopTrayMenuItm
			//
			this.StopTrayMenuItm.Name = "StopTrayMenuItm";
			this.StopTrayMenuItm.Size = new System.Drawing.Size(142, 22);
			this.StopTrayMenuItm.Text = "St&op Hotspot";
			//
			//OpenAppTrayMenuItm
			//
			this.OpenAppTrayMenuItm.Name = "OpenAppTrayMenuItm";
			this.OpenAppTrayMenuItm.Size = new System.Drawing.Size(142, 22);
			this.OpenAppTrayMenuItm.Text = "Open &Application";
			//
			//ExitTrayMenuItm
			//
			this.ExitTrayMenuItm.Name = "ExitTrayMenuItm";
			this.ExitTrayMenuItm.Size = new System.Drawing.Size(142, 22);
			this.ExitTrayMenuItm.Text = "&Exit";
			//
			//ConsoleThread
			//
			//
			//MainDialogToolTip
			//
			this.MainDialogToolTip.BackColor = System.Drawing.Color.White;
			//
			//passwordTextBox
			//
			this.passwordTextBox.Location = new System.Drawing.Point(145, 49);
			this.passwordTextBox.MaxLength = 64;
			this.passwordTextBox.Name = "passwordTextBox";
			this.passwordTextBox.PasswordChar = (char)9679;
			this.passwordTextBox.Size = new System.Drawing.Size(197, 20);
			this.passwordTextBox.TabIndex = 2;
			this.MainDialogToolTip.SetToolTip(this.passwordTextBox, "Password must be with in 64 characters" + "\r" + "\n" + "and a minimum length of 8 characters!");
			//
			//ssidTextBox
			//
			this.ssidTextBox.Location = new System.Drawing.Point(145, 14);
			this.ssidTextBox.MaxLength = 32;
			this.ssidTextBox.Name = "ssidTextBox";
			this.ssidTextBox.Size = new System.Drawing.Size(305, 20);
			this.ssidTextBox.TabIndex = 1;
			this.MainDialogToolTip.SetToolTip(this.ssidTextBox, "SSID must be with in 32 characters" + "\r" + "\n" + "and a minimum length of 1 characters!");
			//
			//connectionComboBox
			//
			this.connectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.connectionComboBox.FormattingEnabled = true;
			this.connectionComboBox.Location = new System.Drawing.Point(145, 86);
			this.connectionComboBox.Name = "connectionComboBox";
			this.connectionComboBox.Size = new System.Drawing.Size(270, 21);
			this.connectionComboBox.Sorted = true;
			this.connectionComboBox.TabIndex = 5;
			this.MainDialogToolTip.SetToolTip(this.connectionComboBox, "Select a network to be shared from the list" + "\r" + "\n" + "if you want to create a lan and not " + "to share" + "\r" + "\n" + "any existing network's internet connection" + "\r" + "\n" + "select local lan from the " + "list");
			//
			//refreshConnectionButton
			//
			this.refreshConnectionButton.BackgroundImage = (System.Drawing.Image)resources.GetObject("refreshConnectionButton.BackgroundImage");
			this.refreshConnectionButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.refreshConnectionButton.Location = new System.Drawing.Point(418, 85);
			this.refreshConnectionButton.Margin = new System.Windows.Forms.Padding(0);
			this.refreshConnectionButton.Name = "refreshConnectionButton";
			this.refreshConnectionButton.Size = new System.Drawing.Size(32, 23);
			this.refreshConnectionButton.TabIndex = 4;
			this.refreshConnectionButton.UseVisualStyleBackColor = true;
			//
			//startButton
			//
			this.startButton.Location = new System.Drawing.Point(377, 127);
			this.startButton.Name = "startButton";
			this.startButton.Size = new System.Drawing.Size(73, 23);
			this.startButton.TabIndex = 6;
			this.startButton.Text = "&Start";
			this.startButton.UseVisualStyleBackColor = true;
			//
			//connectionLabel
			//
			this.connectionLabel.AutoSize = true;
			this.connectionLabel.Location = new System.Drawing.Point(21, 89);
			this.connectionLabel.Name = "connectionLabel";
			this.connectionLabel.Size = new System.Drawing.Size(104, 13);
			this.connectionLabel.TabIndex = 0;
			this.connectionLabel.Text = "Shared Connection: ";
			//
			//passwordLabel
			//
			this.passwordLabel.AutoSize = true;
			this.passwordLabel.Location = new System.Drawing.Point(21, 52);
			this.passwordLabel.Name = "passwordLabel";
			this.passwordLabel.Size = new System.Drawing.Size(59, 13);
			this.passwordLabel.TabIndex = 0;
			this.passwordLabel.Text = "Password: ";
			//
			//ssidLabel
			//
			this.ssidLabel.AutoSize = true;
			this.ssidLabel.Location = new System.Drawing.Point(21, 17);
			this.ssidLabel.Name = "ssidLabel";
			this.ssidLabel.Size = new System.Drawing.Size(118, 13);
			this.ssidLabel.TabIndex = 0;
			this.ssidLabel.Text = "Network Name (SSID): ";
			//
			//ShowPasswordChkBox
			//
			this.ShowPasswordChkBox.AutoSize = true;
			this.ShowPasswordChkBox.Location = new System.Drawing.Point(348, 52);
			this.ShowPasswordChkBox.Name = "ShowPasswordChkBox";
			this.ShowPasswordChkBox.Size = new System.Drawing.Size(102, 17);
			this.ShowPasswordChkBox.TabIndex = 3;
			this.ShowPasswordChkBox.Text = "Show Password";
			this.ShowPasswordChkBox.UseVisualStyleBackColor = true;
			//
			//StatusLbl
			//
			this.StatusLbl.AutoSize = true;
			this.StatusLbl.Location = new System.Drawing.Point(21, 132);
			this.StatusLbl.Name = "StatusLbl";
			this.StatusLbl.Size = new System.Drawing.Size(0, 13);
			this.StatusLbl.TabIndex = 0;
			//
			//CurrentRegistryWriteThread
			//
			//
			//IcsRefreshThread
			//
			//
			//IcsConnectThread
			//
			//
			//MainDialog
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(469, 171);
			this.Controls.Add(this.StatusLbl);
			this.Controls.Add(this.ShowPasswordChkBox);
			this.Controls.Add(this.refreshConnectionButton);
			this.Controls.Add(this.connectionComboBox);
			this.Controls.Add(this.startButton);
			this.Controls.Add(this.connectionLabel);
			this.Controls.Add(this.passwordLabel);
			this.Controls.Add(this.ssidLabel);
			this.Controls.Add(this.passwordTextBox);
			this.Controls.Add(this.ssidTextBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.HelpButton = true;
			this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(485, 210);
			this.MinimumSize = new System.Drawing.Size(485, 210);
			this.Name = "MainDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "WLAN Hotspot Creator";
			((System.ComponentModel.ISupportInitialize)this.VisualStyler).EndInit();
			this.TrayMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

//INSTANT C# NOTE: Converted design-time event handler wireups:
			IcsRefreshThread.DoWork += new System.ComponentModel.DoWorkEventHandler(IcsRefreshThread_DoWork);
			base.Load += new System.EventHandler(MainDialog_Load);
			ShowPasswordChkBox.Click += new System.EventHandler(ShowPasswordChkBox_Click);
			IcsConnectThread.DoWork += new System.ComponentModel.DoWorkEventHandler(IcsConnectThread_DoWork);
			CurrentRegistryWriteThread.DoWork += new System.ComponentModel.DoWorkEventHandler(CurrentRegistryWriteThread_DoWork);
			ConsoleThread.DoWork += new System.ComponentModel.DoWorkEventHandler(ConsoleThread_DoWork);
			startButton.Click += new System.EventHandler(startButton_Click);
			refreshConnectionButton.Click += new System.EventHandler(refreshConnectionButton_Click);
			this.HelpButtonClicked += new CancelEventHandler(MainDialog_HelpButtonClicked);
			//this.Closing += new FormClosingEventHandler(MainDialog_Closing);
			this.Closed += new System.EventHandler(MainDialog_Closed);
			this.Resize += new System.EventHandler(MainDialog_Resize);
			this.VisibleChanged += new System.EventHandler(MainDialog_VisibleChanged);
			this.SizeChanged += new System.EventHandler(MainDialog_SizeChanged);
		}

		internal SkinSoft.VisualStyler.VisualStyler VisualStyler;
		private Button refreshConnectionButton;
		private ComboBox connectionComboBox;
		private Label connectionLabel;
		private Label passwordLabel;
		private Label ssidLabel;
		private ToolTip MainDialogToolTip;
		private NotifyIcon AppTray;
		private ToolStripMenuItem StartTrayMenuItm;
		private ToolStripMenuItem StopTrayMenuItm;
		private ToolStripMenuItem OpenAppTrayMenuItm;
		private ToolStripMenuItem ExitTrayMenuItm;
		internal Label StatusLbl;
		internal CheckBox ShowPasswordChkBox;
		private System.ComponentModel.BackgroundWorker CurrentRegistryWriteThread;
		public Button startButton;
		public TextBox passwordTextBox;
		public TextBox ssidTextBox;
		private ContextMenuStrip TrayMenuStrip;
		private System.ComponentModel.BackgroundWorker IcsRefreshThread;
		private System.ComponentModel.BackgroundWorker IcsConnectThread;
		private System.ComponentModel.BackgroundWorker ConsoleThread;
	}

}