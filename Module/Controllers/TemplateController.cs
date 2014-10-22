using EPiServer.PlugIn;
using HansKindberg.EPiServer.Modules.Web.Mvc.Models;

namespace HansKindberg.EPiServer.Modules.ModuleTemplate.Controllers
{
	[GuiPlugIn(Area = PlugInArea.AdminMenu)]
	public class TemplateController : Controller
	{
		#region Constructors

		public TemplateController(IModelFactory modelFactory) : base(modelFactory) {}

		#endregion
	}
}