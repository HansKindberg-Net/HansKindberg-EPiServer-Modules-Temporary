using System;
using System.Web.Mvc;
using System.Xml;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using HansKindberg.EPiServer.Modules.TestApplication.Business.Configuration;
using HansKindberg.EPiServer.Modules.TestApplication.Business.IoC;
using StructureMap;
using StructureMap.Configuration;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.Initialization
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

			DependencyResolver.SetResolver(new StructureMapDependencyResolver(context.Container));

			foreach(var applicationConfiguration in context.Container.GetAllInstances<IApplicationConfiguration>())
			{
				applicationConfiguration.Configure();
			}
		}

		protected internal virtual void ConfigureContainer(ConfigurationExpression configurationExpression)
		{
			if(configurationExpression == null)
				throw new ArgumentNullException("configurationExpression");

			foreach(XmlNode xmlNode in StructureMapConfigurationSection.GetStructureMapConfiguration())
			{
				configurationExpression.AddConfigurationFromNode(xmlNode);
			}
		}

		public virtual void Initialize(InitializationEngine context) {}
		public virtual void Preload(string[] parameters) {}
		public virtual void Uninitialize(InitializationEngine context) {}

		#endregion
	}
}