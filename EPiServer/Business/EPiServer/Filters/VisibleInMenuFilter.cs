using EPiServer.Core;
using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Core;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Filters
{
	public class VisibleInMenuFilter : ContentFilter
	{
		#region Methods

		public override bool ShouldFilter(IContent content)
		{
			var visibleInMenu = true;

			var navigable = content as INavigable;

			if(navigable != null)
			{
				visibleInMenu = navigable.VisibleInMenu;
			}
			else
			{
				var pageData = content as PageData;

				if(pageData != null)
					visibleInMenu = pageData.VisibleInMenu;
			}

			return !visibleInMenu;
		}

		#endregion
	}
}