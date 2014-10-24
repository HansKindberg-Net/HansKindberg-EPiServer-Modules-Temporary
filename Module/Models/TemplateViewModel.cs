using EPiServer.Framework.Localization;
using HansKindberg.EPiServer.Shell.Modules.Web.Mvc.Models;

namespace HansKindberg.EPiServer.Modules.ModuleTemplate.Models
{
	public class TemplateViewModel : LayoutViewModel
	{
		#region Constructors

		public TemplateViewModel(ILayoutModel layout, LocalizationService localizationService) : base(layout, localizationService) {}

		#endregion
	}
}