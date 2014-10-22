using System.Globalization;

namespace HansKindberg.EPiServer.Modules.ModuleTemplate.Models
{
	public interface ILayoutModel
	{
		#region Properties

		string Heading { get; set; }
		string Title { get; set; }
		CultureInfo UiCulture { get; }

		#endregion
	}
}