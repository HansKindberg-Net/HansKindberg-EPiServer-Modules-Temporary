using System;
using HansKindberg.Collections.Specialized;
using HansKindberg.EPiServer.Shell.Modules.Web.Mvc.Models;
using HansKindberg.Globalization;
using HansKindberg.Web.Collections.Specialized;
using StructureMap.Configuration.DSL;

namespace HansKindberg.EPiServer.Shell.Modules.IoC
{
	public class Registry : StructureMap.Configuration.DSL.Registry
	{
		#region Constructors

		public Registry()
		{
			Register(this);
		}

		#endregion

		#region Methods

		public static void Register(IRegistry registry)
		{
			if(registry == null)
				throw new ArgumentNullException("registry");

			registry.For<ICultureContext>().Singleton().Use<CultureContext>();
			registry.For<ILayoutModel>().HybridHttpOrThreadLocalScoped().Use<LayoutModel>();
			registry.For<INameValueCollectionParser>().Singleton().Use<NameValueCollectionParser>();
			registry.For<IPaths>().Singleton().Use<PathsWrapper>();
			registry.For<IViewModelFactory>().Singleton().Use<ViewModelFactory>();
		}

		#endregion
	}
}