using System.Web.Mvc;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.Configuration
{
	public class FilterConfiguration : IApplicationConfiguration
	{
		#region Methods

		public void Configure()
		{
			this.RegisterFilters(GlobalFilters.Filters);
		}

		protected internal virtual void RegisterFilters(GlobalFilterCollection filters)
		{
			filters = filters;
		}

		#endregion
	}
}