using System;
using System.Collections.Generic;
using System.Linq;
using EPiServer.Framework.Localization;
using EPiServer.ServiceLocation;
using HansKindberg.EPiServer.Modules.TestApplication.Business.Sorting;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Shell.ObjectEditing.SelectionFactories
{
	public class SortDirectionSelectionFactory : EnumerationSelectionFactory<SortDirection>
	{
		#region Fields

		private static readonly IEnumerable<SortDirection> _sortDirections = Enum.GetValues(typeof(SortDirection)).Cast<SortDirection>();

		#endregion

		#region Constructors

		public SortDirectionSelectionFactory() : this(ServiceLocator.Current.GetInstance<LocalizationService>()) {}
		public SortDirectionSelectionFactory(LocalizationService localizationService) : base(localizationService) {}

		#endregion

		#region Properties

		protected internal override IEnumerable<SortDirection> Enumerators
		{
			get { return _sortDirections; }
		}

		protected internal override bool IncludeEmptySelection
		{
			get { return false; }
		}

		protected internal override bool SortByText
		{
			get { return false; }
		}

		#endregion
	}
}