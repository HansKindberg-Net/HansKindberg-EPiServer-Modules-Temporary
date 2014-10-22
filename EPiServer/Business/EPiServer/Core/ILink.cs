using System.Diagnostics.CodeAnalysis;
using EPiServer.Core;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Core
{
	public interface ILink
	{
		#region Properties

		PageShortcutType LinkType { get; set; }

		[SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
		string LinkUrl { get; set; }

		ContentReference ShortcutLink { get; }
		string TargetFrameName { get; }

		#endregion
	}
}