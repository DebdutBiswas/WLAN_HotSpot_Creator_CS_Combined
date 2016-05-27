//INSTANT C# NOTE: Formerly VB project-level imports:
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Data;
using System;

using System.Management.Automation;

namespace IcsManagerLibrary
{
	[Cmdlet(VerbsLifecycle.Disable, "ICS")]
	public class Disable_ICS : PSCmdlet
	{
		protected override void ProcessRecord()
		{
			IcsManager.ShareConnection(null, null);
		}
	}
}
