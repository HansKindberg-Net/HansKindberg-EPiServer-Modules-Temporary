using System;
using System.IO;
using log4net;
using log4net.Config;

namespace HansKindberg.EPiServer.Modules.TestApplication
{
	public class Global : global::EPiServer.Global
	{
		#region Constructors

		static Global()
		{
			// Check if log4net is configured, if not configure it with "log4net.config".
			if(!LogManager.GetRepository().Configured)
				XmlConfigurator.ConfigureAndWatch(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config"));
		}

		#endregion
	}
}