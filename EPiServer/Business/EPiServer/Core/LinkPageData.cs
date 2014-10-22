using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Security;
using EPiServer.SpecializedProperties;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Core
{
	public class LinkPageData : PageData, ILinkContent, INavigable
	{
		#region Constructors

		public LinkPageData() {}
		public LinkPageData(PageData copy) : base(copy) {}
		public LinkPageData(PageReference pageLink) : base(pageLink) {}
		public LinkPageData(RawPage rawPage) : base(rawPage) {}
		public LinkPageData(AccessControlList accessControlList, PropertyDataCollection propertyDataCollection) : base(accessControlList, propertyDataCollection) {}

		#endregion

		#region Properties

		string ILink.LinkUrl
		{
			get { return this.LinkURL; }
			set { this.LinkURL = value; }
		}

		[Ignore]
		public virtual ContentReference ShortcutLink
		{
			get
			{
				var shortcutLink = this.Property["PageShortcutLink"] as PropertyContentReference;

				return shortcutLink != null ? shortcutLink.ContentLink : null;
			}
		}

		[Ignore]
		public virtual string TargetFrameName
		{
			get
			{
				var targetFrame = this.Property["PageTargetFrame"] as PropertyFrame;

				return targetFrame != null ? targetFrame.FrameName : null;
			}
		}

		#endregion
	}
}