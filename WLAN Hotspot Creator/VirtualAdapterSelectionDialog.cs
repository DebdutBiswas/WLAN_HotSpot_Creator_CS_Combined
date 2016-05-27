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
	public partial class VirtualAdapterSelectionDialog
	{
		internal VirtualAdapterSelectionDialog()
		{
			InitializeComponent();
		}

		private void VirtualAdapterSelectionDialog_Load(object sender, EventArgs e)
		{

			IcsVirtualAdapterIdComboBox.Items.Clear();

			foreach (string IcsVirtualAdapter in MainModule.IcsVirtualAdapterIdArray.Items)
			{
				IcsVirtualAdapterIdComboBox.Items.Add(IcsVirtualAdapter);
			}

			IcsVirtualAdapterIdComboBox.SelectedIndex = 0;

		}

		private void selectButton_Click(object sender, EventArgs e)
		{

			MainModule.IcsVirtualAdapterId = IcsVirtualAdapterIdComboBox.SelectedItem.ToString();
			this.Close();

		}

	}
}