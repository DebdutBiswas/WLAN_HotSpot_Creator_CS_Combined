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
	[Cmdlet(VerbsCommon.Get, "NetworkConnections")]
	public class Get_NetworkConnections : PSCmdlet
	{
		protected override void ProcessRecord()
		{
			foreach (var nic in IcsManager.GetIPv4EthernetAndWirelessInterfaces())
			{
				var connection = IcsManager.GetConnectionById(nic.Id);
				var properties = IcsManager.GetProperties(connection);
				var configuration = IcsManager.GetConfiguration(connection);
				var record = new {Name = nic.Name, GUID = nic.Id, MAC = nic.GetPhysicalAddress(), Description = nic.Description, SharingEnabled = configuration.SharingEnabled, NetworkAdapter = nic, Configuration = configuration, Properties = properties};
				WriteObject(record);
			}
		}
	}
}
