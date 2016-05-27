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
	internal static class MainModule
	{

		public static ComboBox IcsVirtualAdapterIdArray = new ComboBox();
		public static string IcsVirtualAdapterId;
		public static void Main()
		{

			Application.Run(new TrayStartUp());

		}

	}

}