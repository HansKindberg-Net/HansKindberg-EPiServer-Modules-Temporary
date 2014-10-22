using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Shell.ObjectEditing.SelectionFactories;
using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Sorting;
using HansKindberg.EPiServer.Modules.TestApplication.Business.Sorting;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Blocks
{
	[ContentType(AvailableInEditMode = false, GUID = "BD1C578A-8F91-46B5-AF0A-76AB0DF39712")]
	public class SortSettingsBlock : BlockData, ISortSettings
	{
		#region Fields

		private const string _directionPropertyName = "Direction";
		private const string _orderPropertyName = "Order";

		#endregion

		#region Properties

		[BackingType(typeof(PropertyBoolean))]
		[Display(Order = 2)]
		[SelectOne(SelectionFactoryType = typeof(SortDirectionSelectionFactory))]
		public virtual SortDirection Direction
		{
			get
			{
				var boolean = this[_directionPropertyName] as bool?;

				if(boolean == null || !boolean.Value)
					return SortDirection.Ascending;

				return SortDirection.Descending;
			}
			set { this[_directionPropertyName] = value == SortDirection.Ascending ? (SortDirection?) null : SortDirection.Descending; }
		}

		[BackingType(typeof(PropertyNumber))]
		[Display(Order = 1)]
		[SelectOne(SelectionFactoryType = typeof(SortOrderSelectionFactory))]
		public virtual SortOrder? Order
		{
			get
			{
				var number = this[_orderPropertyName] as int?;

				if(number == null)
					return null;

				return (SortOrder) number.Value;
			}
			set { this[_orderPropertyName] = value != null ? (int) value : (int?) null; }
		}

		#endregion
	}
}