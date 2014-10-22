using System.Web.Mvc;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.Configuration
{
	public class AreaConfiguration : IApplicationConfiguration
	{
		#region Methods

		public virtual void Configure()
		{
			AreaRegistration.RegisterAllAreas();
		}

		#endregion
	}
}