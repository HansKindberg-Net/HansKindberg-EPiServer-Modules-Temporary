using System.Collections.Generic;
using System.Globalization;
using HansKindberg.EPiServer.Modules.TestApplication.Business.Collections;
using HansKindberg.EPiServer.Modules.TestApplication.Models.Pages;

namespace HansKindberg.EPiServer.Modules.TestApplication.Models.ViewModels
{
	public interface ILayoutModel
	{
		#region Properties

		bool AtHome { get; }
		CultureInfo Culture { get; }
		SitePageData CurrentPage { get; }
		string Heading { get; }
		IEnumerable<ITreeNode<SitePageData>> LeftNavigation { get; }
		IEnumerable<IListItem<SitePageData>> MainNavigation { get; }
		string MetaDescription { get; }
		string MetaKeywords { get; }
		StartPage StartPage { get; }
		string Title { get; }
		CultureInfo UiCulture { get; }

		#endregion
	}
}