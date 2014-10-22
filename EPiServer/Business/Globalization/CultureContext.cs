using System.Globalization;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.Globalization
{
	public class CultureContext : ICultureContext
	{
		#region Properties

		public virtual CultureInfo CurrentCulture
		{
			get { return CultureInfo.CurrentCulture; }
		}

		public virtual CultureInfo CurrentUiCulture
		{
			get { return CultureInfo.CurrentUICulture; }
		}

		#endregion
	}
}