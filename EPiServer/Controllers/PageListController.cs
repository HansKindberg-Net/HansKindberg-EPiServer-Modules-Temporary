using System.Web.Mvc;
using EPiServer;
using HansKindberg.EPiServer.Modules.TestApplication.Models.Pages;
using HansKindberg.EPiServer.Modules.TestApplication.Models.ViewModels;

namespace HansKindberg.EPiServer.Modules.TestApplication.Controllers
{
	public class PageListController : SitePageDataController<PageList>
	{
		#region Constructors

		public PageListController(IViewModelFactory viewModelFactory) : base(viewModelFactory) {}

		#endregion

		#region Methods

		public virtual ActionResult Index()
		{
			var model = this.ViewModelFactory.CreateViewModel<PageListViewModel>();

			return this.View(this.GetViewPath(model.CurrentPage.GetOriginalType()), model);
		}

		#endregion
	}
}