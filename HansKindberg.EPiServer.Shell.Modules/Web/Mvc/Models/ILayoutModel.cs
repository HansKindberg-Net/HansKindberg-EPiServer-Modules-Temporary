using System;
using System.Collections.Generic;
using System.Globalization;
using EPiServer.Framework.Web.Resources;

namespace HansKindberg.EPiServer.Shell.Modules.Web.Mvc.Models
{
	public interface ILayoutModel : IResourcePathResolver
	{
		#region Properties

		string Description { get; }
		string LocalizationPath { get; set; }
		string Name { get; }
		string Title { get; }
		Type TypeInModuleAssembly { get; set; }
		CultureInfo UiCulture { get; }

		#endregion

		#region Methods

		IEnumerable<ClientResource> GetClientResource(string name);
		IEnumerable<ClientResource> GetClientResource(string name, IEnumerable<ClientResourceType> resourceTypes);

		#endregion
	}
}