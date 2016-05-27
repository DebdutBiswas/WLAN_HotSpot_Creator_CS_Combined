//INSTANT C# NOTE: The following line has been commented since C# non-aliased 'using' statements only operate on namespaces:
//using System.Windows.Forms.Control;


//INSTANT C# NOTE: Formerly VB project-level imports:
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;

namespace WLANHotspotCreator
{
	public class TrayStartUp : ApplicationContext
	{
		public NotifyIcon AppTray = new NotifyIcon();
		private ContextMenuStrip TrayMenuStrip = new ContextMenuStrip();
		private ToolStripMenuItem StartTrayMenuItm = new ToolStripMenuItem("&Start Hotspot");
		private ToolStripMenuItem StopTrayMenuItm = new ToolStripMenuItem("St&op Hotspot");
		private ToolStripMenuItem OpenAppTrayMenuItm = new ToolStripMenuItem("Open &Application");
		private ToolStripMenuItem CloseAppTrayMenuItm = new ToolStripMenuItem("&Close Application");
		private ToolStripMenuItem ExitTrayMenuItm = new ToolStripMenuItem("&Exit");
		private MainDialog MainWindow = new MainDialog();

		public void TrayMenuStripInitialize()
		{

			TrayMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {StartTrayMenuItm, StopTrayMenuItm, OpenAppTrayMenuItm, CloseAppTrayMenuItm, ExitTrayMenuItm});
			TrayMenuStrip.ShowImageMargin = false;
			TrayMenuStrip.Size = new System.Drawing.Size(143, 114);
			CloseAppTrayMenuItm.Visible = false;

		}

		public void AppTrayInitialize()
		{

			TrayMenuStripInitialize();
			AppTray.Text = "WLAN Hotspot Creator";
			AppTray.ContextMenuStrip = TrayMenuStrip;
			AppTray.Visible = true;

		}

		public void TrayAppStartedStatus()
		{

			AppTray.Icon = Properties.Resources.connection_icon_white;
			AppTray.BalloonTipIcon = ToolTipIcon.Info;
			AppTray.BalloonTipTitle = "WiFi Hotspot Status";
			AppTray.BalloonTipText = "Application started...";
			AppTray.ShowBalloonTip(500);

		}

		public TrayStartUp()
		{

			Control.CheckForIllegalCrossThreadCalls = false;

			AppTrayInitialize();
			TrayAppStartedStatus();

			SubscribeToEvents();
		}

		private void AppTray_Click(object sender, EventArgs e)
		{

			if (MainWindow.Visible == true)
			{
				OpenAppTrayMenuItm.Visible = false;
				CloseAppTrayMenuItm.Visible = true;
			}
			else if (MainWindow.Visible == false)
			{
				CloseAppTrayMenuItm.Visible = false;
				OpenAppTrayMenuItm.Visible = true;
			}

		}

		private void OpenAppTrayMenuItm_Click(object sender, EventArgs e)
		{

			if (MainWindow.Visible == false)
			{
				OpenAppTrayMenuItm.Visible = false;
				CloseAppTrayMenuItm.Visible = true;
				MainWindow.ShowDialog();
			}

		}

		private void CloseAppTrayMenuItm_Click(object sender, EventArgs e)
		{

			if (MainWindow.Visible == true)
			{
				CloseAppTrayMenuItm.Visible = false;
				OpenAppTrayMenuItm.Visible = true;
				MainWindow.Visible = false;
			}

		}

		private void ExitTrayMenuItm_Click(object sender, EventArgs e)
		{

			//MsgBox("Do you want to exit application?", MsgBoxStyle.YesNo, "WLAN Hotspot Creator")
			//If Conf.DialogResult = DialogResult.OK Then
			AppTray.Visible = false;
			this.Dispose();
			Application.Exit();
			//If MsgBoxResult.No Then
			//End If
			//End If

		}


//INSTANT C# NOTE: Converted event handler wireups:
		private bool EventsSubscribed = false;
		private void SubscribeToEvents()
		{
			if (EventsSubscribed)
				return;
			else
				EventsSubscribed = true;

			AppTray.Click += AppTray_Click;
			OpenAppTrayMenuItm.Click += OpenAppTrayMenuItm_Click;
			CloseAppTrayMenuItm.Click += CloseAppTrayMenuItm_Click;
			ExitTrayMenuItm.Click += ExitTrayMenuItm_Click;
		}

	}

}