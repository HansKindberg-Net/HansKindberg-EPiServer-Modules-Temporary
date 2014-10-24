using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using EPiServer.Framework.Localization;
using EPiServer.Framework.Web.Resources;
using HansKindberg.Globalization;

namespace HansKindberg.EPiServer.Shell.Modules.Web.Mvc.Models
{
	public class LayoutModel : ILayoutModel
	{
		#region Fields

		private readonly IClientResourceService _clientResourceService;
		private readonly ICultureContext _cultureContext;
		private string _description;
		private readonly LocalizationService _localizationService;
		private string _name;
		private readonly IPaths _paths;
		private string _title;
		private CultureInfo _uiCulture;

		#endregion

		#region Constructors

		public LayoutModel(ICultureContext cultureContext, LocalizationService localizationService, IPaths paths, IClientResourceService clientResourceService)
		{
			if(cultureContext == null)
				throw new ArgumentNullException("cultureContext");

			if(localizationService == null)
				throw new ArgumentNullException("localizationService");

			if(paths == null)
				throw new ArgumentNullException("paths");

			if(clientResourceService == null)
				throw new ArgumentNullException("clientResourceService");

			this._clientResourceService = clientResourceService;
			this._cultureContext = cultureContext;
			this._localizationService = localizationService;
			this._paths = paths;
		}

		#endregion

		#region Properties

		protected internal virtual IClientResourceService ClientResourceService
		{
			get { return this._clientResourceService; }
		}

		protected internal virtual ICultureContext CultureContext
		{
			get { return this._cultureContext; }
		}

		public virtual string Description
		{
			get { return this._description ?? (this._description = this.GetLocalizationValue("description") ?? string.Empty); }
		}

		public virtual string LocalizationPath { get; set; }

		protected internal virtual LocalizationService LocalizationService
		{
			get { return this._localizationService; }
		}

		public virtual string Name
		{
			get { return this._name ?? (this._name = this.GetLocalizationValue("name") ?? string.Empty); }
		}

		protected internal virtual IPaths Paths
		{
			get { return this._paths; }
		}

		public virtual string Title
		{
			get { return this._title ?? (this._title = this.Name ?? string.Empty); }
		}

		public virtual Type TypeInModuleAssembly { get; set; }

		public virtual CultureInfo UiCulture
		{
			get { return this._uiCulture ?? (this._uiCulture = this.CultureContext.UiCulture ?? CultureInfo.InvariantCulture); }
		}

		#endregion

		#region Methods

		public virtual IEnumerable<ClientResource> GetClientResources(string name)
		{
			return this.ClientResourceService.GetClientResources(name);
		}

		public virtual IEnumerable<ClientResource> GetClientResources(string name, IEnumerable<ClientResourceType> resourceTypes)
		{
			return this.ClientResourceService.GetClientResources(name, (resourceTypes ?? Enumerable.Empty<ClientResourceType>()).ToArray());
		}

		protected internal virtual string GetLocalizationValue(string relativeKey)
		{
			if(relativeKey == null)
				throw new ArgumentNullException("relativeKey");

			if(this.LocalizationPath == null)
				return string.Format(CultureInfo.InvariantCulture, "[{0}: LocalizationPath not set]", relativeKey);

			return this.LocalizationService.GetString(Path.Combine(this.LocalizationPath, relativeKey).Replace("\\", "/")) ?? string.Empty;
		}

		public virtual string GetResourcePath(string moduleRelativeResourcePath)
		{
			return this.Paths.ToResource(this.TypeInModuleAssembly, moduleRelativeResourcePath);
		}

		public virtual string GetResourcePath(string moduleName, string moduleRelativeResourcePath)
		{
			return this.Paths.ToResource(moduleName, moduleRelativeResourcePath);
		}

		#endregion
	}
}