using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using EPiServer.Core;
using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Core;
using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Sorting;
using HansKindberg.EPiServer.Modules.TestApplication.Business.Sorting;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Filters
{
	public class SortFilter : ContentFilter, ISortFilter
	{
		#region Properties

		public virtual CompareInfo CompareInformation { get; set; }
		public virtual SortDirection Direction { get; set; }
		public virtual SortOrder Order { get; set; }

		#endregion

		#region Methods

		public virtual int Compare(IContent x, IContent y)
		{
			var compare = this.Compare(this.GetPropertyDelegate(x as ISortable)(), this.GetPropertyDelegate(y as ISortable)());

			if(this.Direction == SortDirection.Descending)
				return -compare;

			return compare;
		}

		protected internal virtual int Compare(object first, object second)
		{
			if(first == null)
				return second == null ? 0 : 1;

			if(second == null)
				return -1;

			var firstAsString = first as string;
			var secondAsString = second as string;

			if((this.CompareInformation != null && firstAsString != null) && secondAsString != null)
				return this.CompareInformation.Compare(firstAsString, secondAsString);

			var firstAsComparable = first as IComparable;

			if(firstAsComparable == null)
				this.ThrowNotComparableException(first);

			var secondAsComparable = second as IComparable;

			if(secondAsComparable == null)
				this.ThrowNotComparableException(second);

			// ReSharper disable PossibleNullReferenceException
			return firstAsComparable.CompareTo(secondAsComparable);
			// ReSharper restore PossibleNullReferenceException
		}

		public override void Filter(IList<IContent> contents)
		{
			this.Sort(contents);
		}

		[SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		protected internal virtual Func<object> GetPropertyDelegate(ISortable sortable)
		{
			if(sortable == null)
				return () => null;

			switch(this.Order)
			{
				case SortOrder.Changed:
					return () => sortable.Changed;
				case SortOrder.Created:
					return () => sortable.Created;
				case SortOrder.Heading:
				{
					// ReSharper disable SuspiciousTypeConversion.Global
					var headlinable = sortable as IHeadlinable;
					// ReSharper restore SuspiciousTypeConversion.Global

					if(headlinable != null && !string.IsNullOrEmpty(headlinable.Heading))
						return () => headlinable.Heading;

					return () => sortable.Name;
				}
				case SortOrder.Name:
					return () => sortable.Name;
				case SortOrder.Published:
					return () => sortable.StartPublish;
				case SortOrder.Rank:
					return () => sortable.Rank;
				case SortOrder.Saved:
					return () => sortable.Saved;
				default:
					return () => sortable.Index;
			}
		}

		public override bool ShouldFilter(IContent content)
		{
			return false;
		}

		public virtual void Sort(IList<IContent> contents)
		{
			if(contents == null)
				throw new ArgumentNullException("contents");

			var isConcreteList = true;

			var contentList = contents as List<IContent>;

			if(contentList == null)
			{
				contentList = new List<IContent>(contents);

				isConcreteList = false;
			}

			try
			{
				contentList.Sort(this);
			}
			catch(InvalidOperationException invalidOperationException)
			{
				throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The content-collection could not be sorted using sort-order \"{0}\".", this.Order), invalidOperationException);
			}

			if(!isConcreteList)
			{
				contents.Clear();

				foreach(var content in contentList)
				{
					contents.Add(content);
				}
			}
		}

		protected internal virtual void ThrowNotComparableException(object value)
		{
			throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The value \"{0}\" does not support \"{1}\".", value, typeof(IComparable)));
		}

		#endregion
	}
}