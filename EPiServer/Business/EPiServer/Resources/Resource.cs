using System;
using EPiServer.Framework.Localization;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Resources
{
	public class Resource
	{
		#region Fields

		private readonly LocalizationService _localizationService;

		#endregion

		#region Constructors

		public Resource(LocalizationService localizationService)
		{
			if(localizationService == null)
				throw new ArgumentNullException("localizationService");

			this._localizationService = localizationService;
		}

		#endregion

		#region Properties

		protected internal virtual LocalizationService LocalizationService
		{
			get { return this._localizationService; }
		}

		#endregion
	}
}