using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using EPiServer.Framework.Localization;

namespace HansKindberg.EPiServer.ModuleTemplate.Business
{
	public class TemplateTab : ITemplateTab
	{
		#region Fields

		private string _description;
		private string _localDescription;
		private string _localName;
		private readonly LocalizationService _localizationService;
		private string _name;
		private readonly TemplateTabType _tabType;

		#endregion

		#region Constructors

		public TemplateTab(TemplateTabType tabType, LocalizationService localizationService)
		{
			if(localizationService == null)
				throw new ArgumentNullException("localizationService");

			this._localizationService = localizationService;
			this._tabType = tabType;
		}

		#endregion

		#region Properties

		public virtual bool Active { get; set; }

		public virtual string Description
		{
			get { return this._description ?? (this._description = string.Empty); }
			set
			{
				this._localDescription = null;
				this._description = value;
			}
		}

		public virtual int Index { get; set; }

		public virtual string LocalDescription
		{
			get
			{
				if(this._localDescription == null)
					return this._localDescription = this.GetLocalizationValue("description") ?? string.Empty;

				return this._localDescription;
			}
		}

		public virtual string LocalName
		{
			get
			{
				if(this._localName == null)
					return this._localName = this.GetLocalizationValue("name") ?? string.Empty;

				return this._localName;
			}
		}

		public virtual string LocalizationPath { get; set; }

		protected internal virtual LocalizationService LocalizationService
		{
			get { return this._localizationService; }
		}

		public virtual string Name
		{
			get { return this._name ?? (this._name = this.TabType.ToString()); }
			set
			{
				this._localName = null;
				this._name = value;
			}
		}

		public virtual TemplateTabType TabType
		{
			get { return this._tabType; }
		}

		public virtual Uri Url { get; set; }

		#endregion

		#region Methods

		[SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase")]
		protected internal virtual string GetLocalizationValue(string relativeKey)
		{
			if(relativeKey == null)
				throw new ArgumentNullException("relativeKey");

			if(this.LocalizationPath == null)
				return string.Format(CultureInfo.InvariantCulture, "[{0}: LocalizationPath not set]", relativeKey);

			return this.LocalizationService.GetString(Path.Combine(this.LocalizationPath, "tabs", this.TabType.ToString().ToLowerInvariant(), relativeKey.ToLowerInvariant()).Replace("\\", "/")) ?? string.Empty;
		}

		#endregion
	}
}