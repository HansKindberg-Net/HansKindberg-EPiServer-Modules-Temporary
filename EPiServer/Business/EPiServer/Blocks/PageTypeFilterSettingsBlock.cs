using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Core.Extensions;
using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Filters;
using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Shell.ObjectEditing.SelectionFactories;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Blocks
{
	[ContentType(AvailableInEditMode = false, GUID = "EBA4CB22-026E-4D14-A6DD-102697DF81D8")]
	public class PageTypeFilterSettingsBlock : BlockData, IPageTypeFilterSettings
	{
		#region Fields

		private const string _typesPropertyName = "Types";

		#endregion

		#region Properties

		[Display(Order = 2)]
		public virtual bool Exclude { get; set; }

		[BackingType(typeof(PropertyLongString))]
		[Display(Order = 1)]
		[SelectMany(SelectionFactoryType = typeof(PageTypeSelectionFactory))]
		public virtual IEnumerable<int> Types
		{
			get { return this.GetIntegers(_typesPropertyName); }
			set { this.SetIntegers(_typesPropertyName, value); }
		}

		#endregion
	}
}