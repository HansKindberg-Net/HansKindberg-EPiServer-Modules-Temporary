using System;
using System.Collections.Generic;
using System.Linq;
using EPiServer.Framework.Localization;
using EPiServer.ServiceLocation;
using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Sorting;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Shell.ObjectEditing.SelectionFactories
{
	public class SortOrderSelectionFactory : EnumerationSelectionFactory<SortOrder>
	{
		#region Fields

		private static readonly IEnumerable<SortOrder> _sortOrders = Enum.GetValues(typeof(SortOrder)).Cast<SortOrder>().Where(sortOrder => sortOrder != SortOrder.Rank);

		#endregion

		#region Constructors

		public SortOrderSelectionFactory() : this(ServiceLocator.Current.GetInstance<LocalizationService>()) {}
		public SortOrderSelectionFactory(LocalizationService localizationService) : base(localizationService) {}

		#endregion

		#region Properties

		protected internal override IEnumerable<SortOrder> Enumerators
		{
			get { return _sortOrders; }
		}

		#endregion
	}
}