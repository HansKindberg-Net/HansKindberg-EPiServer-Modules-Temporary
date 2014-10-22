using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.SpecializedProperties;
using EPiServer.Web.Routing;
using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.SpecializedProperties;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Core.Extensions
{
	public static class ContentDataExtension
	{
		#region Fields

		public const char IntegersDelimiter = ',';
		public const char StringsDelimiter = '\n';

		#endregion

		#region Methods

		public static IEnumerable<int> GetCategories(this ContentData contentData, string propertyName)
		{
			if(contentData == null)
				throw new ArgumentNullException("contentData");

			return ((CategoryList) contentData[propertyName] ?? new CategoryList()).ToArray();
		}

		public static IEnumerable<int> GetIntegers(this ContentData contentData, string propertyName)
		{
			return contentData.GetIntegers(propertyName, IntegersDelimiter);
		}

		public static IEnumerable<int> GetIntegers(this ContentData contentData, string propertyName, char delimiter)
		{
			return contentData.GetStrings(propertyName, delimiter).Select(int.Parse);
		}

		public static IEnumerable<ILinkItem> GetLinkItems(this ContentData contentData, string propertyName)
		{
			if(contentData == null)
				throw new ArgumentNullException("contentData");

			return ((LinkItemCollection) contentData[propertyName] ?? new LinkItemCollection()).Select(item => (LinkItemWrapper) item).ToArray();
		}

		public static IEnumerable<ILinkItem> GetLinkItems<TContentData>(this TContentData contentData, Func<TContentData, LinkItemCollection> property)
			where TContentData : ContentData
		{
			if(contentData == null)
				throw new ArgumentNullException("contentData");

			if(property == null)
				throw new ArgumentNullException("property");

			return (property(contentData) ?? new LinkItemCollection()).Select(item => (LinkItemWrapper) item).ToArray();
		}

		public static IEnumerable<string> GetStrings(this ContentData contentData, string propertyName)
		{
			return contentData.GetStrings(propertyName, StringsDelimiter);
		}

		public static IEnumerable<string> GetStrings(this ContentData contentData, string propertyName, char delimiter)
		{
			if(contentData == null)
				throw new ArgumentNullException("contentData");

			var strings = new List<string>();

			var value = contentData[propertyName] as string;

			if(value != null)
				strings.AddRange(value.Split(new[] {delimiter}));

			return strings.ToArray();
		}

		[SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#")]
		public static bool Is<T>(this IContentData contentData, out T typedInstance) where T : class
		{
			return contentData.Is(out typedInstance, true);
		}

		[SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#")]
		public static bool Is<T>(this IContentData contentData, out T typedInstance, bool throwArgumentNullExceptionIfContentDataIsNull) where T : class
		{
			if(contentData == null && throwArgumentNullExceptionIfContentDataIsNull)
				throw new ArgumentNullException("contentData");

			typedInstance = contentData as T;

			return typedInstance != null;
		}

		public static bool IsModified(this IContentData contentData)
		{
			return contentData.IsModified(true);
		}

		public static bool IsModified(this IContentData contentData, bool defaultValue)
		{
			IModifiedTrackable modifiedTrackable;

			if(contentData.Is(out modifiedTrackable))
				return modifiedTrackable.IsModified;

			return defaultValue;
		}

		public static void SetCategories(this ContentData contentData, string propertyName, IEnumerable<int> categories)
		{
			if(contentData == null)
				throw new ArgumentNullException("contentData");

			contentData[propertyName] = new CategoryList((categories ?? Enumerable.Empty<int>()).ToArray());
		}

		public static void SetIntegers(this ContentData contentData, string propertyName, IEnumerable<int> integers)
		{
			contentData.SetIntegers(propertyName, integers, IntegersDelimiter);
		}

		public static void SetIntegers(this ContentData contentData, string propertyName, IEnumerable<int> integers, char delimiter)
		{
			contentData.SetStrings(propertyName, (integers ?? Enumerable.Empty<int>()).Select(integer => integer.ToString(CultureInfo.InvariantCulture)), delimiter);
		}

		public static void SetLinkItems(this ContentData contentData, string propertyName, IEnumerable<ILinkItem> linkItems)
		{
			if(contentData == null)
				throw new ArgumentNullException("contentData");

			var linkItemCollection = new LinkItemCollection();

			if(linkItems != null)
			{
				UrlResolver urlResolver = null;

				foreach(ILinkItem linkItem in linkItems)
				{
					var linkItemWrapper = linkItem as LinkItemWrapper;

					LinkItem concreteLinkItem;

					if(linkItemWrapper != null)
					{
						concreteLinkItem = linkItemWrapper.LinkItem;
					}
					else
					{
						if(urlResolver == null)
							urlResolver = ServiceLocator.Current.GetInstance<UrlResolver>();

						concreteLinkItem = new LinkItem
						{
							Href = linkItem.Href,
							Target = linkItem.Target,
							Text = linkItem.Text,
							Title = linkItem.Title,
							UrlResolver = urlResolver
						};

						foreach(var item in linkItem.Attributes)
						{
							concreteLinkItem.Attributes.Add(item.Key, item.Value);
						}
					}

					linkItemCollection.Add(concreteLinkItem);
				}
			}

			contentData[propertyName] = linkItemCollection;
		}

		public static void SetStrings(this ContentData contentData, string propertyName, IEnumerable<string> strings)
		{
			contentData.SetStrings(propertyName, strings, StringsDelimiter);
		}

		public static void SetStrings(this ContentData contentData, string propertyName, IEnumerable<string> strings, char delimiter)
		{
			if(contentData == null)
				throw new ArgumentNullException("contentData");

			contentData[propertyName] = string.Join(delimiter.ToString(CultureInfo.InvariantCulture), (strings ?? Enumerable.Empty<string>()));
		}

		#endregion
	}
}