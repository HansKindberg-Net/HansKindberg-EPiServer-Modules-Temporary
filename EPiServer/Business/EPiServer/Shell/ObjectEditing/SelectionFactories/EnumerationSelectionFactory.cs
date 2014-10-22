using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using EPiServer.Framework.Localization;
using EPiServer.Shell.ObjectEditing;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Shell.ObjectEditing.SelectionFactories
{
	public abstract class EnumerationSelectionFactory<T> : LocalizationSelectionFactory, ISelectionFactory where T : struct, IComparable, IFormattable
	{
		#region Fields

		private readonly string _localizationPathFormat;

		#endregion

		#region Constructors

		[SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase")]
		protected EnumerationSelectionFactory(LocalizationService localizationService) : base(localizationService)
		{
			if(!typeof(T).IsEnum)
				throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "T must be of type \"{0}\".", typeof(Enum)));

			this._localizationPathFormat = string.Format(CultureInfo.InvariantCulture, "/system/editutil/{0}/{1}", typeof(T).Name.ToLowerInvariant(), "{0}");
		}

		#endregion

		#region Properties

		protected internal abstract IEnumerable<T> Enumerators { get; }

		protected internal virtual bool IncludeEmptySelection
		{
			get { return true; }
		}

		protected internal virtual string LocalizationPathFormat
		{
			get { return this._localizationPathFormat; }
		}

		protected internal virtual bool SortByText
		{
			get { return true; }
		}

		#endregion

		#region Methods

		[SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "integer")]
		protected internal virtual int GetInteger(T enumerator)
		{
			return Convert.ToInt32(enumerator, CultureInfo.InvariantCulture);
		}

		public virtual IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
		{
			var selectItems = new List<SelectItem>();

			if(this.IncludeEmptySelection)
				selectItems.Add(new SelectItem());

			// ReSharper disable LoopCanBeConvertedToQuery
			foreach(T enumerator in this.Enumerators)
			{
				selectItems.Add(new SelectItem
				{
					Text = this.LocalizationService.GetString(string.Format(CultureInfo.InvariantCulture, this.LocalizationPathFormat, enumerator)),
					Value = this.GetInteger(enumerator)
				});
			}
			// ReSharper restore LoopCanBeConvertedToQuery

			return this.Sort(selectItems).ToArray();
		}

		protected internal virtual IEnumerable<ISelectItem> Sort(IEnumerable<ISelectItem> selectItems)
		{
			if(this.SortByText)
				return selectItems.OrderBy(selectItem => selectItem.Text);

			return selectItems;
		}

		#endregion
	}
}