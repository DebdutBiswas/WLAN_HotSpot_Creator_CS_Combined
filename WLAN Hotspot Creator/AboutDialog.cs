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
	public sealed partial class AboutDialog
	{

		internal AboutDialog()
		{
			InitializeComponent();
		}

		private void AboutDialog_Load(object sender, System.EventArgs e)
		{
			// Initialize all of the text displayed on the About Box.
			// TODO: Customize the application's assembly information in the "Application" pane of the project 
			//    properties dialog (under the "Project" menu).
			this.LabelProductName.Text = My.MyApplication.Application.Info.ProductName;
			this.LabelVersion.Text = string.Format("Version {0}", My.MyApplication.Application.Info.Version.ToString());
			this.LabelCopyright.Text = My.MyApplication.Application.Info.Copyright;
			this.LabelCompanyName.Text = My.MyApplication.Application.Info.CompanyName;
			this.TextBoxDescription.Text = My.MyApplication.Application.Info.Description;
		}

		private void OKButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

	}

}