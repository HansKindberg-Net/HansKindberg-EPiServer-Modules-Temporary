using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;
using EPiServer.Core;
using EPiServer.Filters;
using HansKindberg.EPiServer.Modules.TestApplication.Business.Collections.Specialized;
using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Collections;
using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Filters;
using HansKindberg.EPiServer.Modules.TestApplication.Business.Pagination;
using HansKindberg.EPiServer.Modules.TestApplication.Models.Pages;

namespace HansKindberg.EPiServer.Modules.TestApplication.Models.ViewModels
{
	public class PageListViewModel : PageViewModel<PageList>
	{
		#region Fields

		private const string _anchor = "page-list";
		private Lazy<ICategoryFilter> _categoryFilter;
		private readonly IContentCollectionFactory _contentCollectionFactory;
		private IContentListSettings _contentListSettings;
		private Lazy<IContentTypeFilter> _contentTypeFilter;
		private Lazy<ICountFilter> _countFilter;
		private IEnumerable<IContentFilter> _filters;
		private readonly HttpRequestBase _httpRequest;
		private readonly INameValueCollectionParser _nameValueCollectionParser;
		private IPaginationInformation<SitePageData> _pagination;
		private IPaginationSettings _paginationSettings;
		private IEnumerable<ContentReference> _roots;
		private Lazy<ISortFilter> _sortFilter;
		private Uri _url;

		#endregion

		#region Constructors

		public PageListViewModel(PageList currentPage, ILayoutModel layout, IContentCollectionFactory contentCollectionFactory, HttpRequestBase httpRequest, INameValueCollectionParser nameValueCollectionParser) : base(currentPage, layout)
		{
			if(contentCollectionFactory == null)
				throw new ArgumentNullException("contentCollectionFactory");

			if(httpRequest == null)
				throw new ArgumentNullException("httpRequest");

			if(nameValueCollectionParser == null)
				throw new ArgumentNullException("nameValueCollectionParser");

			this._contentCollectionFactory = contentCollectionFactory;
			this._httpRequest = httpRequest;
			this._nameValueCollectionParser = nameValueCollectionParser;
		}

		#endregion

		#region Properties

		public virtual string Anchor
		{
			get { return _anchor; }
		}

		protected internal virtual ICategoryFilter CategoryFilter
		{
			get
			{
				if(this._categoryFilter == null)
				{
					this._categoryFilter = new Lazy<ICategoryFilter>(() =>
					{
						var categories = (this.CurrentPage.CategoryFilter ?? Enumerable.Empty<int>()).ToArray();

						if(categories.Any())
							return new CategoryFilter(categories);

						return null;
					});
				}

				return this._categoryFilter.Value;
			}
		}

		protected internal virtual IContentCollectionFactory ContentCollectionFactory
		{
			get { return this._contentCollectionFactory; }
		}

		protected internal virtual IContentListSettings ContentListSettings
		{
			get
			{
				if(this._contentListSettings == null)
				{
					this._contentListSettings = new ContentListSettings
					{
						Recursive = this.CurrentPage.Recursive
					};
				}

				return this._contentListSettings;
			}
		}

		protected internal virtual IContentTypeFilter ContentTypeFilter
		{
			get
			{
				if(this._contentTypeFilter == null)
				{
					this._contentTypeFilter = new Lazy<IContentTypeFilter>(() =>
					{
						var pageTypeFilterSettings = this.CurrentPage.PageTypeFilterSettings;

						if(pageTypeFilterSettings != null)
						{
							var contentTypes = (pageTypeFilterSettings.Types ?? Enumerable.Empty<int>()).ToArray();

							if(contentTypes.Any())
								return new ContentTypeFilter(contentTypes) {Exclude = pageTypeFilterSettings.Exclude};
						}

						return null;
					});
				}

				return this._contentTypeFilter.Value;
			}
		}

		protected internal virtual ICountFilter CountFilter
		{
			get
			{
				if(this._countFilter == null)
				{
					this._countFilter = new Lazy<ICountFilter>(() =>
					{
						var maxCount = this.CurrentPage.MaxCount;

						if(maxCount != null)
							return new CountFilter() {Count = maxCount.Value};

						return null;
					});
				}

				return this._countFilter.Value;
			}
		}

		protected internal virtual IEnumerable<IContentFilter> Filters
		{
			get
			{
				if(this._filters == null)
				{
					var filters = new List<IContentFilter>();

					if(this.CategoryFilter != null)
						filters.Add(this.CategoryFilter);

					if(this.ContentTypeFilter != null)
						filters.Add(this.ContentTypeFilter);

					if(this.CountFilter != null)
						filters.Add(this.CountFilter);

					if(this.SortFilter != null)
						filters.Add(this.SortFilter);

					this._filters = filters.ToArray();
				}

				return this._filters;
			}
		}

		protected internal virtual HttpRequestBase HttpRequest
		{
			get { return this._httpRequest; }
		}

		protected internal virtual INameValueCollectionParser NameValueCollectionParser
		{
			get { return this._nameValueCollectionParser; }
		}

		public virtual IPaginationInformation<SitePageData> Pagination
		{
			get
			{
				if(this._pagination == null)
					this._pagination = this.ContentCollectionFactory.CreateContentPagination<SitePageData>(this.Roots, this.ContentListSettings, this.Filters, this.PaginationSettings, this.Url);

				return this._pagination;
			}
		}

		protected internal virtual IPaginationSettings PaginationSettings
		{
			get { return this._paginationSettings ?? (this._paginationSettings = this.CurrentPage.PaginationSettings); }
		}

		[SuppressMessage("Microsoft.Usage", "CA2234:PassSystemUriObjectsInsteadOfStrings")]
		protected internal virtual IEnumerable<ContentReference> Roots
		{
			get
			{
				if(this._roots == null)
				{
					var roots = this.CurrentPage.Roots.ToList();

					if(!roots.Any())
						roots.Add(new ContentReference(this.CurrentPage.ContentLink.ID, this.CurrentPage.ContentLink.ProviderName));

					this._roots = roots.ToArray();
				}

				return this._roots;
			}
		}

		protected internal virtual ISortFilter SortFilter
		{
			get
			{
				if(this._sortFilter == null)
				{
					this._sortFilter = new Lazy<ISortFilter>(() =>
					{
						var sortSettings = this.CurrentPage.SortSettings;

						if(sortSettings != null && sortSettings.Order != null)
							return new SortFilter
							{
								Direction = sortSettings.Direction,
								Order = sortSettings.Order.Value
							};

						return null;
					});
				}

				return this._sortFilter.Value;
			}
		}

		protected internal virtual Uri Url
		{
			get
			{
				if(this._url == null)
				{
					if(this.HttpRequest == null)
						throw new InvalidOperationException("The http-request is null.");

					if(this.HttpRequest.Url == null)
						throw new InvalidOperationException("The http-request-url is null.");

					var uriBuilder = new UriBuilder(this.HttpRequest.Url)
					{
						Fragment = this.Anchor
					};

					this._url = uriBuilder.Uri;
				}

				return this._url;
			}
		}

		#endregion
	}
}