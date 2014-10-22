using HansKindberg.EPiServer.Modules.TestApplication.Models.Pages;

namespace HansKindberg.EPiServer.Modules.TestApplication.Models.ViewModels
{
	public class StartPageModel : PageViewModel<StartPage>
	{
		#region Constructors

		public StartPageModel(StartPage currentPage, ILayoutModel layout) : base(currentPage, layout) {}

		#endregion
	}
}