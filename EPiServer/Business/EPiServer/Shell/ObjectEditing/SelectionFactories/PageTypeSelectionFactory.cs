using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using EPiServer.DataAbstraction;
using EPiServer.ServiceLocation;
using EPiServer.Shell.ObjectEditing;
using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.DataAbstraction;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Shell.ObjectEditing.SelectionFactories
{
	public class PageTypeSelectionFactory : ISelectionFactory
	{
		#region Fields

		private readonly IContentTypeRepository _contentTypeRepository;

		#endregion

		#region Constructors

		public PageTypeSelectionFactory() : this(ServiceLocator.Current.GetInstance<IContentTypeRepository>()) {}

		public PageTypeSelectionFactory(IContentTypeRepository contentTypeRepository)
		{
			if(contentTypeRepository == null)
				throw new ArgumentNullException("contentTypeRepository");

			this._contentTypeRepository = contentTypeRepository;
		}

		#endregion

		#region Properties

		protected internal virtual IContentTypeRepository ContentTypeRepository
		{
			get { return this._contentTypeRepository; }
		}

		protected internal virtual IEnumerable<IContentType> PageTypes
		{
			get { return this.ContentTypeRepository.List().OfType<PageType>().Where(pageType => pageType.ID > 2).Select(pageType => (ContentTypeWrapper) pageType).OrderBy(pageType => pageType.SortOrder); }
		}

		#endregion

		#region Methods

		public virtual IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
		{
			return this.PageTypes.Select(pageType => new SelectItem {Text = pageType.LocalizedFullName, Value = pageType.Id.ToString(CultureInfo.InvariantCulture)}).OrderBy(selectItem => selectItem.Text).ToArray();
		}

		#endregion
	}
}