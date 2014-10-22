using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using HansKindberg.EPiServer.Modules.TestApplication.Business.Collections;
using HansKindberg.EPiServer.Modules.TestApplication.Business.Collections.Specialized;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.Pagination
{
	public class PaginationInformation<T> : IPaginationInformation<T>
	{
		#region Fields

		private IEnumerable<IPage<T>> _displayedPages;
		private Lazy<Uri> _firstPageUrl;
		private readonly Func<T, bool> _isSelectedDelegate;
		private readonly IItemCollectionFactory _itemCollectionFactory;
		private readonly IEnumerable<T> _items;
		private Lazy<Uri> _lastPageUrl;
		private readonly int _maximumNumberOfDisplayedPages;
		private readonly INameValueCollectionParser _nameValueCollectionParser;
		private Lazy<Uri> _nextPageGroupUrl;
		private Lazy<Uri> _nextPageUrl;
		private int? _pageIndex;
		private readonly string _pageIndexKey;
		private int? _pageIndexPossiblyFlowingOverTheTop;
		private readonly int _pageSize;
		private IEnumerable<IPage<T>> _pages;
		private Lazy<Uri> _previousPageGroupUrl;
		private Lazy<Uri> _previousPageUrl;
		private readonly Uri _url;

		#endregion

		#region Constructors

		public PaginationInformation(IEnumerable<T> items, int maximumNumberOfDisplayedPages, int pageSize, Uri url, string pageIndexKey, INameValueCollectionParser nameValueCollectionParser, IItemCollectionFactory itemCollectionFactory, Func<T, bool> isSelectedDelegate)
		{
			if(items == null)
				throw new ArgumentNullException("items");

			if(maximumNumberOfDisplayedPages < 1)
				throw new ArgumentException("The maximum number of displayed pages can not be less than one.", "maximumNumberOfDisplayedPages");

			if(pageSize < 1)
				throw new ArgumentException("The page-size can not be less than one.", "pageSize");

			if(url == null)
				throw new ArgumentNullException("url");

			if(!url.IsAbsoluteUri)
				throw new ArgumentException("The url must be absolute.", "url");

			if(pageIndexKey == null)
				throw new ArgumentNullException("pageIndexKey");

			if(string.IsNullOrWhiteSpace(pageIndexKey))
				throw new ArgumentException("The page-index-key can not be empty.", "pageIndexKey");

			if(nameValueCollectionParser == null)
				throw new ArgumentNullException("nameValueCollectionParser");

			if(itemCollectionFactory == null)
				throw new ArgumentNullException("itemCollectionFactory");

			if(isSelectedDelegate == null)
				throw new ArgumentNullException("isSelectedDelegate");

			this._isSelectedDelegate = isSelectedDelegate;
			this._itemCollectionFactory = itemCollectionFactory;
			this._items = items;
			this._maximumNumberOfDisplayedPages = maximumNumberOfDisplayedPages;
			this._nameValueCollectionParser = nameValueCollectionParser;
			this._pageIndexKey = pageIndexKey;
			this._pageSize = pageSize;
			this._url = url;
		}

		#endregion

		#region Properties

		IEnumerable<IPage> IPaginationInformation.DisplayedPages
		{
			get { return this.DisplayedPages; }
		}

		public virtual IEnumerable<IPage<T>> DisplayedPages
		{
			get
			{
				if(this._displayedPages == null)
				{
					// ReSharper disable ConvertIfStatementToConditionalTernaryExpression

					if(this.MaximumNumberOfDisplayedPages >= this.Pages.Count())
						this._displayedPages = this.Pages;
					else
						this._displayedPages = this.Pages.Skip(this.PageGroupIndex*this.MaximumNumberOfDisplayedPages).Take(this.MaximumNumberOfDisplayedPages);

					// ReSharper restore ConvertIfStatementToConditionalTernaryExpression
				}

				return this._displayedPages;
			}
		}

		public virtual Uri FirstPageUrl
		{
			get
			{
				if(this._firstPageUrl == null)
				{
					this._firstPageUrl = new Lazy<Uri>(() =>
					{
						if(this.PageIndex == 0)
							return null;

						return this.Pages.First().Url;
					});
				}

				return this._firstPageUrl.Value;
			}
		}

		protected internal virtual Func<T, bool> IsSelectedDelegate
		{
			get { return this._isSelectedDelegate; }
		}

		protected internal virtual IItemCollectionFactory ItemCollectionFactory
		{
			get { return this._itemCollectionFactory; }
		}

		IEnumerable IPaginationInformation.Items
		{
			get { return this.Items; }
		}

		public virtual IEnumerable<T> Items
		{
			get { return this._items; }
		}

		public virtual Uri LastPageUrl
		{
			get
			{
				if(this._lastPageUrl == null)
				{
					this._lastPageUrl = new Lazy<Uri>(() =>
					{
						if(this.PageIndex == this.Pages.Count() - 1)
							return null;

						return this.Pages.Last().Url;
					});
				}

				return this._lastPageUrl.Value;
			}
		}

		protected internal virtual int MaximumNumberOfDisplayedPages
		{
			get { return this._maximumNumberOfDisplayedPages; }
		}

		protected internal virtual NameValueCollection NameValueCollection
		{
			get { return this.NameValueCollectionParser.Parse(this.Url.Query); }
		}

		protected internal virtual INameValueCollectionParser NameValueCollectionParser
		{
			get { return this._nameValueCollectionParser; }
		}

		public virtual Uri NextPageGroupUrl
		{
			get
			{
				if(this._nextPageGroupUrl == null)
				{
					this._nextPageGroupUrl = new Lazy<Uri>(() =>
					{
						if(this.PageIndex < this.Pages.Count() - 1)
						{
							int quotient = this.PageIndex/this.MaximumNumberOfDisplayedPages;

							int firstIndexInNextPageGroup = this.Add(this.Multiply(quotient, this.MaximumNumberOfDisplayedPages), this.MaximumNumberOfDisplayedPages);

							if(firstIndexInNextPageGroup < this.Pages.Count())
								return this.Pages.ElementAt(firstIndexInNextPageGroup).Url;
						}

						return null;
					});
				}

				return this._nextPageGroupUrl.Value;
			}
		}

		public virtual Uri NextPageUrl
		{
			get
			{
				if(this._nextPageUrl == null)
				{
					this._nextPageUrl = new Lazy<Uri>(() =>
					{
						if(this.PageIndex == this.Pages.Count() - 1)
							return null;

						return this.Pages.ElementAt(this.PageIndex + 1).Url;
					});
				}

				return this._nextPageUrl.Value;
			}
		}

		IPage IPaginationInformation.Page
		{
			get { return this.Page; }
		}

		public virtual IPage<T> Page
		{
			get { return this.Pages.ElementAt(this.PageIndex); }
		}

		protected internal virtual int PageGroupIndex
		{
			get { return this.PageIndex/this.MaximumNumberOfDisplayedPages; }
		}

		protected internal virtual int PageIndex
		{
			get
			{
				if(this._pageIndex == null)
				{
					int pageIndex = this.PageIndexPossiblyFlowingOverTheTop;

					if(pageIndex > this.Pages.Count() - 1)
						pageIndex = this.Pages.Count() - 1;

					this._pageIndex = pageIndex;
				}

				return this._pageIndex.Value;
			}
		}

		protected internal virtual string PageIndexKey
		{
			get { return this._pageIndexKey; }
		}

		protected internal virtual int PageIndexPossiblyFlowingOverTheTop
		{
			get
			{
				if(this._pageIndexPossiblyFlowingOverTheTop == null)
				{
					var nameValueCollection = this.NameValueCollection;

					var pageIndexValue = nameValueCollection[this.PageIndexKey];

					int pageIndex;
					if(!int.TryParse(pageIndexValue, out pageIndex))
						pageIndex = 0;

					if(pageIndex < 0)
						pageIndex = 0;

					this._pageIndexPossiblyFlowingOverTheTop = pageIndex;
				}

				return this._pageIndexPossiblyFlowingOverTheTop.Value;
			}
		}

		protected internal virtual int PageSize
		{
			get { return this._pageSize; }
		}

		IEnumerable<IPage> IPaginationInformation.Pages
		{
			get { return this.Pages; }
		}

		public virtual IEnumerable<IPage<T>> Pages
		{
			get
			{
				if(this._pages == null)
				{
					var pages = new List<Page<T>>();

					var numberOfPages = this.GetNumberOfPages(this.Items.Count(), this.PageSize);

					var pageIndex = this.PageIndexPossiblyFlowingOverTheTop;

					if(pageIndex > numberOfPages - 1)
						pageIndex = numberOfPages - 1;

					var nameValueCollection = this.NameValueCollection;

					var urlBuilder = new UriBuilder(this.Url);

					for(int i = 0; i < numberOfPages; i++)
					{
						var modulus = i%this.MaximumNumberOfDisplayedPages;
						nameValueCollection.Set(this.PageIndexKey, i.ToString(CultureInfo.InvariantCulture));
						urlBuilder.Query = nameValueCollection.ToString();

						var page = new Page<T>
						{
							Current = i == pageIndex,
							First = i == 0,
							FirstInGroup = modulus == 0,
							Index = i,
							Items = this.ItemCollectionFactory.CreateListItems(this.Items.Skip(i*this.PageSize).Take(this.PageSize), this.IsSelectedDelegate),
							Last = i == numberOfPages - 1,
							LastInGroup = modulus == this.MaximumNumberOfDisplayedPages - 1,
							Url = urlBuilder.Uri
						};

						pages.Add(page);
					}

					this._pages = pages.ToArray();
				}

				return this._pages;
			}
		}

		public virtual Uri PreviousPageGroupUrl
		{
			get
			{
				if(this._previousPageGroupUrl == null)
				{
					this._previousPageGroupUrl = new Lazy<Uri>(() =>
					{
						if(this.PageIndex > 0)
						{
							int quotient = this.PageIndex/this.MaximumNumberOfDisplayedPages;

							if(quotient > 0)
							{
								int lastIndexInPreviousPageGroup = this.Multiply(quotient, this.MaximumNumberOfDisplayedPages) - 1;

								return this.Pages.ElementAt(lastIndexInPreviousPageGroup).Url;
							}
						}

						return null;
					});
				}

				return this._previousPageGroupUrl.Value;
			}
		}

		public virtual Uri PreviousPageUrl
		{
			get
			{
				if(this._previousPageUrl == null)
				{
					this._previousPageUrl = new Lazy<Uri>(() =>
					{
						if(this.PageIndex == 0)
							return null;

						return this.Pages.ElementAt(this.PageIndex - 1).Url;
					});
				}

				return this._previousPageUrl.Value;
			}
		}

		protected internal virtual Uri Url
		{
			get { return this._url; }
		}

		#endregion

		#region Methods

		protected virtual int Add(int firstNumber, int secondNumber)
		{
			try
			{
				return checked(firstNumber + secondNumber);
			}
			catch(OverflowException)
			{
				return int.MaxValue;
			}
		}

		protected internal virtual int GetNumberOfPages(int numberOfItems, int pageSize)
		{
			if(pageSize < 1)
				throw new ArgumentException("The page-size can not be less than one.", "pageSize");

			if(numberOfItems < 1)
				return 1;

			return 1 + (numberOfItems - 1)/pageSize;
		}

		protected virtual int Multiply(int firstNumber, int secondNumber)
		{
			try
			{
				return checked(firstNumber*secondNumber);
			}
			catch(OverflowException)
			{
				return int.MaxValue;
			}
		}

		#endregion
	}
}