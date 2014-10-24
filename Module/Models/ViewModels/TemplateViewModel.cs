using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Framework.Localization;
using HansKindberg.Collections.Specialized;
using HansKindberg.EPiServer.ModuleTemplate.Business;
using HansKindberg.EPiServer.Shell.Modules.Web.Mvc.Models;

namespace HansKindberg.EPiServer.ModuleTemplate.Models.ViewModels
{
	public class TemplateViewModel : LayoutViewModel
	{
		#region Fields

		private ITemplateTab _activeTab;
		private readonly HttpRequestBase _httpRequest;
		private readonly INameValueCollectionParser _nameValueCollectionParser;
		private const string _tabKey = "Tab";
		private IEnumerable<ITemplateTab> _tabs;

		#endregion

		#region Constructors

		public TemplateViewModel(ILayoutModel layout, LocalizationService localizationService, HttpRequestBase httpRequest, INameValueCollectionParser nameValueCollectionParser) : base(layout, localizationService)
		{
			if(httpRequest == null)
				throw new ArgumentNullException("httpRequest");

			if(nameValueCollectionParser == null)
				throw new ArgumentNullException("nameValueCollectionParser");

			this._httpRequest = httpRequest;
			this._nameValueCollectionParser = nameValueCollectionParser;
		}

		#endregion

		#region Properties

		public virtual ITemplateTab ActiveTab
		{
			get { return this._activeTab ?? (this._activeTab = this.Tabs.First(tab => tab.Active)); }
		}

		protected internal virtual HttpRequestBase HttpRequest
		{
			get { return this._httpRequest; }
		}

		protected internal virtual INameValueCollectionParser NameValueCollectionParser
		{
			get { return this._nameValueCollectionParser; }
		}

		public virtual string TabKey
		{
			get { return _tabKey; }
		}

		public virtual IEnumerable<ITemplateTab> Tabs
		{
			get
			{
				if(this._tabs == null)
				{
					var tabs = new List<TemplateTab>();

					// ReSharper disable AssignNullToNotNullAttribute
					var uriBuilder = new UriBuilder(this.HttpRequest.Url);
					// ReSharper restore AssignNullToNotNullAttribute

					// ReSharper disable PossibleNullReferenceException
					var queryString = this.NameValueCollectionParser.Parse(this.HttpRequest.Url.Query);
					// ReSharper restore PossibleNullReferenceException

					// ReSharper disable LoopCanBeConvertedToQuery

					foreach(var tabType in (TemplateTabType[]) Enum.GetValues(typeof(TemplateTabType)))
					{
						var templateTab = new TemplateTab(tabType, this.LocalizationService)
						{
							LocalizationPath = this.Layout.LocalizationPath
						};

						templateTab.Active = templateTab.Name.Equals(this.HttpRequest.QueryString[this.TabKey], StringComparison.OrdinalIgnoreCase);

						queryString.Set(this.TabKey, templateTab.Name);

						uriBuilder.Query = queryString.ToString();

						templateTab.Url = uriBuilder.Uri;

						tabs.Add(templateTab);
					}

					if(!tabs.Any(tab => tab.Active))
						tabs.First().Active = true;

					// ReSharper restore LoopCanBeConvertedToQuery

					this._tabs = tabs.ToArray();
				}

				return this._tabs;
			}
		}

		#endregion
	}
}