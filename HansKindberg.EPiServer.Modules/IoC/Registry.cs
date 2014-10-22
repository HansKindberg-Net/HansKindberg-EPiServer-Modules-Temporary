using System;
using HansKindberg.EPiServer.Modules.Globalization;
using StructureMap.Configuration.DSL;

namespace HansKindberg.EPiServer.Modules.IoC
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
		}

		#endregion
	}
}