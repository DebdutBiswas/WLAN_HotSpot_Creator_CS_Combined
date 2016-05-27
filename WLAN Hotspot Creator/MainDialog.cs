//INSTANT C# NOTE: The following line has been modified since C# non-aliased 'using' statements only operate on namespaces:
//ORIGINAL LINE: Imports WLANHotspotCreator.TrayStartUp

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
	public partial class MainDialog
	{

		internal MainDialog()
		{
			InitializeComponent();
		}

		public string SysPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
		public string CommandSeperator = "&&";

		private void StartUpRegistryCheck()
		{

			bool SSID_Val_Status = false;
			SSID_Val_Status = true;
			bool Key_Val_Status = false;
			Key_Val_Status = true;
			//----------------------------------------------------------------------------------------------
			RegistryKey WLANHotspotSSIDRegKey = null;
			WLANHotspotSSIDRegKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WLANHotspot", true);

			string SSID = null;
			try
			{
				SSID = WLANHotspotSSIDRegKey.GetValue("SSID").ToString();
				if (SSID.LongCount() > 0 && SSID.LongCount() <= 32)
				{
					ssidTextBox.Text = SSID;
				}
				else
				{
					MessageBox.Show("Registry value for: SSID must be between 1 to 32 character.", "Registry Value Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					ssidTextBox.Text = "MyHotspot";
					try
					{
						WLANHotspotSSIDRegKey.SetValue("SSID", "MyHotspot");
						WLANHotspotSSIDRegKey.Close();
						StatusLbl.Text = "Status: Default SSID is written!";
					}
					catch
					{
						MessageBox.Show("Unable to write default registry value for: SSID", "Registry Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
			catch
			{
				MessageBox.Show("Unable to read registry value for: SSID", "Registry Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				ssidTextBox.Text = "MyHotspot";
				try
				{
					WLANHotspotSSIDRegKey.SetValue("SSID", "MyHotspot");
					WLANHotspotSSIDRegKey.Close();
					StatusLbl.Text = "Status: Default SSID is written!";
				}
				catch
				{
					SSID_Val_Status = false;
					MessageBox.Show("Unable to write default registry value for: SSID", "Registry Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			//----------------------------------------------------------------------------------------------
			RegistryKey WLANHotspotKeyRegKey = null;
			WLANHotspotKeyRegKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WLANHotspot", true);

			string Key = null;
			try
			{
				Key = WLANHotspotKeyRegKey.GetValue("Key").ToString();
				if (Key.LongCount() >= 8 && Key.LongCount() <= 64)
				{
					passwordTextBox.Text = Key;
				}
				else
				{
					MessageBox.Show("Registry value for: Key must be between 8 to 64 character.", "Registry Value Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					passwordTextBox.Text = "12345678";
					try
					{
						WLANHotspotKeyRegKey.SetValue("Key", "12345678");
						WLANHotspotKeyRegKey.Close();
						StatusLbl.Text = "Status: Default Key is written!";
					}
					catch
					{
						MessageBox.Show("Unable to write default registry value for: Key", "Registry Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
			catch
			{
				MessageBox.Show("Unable to read registry value for: Key", "Registry Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				passwordTextBox.Text = "12345678";
				try
				{
					WLANHotspotKeyRegKey.SetValue("Key", "12345678");
					WLANHotspotKeyRegKey.Close();
					StatusLbl.Text = "Status: Default Key is written!";
				}
				catch
				{
					Key_Val_Status = false;
					MessageBox.Show("Unable to write default registry value for: Key", "Registry Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

			if (SSID_Val_Status == false || Key_Val_Status == false)
			{
				RegistryKey WLANHotspotRepairRegistry = null;
				try
				{
					WLANHotspotRepairRegistry = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WLANHotspot");
					WLANHotspotRepairRegistry.SetValue("SSID", "MyHotspot", RegistryValueKind.String);
					WLANHotspotRepairRegistry.SetValue("Key", "12345678", RegistryValueKind.String);
					WLANHotspotRepairRegistry.Close();
					StatusLbl.Text = "Status: Application registry error repaired!";
				}
				catch
				{
					MessageBox.Show("Unable to repair application default registry!", "Registry Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}


		}

		private void GetIcsAdapters()
		{

			connectionComboBox.Items.Clear();

			ManagementScope InternetShareableAdapterScope = new ManagementScope();
			SelectQuery InternetShareableAdapterQuery = new SelectQuery("Win32_NetworkAdapter", "NetConnectionStatus=2");
			ManagementObjectSearcher InternetShareableAdapterSearcher = new ManagementObjectSearcher(InternetShareableAdapterScope, InternetShareableAdapterQuery);

			try
			{
				foreach (ManagementObject InternetShareableAdapter in InternetShareableAdapterSearcher.Get())
				{
					string InternetShareableAdapterId = InternetShareableAdapter["NetConnectionID"].ToString();

					connectionComboBox.Items.Add(InternetShareableAdapterId);

				}
			}
			catch
			{
			}

			if (connectionComboBox.Items.Count == 0)
			{
				connectionComboBox.Items.Add("No connection Avilable!");
			}

			connectionComboBox.SelectedIndex = 0;

		}

		private void IcsRefreshThread_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{

			refreshConnectionButton.Enabled = false;
			GetIcsAdapters();
			refreshConnectionButton.Enabled = true;

		}

		private void MainDialog_Load(object sender, EventArgs e)
		{

			//CheckForIllegalCrossThreadCalls = False

			if (!(System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\netsh.exe")))
			{
				MessageBox.Show("netsh.exe Not found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Close();
			}
			else
			{
				AppTray.Visible = true;
				StartUpRegistryCheck();
				if (startButton.Text == "&Start")
				{
					IcsRefreshThread.RunWorkerAsync();
				}
			}

		}

		private void ShowPasswordChkBox_Click(object sender, EventArgs e)
		{

			if (ShowPasswordChkBox.CheckState == CheckState.Checked)
			{
				passwordTextBox.PasswordChar = '\0';
			}
			else if (ShowPasswordChkBox.CheckState == CheckState.Unchecked)
			{
				passwordTextBox.PasswordChar = '●';
			}

		}

		public void EnableUserInterface()
		{

			ssidTextBox.Enabled = true;
			passwordTextBox.Enabled = true;
			ShowPasswordChkBox.Enabled = true;
			connectionComboBox.Enabled = true;
			refreshConnectionButton.Enabled = true;

		}

		public void DisableUserInterface()
		{

			ssidTextBox.Enabled = false;
			passwordTextBox.Enabled = false;
			ShowPasswordChkBox.Enabled = false;
			connectionComboBox.Enabled = false;
			refreshConnectionButton.Enabled = false;

		}

		public void TrayStartingStatus()
		{

			AppTray.Icon = Properties.Resources.connection_icon_blue;
			AppTray.BalloonTipIcon = ToolTipIcon.Info;
			AppTray.BalloonTipTitle = "WiFi Hotspot Status";
			AppTray.BalloonTipText = "Creating Hotspot...";
			AppTray.ShowBalloonTip(500);

		}

		public void TrayStartedStatus()
		{

			AppTray.Icon = Properties.Resources.connection_icon_green;
			AppTray.BalloonTipIcon = ToolTipIcon.Info;
			AppTray.BalloonTipTitle = "WiFi Hotspot Status";
			AppTray.BalloonTipText = "Hotspot Started...";
			AppTray.ShowBalloonTip(500);

		}

		public void TrayStoppingStatus()
		{

			AppTray.Icon = Properties.Resources.connection_icon_yellow;
			AppTray.BalloonTipIcon = ToolTipIcon.Info;
			AppTray.BalloonTipTitle = "WiFi Hotspot Status";
			AppTray.BalloonTipText = "Stopping Hotspot...";
			AppTray.ShowBalloonTip(500);

		}

		public void TrayStoppedStatus()
		{

			AppTray.Icon = Properties.Resources.connection_icon_red;
			AppTray.BalloonTipIcon = ToolTipIcon.Info;
			AppTray.BalloonTipTitle = "WiFi Hotspot Status";
			AppTray.BalloonTipText = "Hotspot Stopped...";
			AppTray.ShowBalloonTip(500);

		}

		public void TrayErrorStatus()
		{

			AppTray.Icon = Properties.Resources.connection_icon_red;
			AppTray.BalloonTipIcon = ToolTipIcon.Info;
			AppTray.BalloonTipTitle = "WiFi Hotspot Status";
			AppTray.BalloonTipText = "Hotspot couldn't be started...";
			AppTray.ShowBalloonTip(500);

		}

		private void ConnectIcs()
		{

			if (connectionComboBox.SelectedItem.ToString() == "No connection Avilable!")
			{
				StatusLbl.Text = "Status: Hotspot started without ICS!";
				startButton.Text = "&Stop";
				startButton.Enabled = true;
			}
			else
			{
				StatusLbl.Text = "Status: Trying to create ICS with " + connectionComboBox.SelectedItem.ToString() + ".";

				//------------------------------------------------------------------------------------------------------
				ManagementScope IcsVirtualAdapterScope = new ManagementScope();
				SelectQuery IcsVirtualAdapterQuery = new SelectQuery("Win32_NetworkAdapter", "Description=\"Microsoft Hosted Network Virtual Adapter\"");
				ManagementObjectSearcher IcsVirtualAdapterSearcher = new ManagementObjectSearcher(IcsVirtualAdapterScope, IcsVirtualAdapterQuery);
				//Dim IcsVirtualAdapterIdArray As New ComboBox

				try
				{
					foreach (ManagementObject IcsVirtualAdapter in IcsVirtualAdapterSearcher.Get())
					{
						string IcsVirtualAdapterId = IcsVirtualAdapter["NetConnectionID"].ToString();
						MainModule.IcsVirtualAdapterIdArray.Items.Add(IcsVirtualAdapterId);
					}
				}
				catch
				{

				}

				if (MainModule.IcsVirtualAdapterIdArray.Items.Count > 1)
				{
					VirtualAdapterSelectionDialog.DefaultInstance.ShowDialog();
				}
				else
				{
					MainModule.IcsVirtualAdapterIdArray.SelectedIndex = 0;
					MainModule.IcsVirtualAdapterId = MainModule.IcsVirtualAdapterIdArray.SelectedItem.ToString();
				}

				MainModule.IcsVirtualAdapterIdArray.Items.Clear();
				StatusLbl.Text = "Status: Selected virtual adapter: " + MainModule.IcsVirtualAdapterId + ".";
				//------------------------------------------------------------------------------------------------------

				try
				{
					IcsManager.ShareConnection(IcsManager.GetConnectionByName(connectionComboBox.SelectedItem.ToString()), IcsManager.GetConnectionByName(MainModule.IcsVirtualAdapterId));
					StatusLbl.Text = "Status: Shared internet from " + connectionComboBox.SelectedItem.ToString() + " to " + MainModule.IcsVirtualAdapterId.ToString() + ".";
					startButton.Text = "&Stop";
					startButton.Enabled = true;
				}
				catch
				{
					StatusLbl.Text = "Status: Network shell busy, retrying ICS with " + connectionComboBox.SelectedItem.ToString() + ".";
					//startButton.Text = "&Stop"
					//startButton.Enabled = True
					System.Threading.Thread.Sleep(1000);
					ConnectIcs();
				}

			}

		}

		private void IcsConnectThread_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{

			ConnectIcs();

		}

		private void ConnectFunction()
		{

			startButton.Enabled = false;

			bool ConnectionCriteria = false;
			ConnectionCriteria = false;

			if (ssidTextBox.Text.LongCount() > 0 && passwordTextBox.Text.LongCount() > 7)
			{
				ConnectionCriteria = true;
			}
			else
			{
				ConnectionCriteria = false;
			}

			if (ConnectionCriteria == true)
			{

				StatusLbl.Text = "Status: Trying to create hotspot!";
				DisableUserInterface();
				TrayStartingStatus();

                CurrentRegistryWriteThread.RunWorkerAsync();

                string SSID = null;
				SSID = "\"" + ssidTextBox.Text + "\"";

				string PSWD = null;
				PSWD = "\"" + passwordTextBox.Text + "\"";

				//Dim SysPath As String
				//SysPath = Environment.GetFolderPath(Environment.SpecialFolder.System)

				//Dim CommandSeperator As String
				//CommandSeperator = "&&"

				if (System.IO.File.Exists(SysPath + "\\netsh.exe"))
				{
					var ConnectionProcess = new Process();
					ConnectionProcess.StartInfo.FileName = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\cmd.exe";
					ConnectionProcess.StartInfo.Arguments = "/k echo off" + CommandSeperator + SysPath + "\\netsh.exe wlan set hostednetwork mode=allow ssid=" + SSID + " key=" + PSWD + CommandSeperator + SysPath + "\\netsh.exe  wlan start hostednetwork";
					ConnectionProcess.StartInfo.UseShellExecute = false;
					ConnectionProcess.StartInfo.CreateNoWindow = true;
					ConnectionProcess.StartInfo.RedirectStandardOutput = true;
					ConnectionProcess.StartInfo.RedirectStandardError = true;
					ConnectionProcess.Start();
					ConnectionProcess.WaitForExit(4000);
					if (!ConnectionProcess.HasExited)
					{
						ConnectionProcess.Kill();
						System.IO.StreamReader SuccessOutPut = ConnectionProcess.StandardOutput;
						System.IO.StreamReader ErrorOutPut = ConnectionProcess.StandardError;
						string ProcessSuccess = null;
						string ProcessError = null;
						ProcessSuccess = SuccessOutPut.ReadToEnd();
						ProcessError = ErrorOutPut.ReadToEnd();
						if (string.IsNullOrEmpty(ProcessError))
						{
							if (ProcessSuccess.Contains("The hosted network couldn't be started"))
							{
								StatusLbl.Text = "Status: Hotspot couldn't be started!";
								EnableUserInterface();
								startButton.Enabled = true;
								TrayErrorStatus();
							}
							else if (ProcessSuccess.Contains("The hosted network started"))
							{
								StatusLbl.Text = "Status: Hotspot started!";
								IcsConnectThread.RunWorkerAsync();
								//startButton.Text = "&Stop"
								//startButton.Enabled = True
								TrayStartedStatus();
							}
						}
						else
						{
							EnableUserInterface();
							MessageBox.Show(ProcessError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
						SuccessOutPut.Close();
						ErrorOutPut.Close();
						ConnectionProcess.Close();
					}

				}
				else
				{
					MessageBox.Show("netsh.exe Not found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

			}
			else
			{
				StatusLbl.Text = "Status: Check given SSID and Password!";
				startButton.Enabled = true;
			}

		}

		private void DisconnectFunction()
		{

			startButton.Enabled = false;

			StatusLbl.Text = "Status: Trying to stop hotspot!";
			TrayStoppingStatus();

			IcsManager.ShareConnection(null, null);

			//Dim SysPath As String
			//SysPath = Environment.GetFolderPath(Environment.SpecialFolder.System)

			//Dim CommandSeperator As String
			//CommandSeperator = "&&"

			if (System.IO.File.Exists(SysPath + "\\netsh.exe"))
			{
				var ConnectionProcess = new Process();
				ConnectionProcess.StartInfo.FileName = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\cmd.exe";
				ConnectionProcess.StartInfo.Arguments = "/k echo off" + CommandSeperator + SysPath + "\\netsh.exe  wlan stop hostednetwork";
				ConnectionProcess.StartInfo.UseShellExecute = false;
				ConnectionProcess.StartInfo.CreateNoWindow = true;
				ConnectionProcess.StartInfo.RedirectStandardOutput = true;
				ConnectionProcess.StartInfo.RedirectStandardError = true;
				ConnectionProcess.Start();
				ConnectionProcess.WaitForExit(4000);
				if (!ConnectionProcess.HasExited)
				{
					ConnectionProcess.Kill();
					System.IO.StreamReader SuccessOutPut = ConnectionProcess.StandardOutput;
					System.IO.StreamReader ErrorOutPut = ConnectionProcess.StandardError;
					string ProcessSuccess = null;
					string ProcessError = null;
					ProcessSuccess = SuccessOutPut.ReadToEnd();
					ProcessError = ErrorOutPut.ReadToEnd();
					if (string.IsNullOrEmpty(ProcessError))
					{
						if (ProcessSuccess.Contains("The hosted network stopped"))
						{
							StatusLbl.Text = "Status: Hotspot stopped!";
							EnableUserInterface();
							IcsRefreshThread.RunWorkerAsync();
							startButton.Text = "&Start";
							startButton.Enabled = true;
							TrayStoppedStatus();
						}
					}
					else
					{
						EnableUserInterface();
						MessageBox.Show(ProcessError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					SuccessOutPut.Close();
					ErrorOutPut.Close();
					ConnectionProcess.Close();
				}

			}
			else
			{
				MessageBox.Show("netsh.exe Not found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private void WriteCurrentConfigToRegistry()
		{

			RegistryKey WLANHotspotWriteRegKey = null;
			try
			{
				WLANHotspotWriteRegKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WLANHotspot", true);
				if (!(ssidTextBox.Text == WLANHotspotWriteRegKey.GetValue("SSID").ToString()))
				{
					WLANHotspotWriteRegKey.SetValue("SSID", ssidTextBox.Text);
				}
				//------------------------------------------------------------------------------------------------
				if (!(passwordTextBox.Text == WLANHotspotWriteRegKey.GetValue("Key").ToString()))
				{
					WLANHotspotWriteRegKey.SetValue("Key", passwordTextBox.Text);
				}
			}
			catch
			{
				StartUpRegistryCheck();
			}

		}

		private void CurrentRegistryWriteThread_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{

			WriteCurrentConfigToRegistry();

		}

		private void ConsoleThread_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{

			if (startButton.Text == "&Start")
			{
				ConnectFunction();
			}
			else if (startButton.Text == "&Stop")
			{
				DisconnectFunction();
			}

		}

		private void startButton_Click(object sender, EventArgs e)
		{

			ConsoleThread.RunWorkerAsync();

		}

		private void refreshConnectionButton_Click(object sender, EventArgs e)
		{

			IcsRefreshThread.RunWorkerAsync();

		}

		private void MainDialog_HelpButtonClicked(object sender, CancelEventArgs e)
		{

			AboutDialog.DefaultInstance.ShowDialog();

		}

		private void MainDialog_Closing(object sender, FormClosingEventArgs e)
		{

			if (e.CloseReason == CloseReason.UserClosing)
			{
				e.Cancel = true;
				this.Visible = false;
			}

		}

		//Public c1 As TrayStartUp
		private void MainDialog_Closed(object sender, EventArgs e)
		{

			//c1.TrayAppStartedStatus()

		}

		private void MainDialog_Resize(object sender, EventArgs e)
		{

			//If Me.WindowState = FormWindowState.Minimized Then
			//Me.Hide()
			//End If

		}

		private void MainDialog_VisibleChanged(object sender, EventArgs e)
		{

			if (this.Visible == false)
			{
				AppTray.Visible = false;
			}
			else if (this.Visible == true)
			{
				AppTray.Visible = true;
			}

		}

		private void MainDialog_SizeChanged(object sender, EventArgs e)
		{

			this.Width = 485;
			this.Height = 210;

		}


		private static MainDialog _DefaultInstance;
		public static MainDialog DefaultInstance
		{
			get
			{
				if (_DefaultInstance == null)
					_DefaultInstance = new MainDialog();

				return _DefaultInstance;
			}
		}
	}

}