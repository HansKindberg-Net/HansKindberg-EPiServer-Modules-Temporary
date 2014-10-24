using System;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using HansKindberg.EPiServer.Shell.Modules.IoC;
using StructureMap;

namespace HansKindberg.EPiServer.Shell.Modules.Initialization
{
	[InitializableModule]
	public class Bootstrapper : IConfigurableModule
	{
		#region Methods

		public virtual void ConfigureContainer(ServiceConfigurationContext context)
		{
			if(context == null)
				throw new ArgumentNullException("context");

			context.Container.Configure(this.ConfigureContainer);
		}

		protected internal virtual void ConfigureContainer(ConfigurationExpression configurationExpression)
		{
			if(configurationExpression == null)
				throw new ArgumentNullException("configurationExpression");

			Registry.Register(configurationExpression);
		}

		public virtual void Initialize(InitializationEngine context) {}
		public virtual void Preload(string[] parameters) {}
		public virtual void Uninitialize(InitializationEngine context) {}

		#endregion
	}
}