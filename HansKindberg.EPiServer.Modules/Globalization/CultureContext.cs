using System.Globalization;

namespace HansKindberg.EPiServer.Modules.Globalization
{
	public class CultureContext : ICultureContext
	{
		#region Properties

		public virtual CultureInfo Culture
		{
			get { return CultureInfo.CurrentCulture; }
		}

		public virtual CultureInfo UiCulture
		{
			get { return CultureInfo.CurrentUICulture; }
		}

		#endregion
	}
}