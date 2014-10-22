using EPiServer.Core;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Core
{
	public class ContentReferenceRepository : IContentReferenceRepository
	{
		#region Properties

		public virtual ContentReference RootPage
		{
			get { return ContentReference.RootPage; }
		}

		public virtual ContentReference SiteBlockFolder
		{
			get { return ContentReference.SiteBlockFolder; }
		}

		public virtual ContentReference StartPage
		{
			get { return ContentReference.StartPage; }
		}

		public virtual ContentReference Wastebasket
		{
			get { return ContentReference.WasteBasket; }
		}

		#endregion
	}
}