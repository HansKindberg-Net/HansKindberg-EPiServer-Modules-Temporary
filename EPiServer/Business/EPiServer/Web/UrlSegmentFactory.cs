using EPiServer.Web;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Web
{
	public class UrlSegmentFactory : IUrlSegmentFactory
	{
		#region Methods

		public virtual string Create(string segment)
		{
			return UrlSegment.GetUrlFriendlySegment(segment);
		}

		#endregion
	}
}