using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using EPiServer.Framework.Localization;
using EPiServer.ServiceLocation;
using EPiServer.Shell.ObjectEditing;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Shell.ObjectEditing.SelectionFactories
{
	public class PageListTypeSelectionFactory : LocalizationSelectionFactory, ISelectionFactory
	{
		#region Fields

		private const string _localizationPathFormat = "/contenttypes/pagelist/properties/pagelisttype/types/{0}";

		private static readonly IDictionary<int, string> _pageListTypes = new Dictionary<int, string>
		{
			{1, "Introduction"},
			{2, "News"},
			{3, "SimpleNews"}
		};

		#endregion

		#region Constructors

		public PageListTypeSelectionFactory() : this(ServiceLocator.Current.GetInstance<LocalizationService>()) {}
		public PageListTypeSelectionFactory(LocalizationService localizationService) : base(localizationService) {}

		#endregion

		#region Properties

		protected internal virtual string LocalizationPathFormat
		{
			get { return _localizationPathFormat; }
		}

		protected internal virtual IDictionary<int, string> PageListTypes
		{
			get { return _pageListTypes; }
		}

		#endregion

		#region Methods

		public virtual IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
		{
			var selectItems = new List<SelectItem>
			{
				new SelectItem()
			};

			selectItems.AddRange(this.PageListTypes.Select(pageListType => new SelectItem {Text = this.LocalizationService.GetString(string.Format(CultureInfo.InvariantCulture, this.LocalizationPathFormat, pageListType.Value)), Value = pageListType.Key}));

			return selectItems.ToArray();
		}

		#endregion
	}
}