using HansKindberg.EPiServer.Modules.TestApplication.Models.Pages;

namespace HansKindberg.EPiServer.Modules.TestApplication.Models.ViewModels
{
	public interface IViewModelFactory
	{
		#region Methods

		IPageViewModel<SitePageData> CreatePageViewModel();
		T CreateViewModel<T>();

		#endregion
	}
}