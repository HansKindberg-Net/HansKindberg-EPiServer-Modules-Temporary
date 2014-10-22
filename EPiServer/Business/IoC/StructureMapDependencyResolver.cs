using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using log4net;
using StructureMap;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.IoC
{
	public class StructureMapDependencyResolver : IDependencyResolver
	{
		#region Fields

		private readonly IContainer _container;
		private static readonly ILog _log = LogManager.GetLogger(typeof(StructureMapDependencyResolver));

		#endregion

		#region Constructors

		public StructureMapDependencyResolver(IContainer container)
		{
			if(container == null)
				throw new ArgumentNullException("container");

			this._container = container;
		}

		#endregion

		#region Properties

		protected internal virtual IContainer Container
		{
			get { return this._container; }
		}

		#endregion

		#region Methods

		protected internal virtual object GetAbstractService(Type abstractServiceType)
		{
			if(abstractServiceType == null)
				throw new ArgumentNullException("abstractServiceType");

			if(!abstractServiceType.IsAbstract && !abstractServiceType.IsInterface)
				throw new ArgumentException("The service-type is not abstract.", "abstractServiceType");

			return this.Container.TryGetInstance(abstractServiceType);
		}

		protected internal virtual object GetConcreteService(Type concreteServiceType)
		{
			if(concreteServiceType == null)
				throw new ArgumentNullException("concreteServiceType");

			if(concreteServiceType.IsAbstract || concreteServiceType.IsInterface)
				throw new ArgumentException("The service-type is not concrete.", "concreteServiceType");

			try
			{
				return this.Container.GetInstance(concreteServiceType);
			}
			catch(StructureMapException structureMapException)
			{
				if(_log.IsErrorEnabled)
					_log.Error(structureMapException);

				return null;
			}
		}

		public virtual object GetService(Type serviceType)
		{
			if(serviceType == null)
				throw new ArgumentNullException("serviceType");

			if(serviceType.IsAbstract || serviceType.IsInterface)
				return this.GetAbstractService(serviceType);

			return this.GetConcreteService(serviceType);
		}

		public virtual IEnumerable<object> GetServices(Type serviceType)
		{
			return this.Container.GetAllInstances(serviceType).Cast<object>();
		}

		#endregion
	}
}