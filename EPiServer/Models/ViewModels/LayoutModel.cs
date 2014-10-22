using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using EPiServer;
using EPiServer.Core;
using EPiServer.Filters;
using EPiServer.Web.Routing;
using HansKindberg.EPiServer.Modules.TestApplication.Business.Collections;
using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Collections;
using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Core;
using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Filters.Extensions;
using HansKindberg.EPiServer.Modules.TestApplication.Business.Globalization;
using HansKindberg.EPiServer.Modules.TestApplication.Models.Pages;

namespace HansKindberg.EPiServer.Modules.TestApplication.Models.ViewModels
{
	public class LayoutModel : ILayoutModel
	{
		#region Fields

		private bool? _atHome;
		private readonly IContentCollectionFactory _contentCollectionFactory;
		private readonly IContentLoader _contentLoader;
		private readonly IContentReferenceRepository _contentReferenceRepository;
		private readonly ICultureContext _cultureContext;
		private Lazy<SitePageData> _currentPage;
		private readonly IContentFilter _filterForVisitor;
		private readonly HttpContextBase _httpContext;
		private Lazy<IEnumerable<ITreeNode<SitePageData>>> _leftNavigation;
		private Lazy<ContentReference> _leftNavigationRoot;
		private IContentTreeSettings _leftNavigationSettings;
		private IEnumerable<IListItem<SitePageData>> _mainNavigation;
		private IContentListSettings _mainNavigationSettings;
		private readonly PageRouteHelper _pageRouteHelper;
		private Lazy<StartPage> _startPage;

		#endregion

		#region Constructors

		public LayoutModel(PageRouteHelper pageRouteHelper, IContentLoader contentLoader, IContentReferenceRepository contentReferenceRepository, IContentFilter filterForVisitor, ICultureContext cultureContext, IContentCollectionFactory contentCollectionFactory, HttpContextBase httpContext)
		{
			if(pageRouteHelper == null)
				throw new ArgumentNullException("pageRouteHelper");

			if(contentLoader == null)
				throw new ArgumentNullException("contentLoader");

			if(contentReferenceRepository == null)
				throw new ArgumentNullException("contentReferenceRepository");

			if(filterForVisitor == null)
				throw new ArgumentNullException("filterForVisitor");

			if(cultureContext == null)
				throw new ArgumentNullException("cultureContext");

			if(contentCollectionFactory == null)
				throw new ArgumentNullException("contentCollectionFactory");

			if(httpContext == null)
				throw new ArgumentNullException("httpContext");

			this._contentCollectionFactory = contentCollectionFactory;
			this._contentLoader = contentLoader;
			this._contentReferenceRepository = contentReferenceRepository;
			this._cultureContext = cultureContext;
			this._filterForVisitor = filterForVisitor;
			this._httpContext = httpContext;
			this._pageRouteHelper = pageRouteHelper;
		}

		#endregion

		#region Properties

		public virtual bool AtHome
		{
			get
			{
				if(this._atHome == null)
					this._atHome = this.StartPage != null && this.CurrentPage != null && this.StartPage.ContentLink.ID == this.CurrentPage.ContentLink.ID;

				return this._atHome.Value;
			}
		}

		protected internal virtual IContentCollectionFactory ContentCollectionFactory
		{
			get { return this._contentCollectionFactory; }
		}

		protected internal virtual IContentLoader ContentLoader
		{
			get { return this._contentLoader; }
		}

		protected internal virtual IContentReferenceRepository ContentReferenceRepository
		{
			get { return this._contentReferenceRepository; }
		}

		public virtual CultureInfo Culture
		{
			get
			{
				if(this.CurrentPage == null)
					return this.CultureContext.CurrentCulture;

				CultureInfo culture = this.CurrentPage.Language;

				if(culture.IsNeutralCulture)
					culture = CultureInfo.CreateSpecificCulture(culture.Name);

				return culture;
			}
		}

		protected internal virtual ICultureContext CultureContext
		{
			get { return this._cultureContext; }
		}

		public virtual SitePageData CurrentPage
		{
			get
			{
				if(this._currentPage == null)
					this._currentPage = new Lazy<SitePageData>(() => (SitePageData) this.PageRouteHelper.Page);

				return this._currentPage.Value;
			}
		}

		protected internal virtual ContentReference CurrentPageLink
		{
			get { return this.CurrentPage != null ? this.CurrentPage.ContentLink : null; }
		}

		protected internal virtual IContentFilter FilterForVisitor
		{
			get { return this._filterForVisitor; }
		}

		public virtual string Heading
		{
			get { return this.CurrentPage != null ? this.CurrentPage.Name : string.Empty; }
		}

		protected internal virtual HttpContextBase HttpContext
		{
			get { return this._httpContext; }
		}

		public virtual IEnumerable<ITreeNode<SitePageData>> LeftNavigation
		{
			get
			{
				if(this._leftNavigation == null)
				{
					this._leftNavigation = new Lazy<IEnumerable<ITreeNode<SitePageData>>>(() =>
					{
						if(this.LeftNavigationRoot != null)
							return this.ContentCollectionFactory.CreateContentTree<SitePageData>(this.LeftNavigationRoot, this.LeftNavigationSettings, this.CurrentPageLink);

						return null;
					});
				}

				return this._leftNavigation.Value;
			}
		}

		protected internal virtual ContentReference LeftNavigationRoot
		{
			get
			{
				if(this._leftNavigationRoot == null)
				{
					this._leftNavigationRoot = new Lazy<ContentReference>(() =>
					{
						if(this.CurrentPageLink != null)
						{
							var mainNavigationContentLinks = this.MainNavigation.Select(mainNavigationItem => mainNavigationItem.Value.ContentLink).ToArray();

							var leftNavigationRoot = mainNavigationContentLinks.FirstOrDefault(mainNavigationContentLink => this.CurrentPageLink.CompareToIgnoreWorkID(mainNavigationContentLink));

							if(leftNavigationRoot == null)
							{
								var ancestorContentLinks = this.ContentLoader.GetAncestors(this.CurrentPage.ContentLink).Select(ancestor => ancestor.ContentLink).ToArray();

								leftNavigationRoot = ancestorContentLinks.FirstOrDefault(ancestorContentLink => mainNavigationContentLinks.Any(ancestorContentLink.CompareToIgnoreWorkID));
							}

							return leftNavigationRoot;
						}

						return null;
					});
				}

				return this._leftNavigationRoot.Value;
			}
		}

		protected internal virtual IContentTreeSettings LeftNavigationSettings
		{
			get
			{
				if(this._leftNavigationSettings == null)
				{
					this._leftNavigationSettings = new ContentTreeSettings
					{
						ExpandAll = false,
						IncludeRoot = false,
						NumberOfLevels = int.MaxValue,
						OnlyForVisitor = true,
						OnlyVisibleInMenu = true
					};
				}

				return this._leftNavigationSettings;
			}
		}

		public virtual IEnumerable<IListItem<SitePageData>> MainNavigation
		{
			get { return this._mainNavigation ?? (this._mainNavigation = this.ContentCollectionFactory.CreateContentList<SitePageData>(this.MainNavigationRoot, this.MainNavigationSettings, this.CurrentPageLink)); }
		}

		protected internal virtual ContentReference MainNavigationRoot
		{
			get { return this.ContentReferenceRepository.StartPage; }
		}

		protected internal virtual IContentListSettings MainNavigationSettings
		{
			get
			{
				// ReSharper disable ConvertIfStatementToNullCoalescingExpression
				if(this._mainNavigationSettings == null)
				{
					this._mainNavigationSettings = new ContentListSettings
					{
						OnlyForVisitor = true,
						OnlyVisibleInMenu = true,
						Recursive = false
					};
				}
				// ReSharper restore ConvertIfStatementToNullCoalescingExpression

				return this._mainNavigationSettings;
			}
		}

		public virtual string MetaDescription
		{
			get { return "MetaDescription"; }
		}

		public virtual string MetaKeywords
		{
			get { return "MetaKeywords"; }
		}

		protected internal virtual PageRouteHelper PageRouteHelper
		{
			get { return this._pageRouteHelper; }
		}

		public virtual StartPage StartPage
		{
			get
			{
				if(this._startPage == null)
					this._startPage = new Lazy<StartPage>(() => (StartPage) this.FilterForVisitor.Filter(this.ContentLoader.Get<StartPage>(this.ContentReferenceRepository.StartPage)));

				return this._startPage.Value;
			}
		}

		public virtual string Title
		{
			get { return "EPiServer - " + this.Heading; }
		}

		public virtual CultureInfo UiCulture
		{
			get
			{
				if(this.CurrentPage == null)
					return this.CultureContext.CurrentUiCulture;

				CultureInfo uiCulture = this.CurrentPage.Language;

				if(!uiCulture.IsNeutralCulture)
					uiCulture = uiCulture.Parent;

				return uiCulture;
			}
		}

		#endregion
	}
}