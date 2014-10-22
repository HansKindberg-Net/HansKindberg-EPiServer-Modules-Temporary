using HansKindberg.EPiServer.Modules.TestApplication.Models.Pages;

namespace HansKindberg.EPiServer.Modules.TestApplication.Models.ViewModels
{
	public interface IPageViewModel<out T> : ILayoutViewModel where T : SitePageData
	{
		#region Properties

		T CurrentPage { get; }
		string Heading { get; }

		#endregion
	}
}