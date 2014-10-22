using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Blocks;
using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Core.Extensions;
using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Filters;
using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Shell.ObjectEditing.SelectionFactories;
using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Sorting;
using HansKindberg.EPiServer.Modules.TestApplication.Business.Pagination;

namespace HansKindberg.EPiServer.Modules.TestApplication.Models.Pages
{
	[ContentType(GUID = "2C7F347B-8A1F-472E-A3D3-C8150E7C5796", Order = 140)]
	public class PageList : MainBodyPage
	{
		#region Fields

		private const string _categoryFilterPropertyName = "CategoryFilter";

		#endregion

		#region Properties

		[BackingType(typeof(PropertyCategory))]
		[Display(GroupName = SystemTabNames.Content, Order = 260)]
		public virtual IEnumerable<int> CategoryFilter
		{
			get { return this.GetCategories(_categoryFilterPropertyName); }
			set { this.SetCategories(_categoryFilterPropertyName, value); }
		}

		[Display(GroupName = SystemTabNames.Content, Order = 250)]
		public virtual bool DisableVisibleInMenu { get; set; }

		[Display(GroupName = SystemTabNames.Content, Order = 220)]
		public virtual int? MaxCount { get; set; }

		[Display(GroupName = SystemTabNames.Content, Order = 210)]
		[SelectOne(SelectionFactoryType = typeof(PageListTypeSelectionFactory))]
		public virtual int? PageListType { get; set; }

		public virtual IPageTypeFilterSettings PageTypeFilterSettings
		{
			get { return this.PageTypeFilterSettingsBlock; }
		}

		[Display(GroupName = SystemTabNames.Content, Order = 240)]
		public virtual PageTypeFilterSettingsBlock PageTypeFilterSettingsBlock { get; set; }

		public virtual IPaginationSettings PaginationSettings
		{
			get { return this.PaginationSettingsBlock; }
		}

		[Display(GroupName = SystemTabNames.Content, Order = 290)]
		public virtual PaginationSettingsBlock PaginationSettingsBlock { get; set; }

		[Display(GroupName = SystemTabNames.Content, Order = 280)]
		public virtual bool Recursive { get; set; }

		public virtual IEnumerable<ContentReference> Roots
		{
			get
			{
				var roots = new List<ContentReference>();

				if(this.RootsContentArea != null)
				{
					// ReSharper disable LoopCanBeConvertedToQuery
					foreach(var contentAreaItem in this.RootsContentArea.Items ?? Enumerable.Empty<ContentAreaItem>())
					{
						if(!ContentReference.IsNullOrEmpty(contentAreaItem.ContentLink))
							roots.Add(contentAreaItem.ContentLink);
					}
					// ReSharper restore LoopCanBeConvertedToQuery
				}

				return roots.ToArray();
			}
		}

		[AllowedTypes(new[] {typeof(PageData)})]
		[Display(GroupName = SystemTabNames.Content, Order = 200)]
		public virtual ContentArea RootsContentArea { get; set; }

		public virtual ISortSettings SortSettings
		{
			get { return this.SortSettingsBlock; }
		}

		[Display(GroupName = SystemTabNames.Content, Order = 230)]
		public virtual SortSettingsBlock SortSettingsBlock { get; set; }

		#endregion
	}
}