using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using EPiServer.Framework.Localization;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Framework.Localization.Extensions
{
	public static class LocalizationServiceExtension
	{
		#region Fields

		public const char RelativeResourceKeyPrefix = '#';

		#endregion

		#region Methods

		[SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase")]
		public static string GetFullResourceKey(string potentialRelativeResourceKey, Type type)
		{
			if(type == null)
				throw new ArgumentNullException("type");

			if(string.IsNullOrEmpty(potentialRelativeResourceKey))
				return potentialRelativeResourceKey;

			if(!potentialRelativeResourceKey.StartsWith(RelativeResourceKeyPrefix.ToString(CultureInfo.InvariantCulture), StringComparison.OrdinalIgnoreCase))
				return potentialRelativeResourceKey;

			return ("/" + type.FullName.Replace(".", "/") + "/").ToLowerInvariant() + potentialRelativeResourceKey.Substring(1);
		}

		public static string GetString(this LocalizationService localizationService, string resourceKey, Type type)
		{
			if(localizationService == null)
				throw new ArgumentNullException("localizationService");

			return localizationService.GetString(GetFullResourceKey(resourceKey, type));
		}

		public static string GetString(this LocalizationService localizationService, string resourceKey, Type type, string fallback)
		{
			if(localizationService == null)
				throw new ArgumentNullException("localizationService");

			return localizationService.GetString(GetFullResourceKey(resourceKey, type), fallback);
		}

		public static string GetString(this LocalizationService localizationService, string resourceKey, Type type, FallbackBehaviors fallbackBehaviors)
		{
			if(localizationService == null)
				throw new ArgumentNullException("localizationService");

			return localizationService.GetString(GetFullResourceKey(resourceKey, type), fallbackBehaviors);
		}

		#endregion
	}
}