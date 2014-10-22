using EPiServer.Core;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Core
{
	public interface IContentReferenceRepository
	{
		#region Properties

		ContentReference RootPage { get; }
		ContentReference SiteBlockFolder { get; }
		ContentReference StartPage { get; }
		ContentReference Wastebasket { get; }

		#endregion
	}
}