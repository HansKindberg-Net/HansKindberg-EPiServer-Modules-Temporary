using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Web.Mvc;
using EPiServer.Framework.Localization;
using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Framework.Localization.Extensions;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Web.Mvc.Extensions
{
	public class DefaultTranslationExtension : ITranslationExtension
	{
		#region Fields

		private const char _absoluteResourceKeyPathSeparator = '/';
		private readonly IDictionary<Type, string> _absoluteResourceKeyPrefixCache = new Dictionary<Type, string>();
		private readonly LocalizationService _localizationService;
		private readonly object _lockObject = new object();
		private static readonly IEnumerable<string> _prefixesToRemove = new[] {"ASP._Page_"};
		private static readonly IEnumerable<string> _suffixesToRemove = new[] {"_cshtml"};

		#endregion

		#region Constructors

		public DefaultTranslationExtension(LocalizationService localizationService)
		{
			if(localizationService == null)
				throw new ArgumentNullException("localizationService");

			this._localizationService = localizationService;
		}

		#endregion

		#region Properties

		protected internal virtual char AbsoluteResourceKeyPathSeparator
		{
			get { return _absoluteResourceKeyPathSeparator; }
		}

		protected internal virtual IDictionary<Type, string> AbsoluteResourceKeyPrefixCache
		{
			get { return this._absoluteResourceKeyPrefixCache; }
		}

		protected internal virtual LocalizationService LocalizationService
		{
			get { return this._localizationService; }
		}

		protected internal virtual IEnumerable<string> PrefixesToRemove
		{
			get { return _prefixesToRemove; }
		}

		protected internal virtual char RelativeResourceKeyPrefix
		{
			get { return LocalizationServiceExtension.RelativeResourceKeyPrefix; }
		}

		protected internal virtual IEnumerable<string> SuffixesToRemove
		{
			get { return _suffixesToRemove; }
		}

		#endregion

		#region Methods

		[SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase")]
		protected internal virtual string GetAbsoluteResourceKeyPrefix(Type type)
		{
			if(type == null)
				throw new ArgumentNullException("type");

			string absoluteResourceKeyPrefix;

			if(!this.AbsoluteResourceKeyPrefixCache.TryGetValue(type, out absoluteResourceKeyPrefix))
			{
				lock(this._lockObject)
				{
					if(!this.AbsoluteResourceKeyPrefixCache.TryGetValue(type, out absoluteResourceKeyPrefix))
					{
						absoluteResourceKeyPrefix = type.FullName;

						foreach(var prefixToRemove in this.PrefixesToRemove)
						{
							if(absoluteResourceKeyPrefix.StartsWith(prefixToRemove, StringComparison.OrdinalIgnoreCase))
							{
								absoluteResourceKeyPrefix = absoluteResourceKeyPrefix.Substring(prefixToRemove.Length);
								break;
							}
						}

						foreach(var suffixToRemove in this.SuffixesToRemove)
						{
							if(absoluteResourceKeyPrefix.EndsWith(suffixToRemove, StringComparison.OrdinalIgnoreCase))
							{
								absoluteResourceKeyPrefix = absoluteResourceKeyPrefix.Substring(0, absoluteResourceKeyPrefix.Length - suffixToRemove.Length);
								break;
							}
						}

						var absoluteResourceKeyPathSeparator = this.AbsoluteResourceKeyPathSeparator.ToString(CultureInfo.InvariantCulture);

						absoluteResourceKeyPrefix = (absoluteResourceKeyPathSeparator + absoluteResourceKeyPrefix.Replace("_", absoluteResourceKeyPathSeparator).Trim(new[] {this.AbsoluteResourceKeyPathSeparator}) + absoluteResourceKeyPathSeparator).ToLowerInvariant();

						this.AbsoluteResourceKeyPrefixCache.Add(type, absoluteResourceKeyPrefix);
					}
				}
			}

			return absoluteResourceKeyPrefix;
		}

		protected internal virtual string GetFullResourceKey(string potentialRelativeResourceKey, IViewDataContainer view)
		{
			if(view == null)
				throw new ArgumentNullException("view");

			return this.GetFullResourceKey(potentialRelativeResourceKey, view.GetType());
		}

		[SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase")]
		protected internal virtual string GetFullResourceKey(string potentialRelativeResourceKey, Type type)
		{
			if(type == null)
				throw new ArgumentNullException("type");

			if(string.IsNullOrEmpty(potentialRelativeResourceKey))
				return potentialRelativeResourceKey;

			if(!potentialRelativeResourceKey.StartsWith(this.RelativeResourceKeyPrefix.ToString(CultureInfo.InvariantCulture), StringComparison.OrdinalIgnoreCase))
				return potentialRelativeResourceKey;

			return (this.GetAbsoluteResourceKeyPrefix(type) + potentialRelativeResourceKey.Substring(1)).ToLowerInvariant();
		}

		public virtual string Translate(string key, IViewDataContainer view)
		{
			return this.LocalizationService.GetString(this.GetFullResourceKey(key, view));
		}

		public virtual string Translate(string key, IViewDataContainer view, string fallback)
		{
			return this.LocalizationService.GetString(this.GetFullResourceKey(key, view), fallback);
		}

		public virtual string Translate(string key, IViewDataContainer view, FallbackBehaviors fallbackBehaviors)
		{
			return this.LocalizationService.GetString(this.GetFullResourceKey(key, view), fallbackBehaviors);
		}

		#endregion
	}
}