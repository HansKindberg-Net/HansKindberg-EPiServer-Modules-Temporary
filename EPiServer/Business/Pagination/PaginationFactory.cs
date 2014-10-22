using System;
using System.Collections.Generic;
using HansKindberg.EPiServer.Modules.TestApplication.Business.Collections;
using HansKindberg.EPiServer.Modules.TestApplication.Business.Collections.Specialized;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.Pagination
{
	public class PaginationFactory : IPaginationFactory
	{
		#region Fields

		private const int _defaultMaximumNumberOfDisplayedPages = 10;
		private const string _defaultPageIndexKey = "PageIndex";
		private const int _defaultPageSize = 10;
		private readonly IItemCollectionFactory _itemCollectionFactory;
		private readonly INameValueCollectionParser _nameValueCollectionParser;
		private string _pageIndexKey;
		private readonly IPaginationValidator _validator;

		#endregion

		#region Constructors

		public PaginationFactory(IPaginationValidator validator, INameValueCollectionParser nameValueCollectionParser, IItemCollectionFactory itemCollectionFactory)
		{
			if(validator == null)
				throw new ArgumentNullException("validator");

			if(nameValueCollectionParser == null)
				throw new ArgumentNullException("nameValueCollectionParser");

			if(itemCollectionFactory == null)
				throw new ArgumentNullException("itemCollectionFactory");

			this._itemCollectionFactory = itemCollectionFactory;
			this._nameValueCollectionParser = nameValueCollectionParser;
			this._validator = validator;
		}

		#endregion

		#region Properties

		protected internal virtual int DefaultMaximumNumberOfDisplayedPages
		{
			get { return _defaultMaximumNumberOfDisplayedPages; }
		}

		protected internal virtual string DefaultPageIndexKey
		{
			get { return _defaultPageIndexKey; }
		}

		protected internal virtual int DefaultPageSize
		{
			get { return _defaultPageSize; }
		}

		protected internal virtual IItemCollectionFactory ItemCollectionFactory
		{
			get { return this._itemCollectionFactory; }
		}

		protected internal virtual INameValueCollectionParser NameValueCollectionParser
		{
			get { return this._nameValueCollectionParser; }
		}

		public virtual string PageIndexKey
		{
			get { return this._pageIndexKey ?? (this._pageIndexKey = this.DefaultPageIndexKey); }
			set
			{
				if(value != null)
					this.Validator.ValidatePageIndexKey(value);

				this._pageIndexKey = value;
			}
		}

		protected internal virtual IPaginationValidator Validator
		{
			get { return this._validator; }
		}

		#endregion

		#region Methods

		public virtual IPaginationInformation<T> Create<T>(IEnumerable<T> items, IPaginationSettings settings, Uri url, Func<T, bool> isSelectedDelegate)
		{
			return new PaginationInformation<T>(items, this.GetMaximumNumberOfDisplayedPages(settings), this.GetPageSize(settings), url, this.PageIndexKey, this.NameValueCollectionParser, this.ItemCollectionFactory, isSelectedDelegate);
		}

		protected internal virtual int GetMaximumNumberOfDisplayedPages(IPaginationSettings settings)
		{
			if(settings == null)
				throw new ArgumentNullException("settings");

			if(!settings.Enabled)
				return 1;

			var nullableMaximumNumberOfDisplayedPages = settings.MaximumNumberOfDisplayedPages;

			var maximumNumberOfDisplayedPages = nullableMaximumNumberOfDisplayedPages != null ? nullableMaximumNumberOfDisplayedPages.Value : this.DefaultMaximumNumberOfDisplayedPages;

			if(maximumNumberOfDisplayedPages < 1)
				maximumNumberOfDisplayedPages = this.DefaultMaximumNumberOfDisplayedPages;

			return maximumNumberOfDisplayedPages;
		}

		protected internal virtual int GetPageSize(IPaginationSettings settings)
		{
			if(settings == null)
				throw new ArgumentNullException("settings");

			if(!settings.Enabled)
				return int.MaxValue;

			var nullablePageSize = settings.PageSize;

			var pageSize = nullablePageSize != null ? nullablePageSize.Value : this.DefaultPageSize;

			if(pageSize < 1)
				pageSize = this.DefaultPageSize;

			return pageSize;
		}

		#endregion
	}
}