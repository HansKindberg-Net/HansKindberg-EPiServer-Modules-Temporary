using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Core;
using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Sorting;

namespace HansKindberg.EPiServer.Modules.TestApplication.Models.Pages
{
	public abstract class SitePageData : LinkPageData, ISortable
	{
		#region Properties

		public virtual int Index
		{
			get { return (int) (this["PagePeerOrder"] ?? 0); }
		}

		public virtual int Rank
		{
			get { return (int) (this["PageRank"] ?? 0); }
		}

		#endregion
	}
}