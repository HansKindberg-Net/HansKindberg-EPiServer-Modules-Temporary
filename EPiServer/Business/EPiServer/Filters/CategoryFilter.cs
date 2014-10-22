using System;
using System.Collections.Generic;
using System.Linq;
using EPiServer.Core;
using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Core;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Filters
{
	public class CategoryFilter : ContentFilter, ICategoryFilter
	{
		#region Fields

		private readonly CategoryList _categories;

		#endregion

		#region Constructors

		public CategoryFilter(IEnumerable<int> categories)
		{
			if(categories == null)
				throw new ArgumentNullException("categories");

			this._categories = new CategoryList(categories.ToArray());
		}

		#endregion

		#region Properties

		IEnumerable<int> ICategoryFilter.Categories
		{
			get { return this.Categories; }
		}

		public virtual CategoryList Categories
		{
			get { return this._categories; }
		}

		public virtual CategoryComparison Comparison { get; set; }

		#endregion

		#region Methods

		public override bool ShouldFilter(IContent content)
		{
			if(content == null)
				throw new ArgumentNullException("content");

			if((this.Categories == null || !this.Categories.Any()) && this.Comparison != CategoryComparison.Exact)
				return false;

			var categorizable = content as ICategorizable;

			if(categorizable == null)
				return false;

			var contentCategories = categorizable.Category;

			if(this.Comparison == CategoryComparison.Exact)
				return !contentCategories.Equals(this.Categories);

			if(this.Comparison == CategoryComparison.MemberOfAll)
				return !contentCategories.MemberOfAll(this.Categories);

			return !contentCategories.MemberOfAny(this.Categories);
		}

		#endregion
	}
}