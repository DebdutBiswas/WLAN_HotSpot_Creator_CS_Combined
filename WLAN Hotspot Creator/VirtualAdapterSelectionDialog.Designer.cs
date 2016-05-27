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
	[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	public partial class VirtualAdapterSelectionDialog : System.Windows.Forms.Form
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VirtualAdapterSelectionDialog));
			this.IcsVirtualAdapterIdComboBox = new System.Windows.Forms.ComboBox();
			this.selectButton = new System.Windows.Forms.Button();
			this.SelectConnectionLabel = new System.Windows.Forms.Label();
			this.VisualStyler = new SkinSoft.VisualStyler.VisualStyler(this.components);
			((System.ComponentModel.ISupportInitialize)this.VisualStyler).BeginInit();
			this.SuspendLayout();
			//
			//IcsVirtualAdapterIdComboBox
			//
			this.IcsVirtualAdapterIdComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.IcsVirtualAdapterIdComboBox.FormattingEnabled = true;
			this.IcsVirtualAdapterIdComboBox.Location = new System.Drawing.Point(20, 44);
			this.IcsVirtualAdapterIdComboBox.Name = "IcsVirtualAdapterIdComboBox";
			this.IcsVirtualAdapterIdComboBox.Size = new System.Drawing.Size(270, 21);
			this.IcsVirtualAdapterIdComboBox.Sorted = true;
			this.IcsVirtualAdapterIdComboBox.TabIndex = 8;
			//
			//selectButton
			//
			this.selectButton.Location = new System.Drawing.Point(217, 71);
			this.selectButton.Name = "selectButton";
			this.selectButton.Size = new System.Drawing.Size(73, 23);
			this.selectButton.TabIndex = 9;
			this.selectButton.Text = "&Select";
			this.selectButton.UseVisualStyleBackColor = true;
			//
			//SelectConnectionLabel
			//
			this.SelectConnectionLabel.AutoSize = true;
			this.SelectConnectionLabel.Location = new System.Drawing.Point(17, 15);
			this.SelectConnectionLabel.Name = "SelectConnectionLabel";
			this.SelectConnectionLabel.Size = new System.Drawing.Size(225, 26);
			this.SelectConnectionLabel.TabIndex = 7;
			this.SelectConnectionLabel.Text = "Multiple virtual network adapters are detected!" + "\r" + "\n" + "Select any one from the list: ";
			//
			//VisualStyler
			//
			this.VisualStyler.HostForm = this;
			this.VisualStyler.License = (SkinSoft.VisualStyler.Licensing.VisualStylerLicense)resources.GetObject("VisualStyler.License");
			this.VisualStyler.ShadowStyle = SkinSoft.VisualStyler.ShadowStyle.Medium;
			this.VisualStyler.LoadVisualStyle(null, "XP Royale (Black).vssf");
			//
			//VirtualAdapterSelectionDialog
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(309, 106);
			this.ControlBox = false;
			this.Controls.Add(this.IcsVirtualAdapterIdComboBox);
			this.Controls.Add(this.selectButton);
			this.Controls.Add(this.SelectConnectionLabel);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(325, 145);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(325, 145);
			this.Name = "VirtualAdapterSelectionDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "                  Multiple Virtual Adapter(s)";
			((System.ComponentModel.ISupportInitialize)this.VisualStyler).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

//INSTANT C# NOTE: Converted design-time event handler wireups:
			base.Load += new System.EventHandler(VirtualAdapterSelectionDialog_Load);
			selectButton.Click += new System.EventHandler(selectButton_Click);
		}

		private ComboBox IcsVirtualAdapterIdComboBox;
		public Button selectButton;
		private Label SelectConnectionLabel;
		internal SkinSoft.VisualStyler.VisualStyler VisualStyler;

		private static VirtualAdapterSelectionDialog _DefaultInstance;
		public static VirtualAdapterSelectionDialog DefaultInstance
		{
			get
			{
				if (_DefaultInstance == null)
					_DefaultInstance = new VirtualAdapterSelectionDialog();

				return _DefaultInstance;
			}
		}
	}

}