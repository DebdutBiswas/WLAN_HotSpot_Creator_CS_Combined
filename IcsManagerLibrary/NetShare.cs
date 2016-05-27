//INSTANT C# NOTE: Formerly VB project-level imports:
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Data;
using System;

using NETCONLib;

namespace IcsManagerLibrary
{
	public class NetShare
	{

		public INetConnection SharedConnection;

		public INetConnection HomeConnection;

		public NetShare(INetConnection sharedConnection, INetConnection homeConnection)
		{
			this.SharedConnection = sharedConnection;
			this.HomeConnection = homeConnection;
		}

		public bool Exists
		{
			get
			{
				return (SharedConnection != null) && (HomeConnection != null);
			}
		}

		public override string ToString()
		{
			return string.Format("{0} -> {1}", SharedConnection, HomeConnection);
		}

	}

}
