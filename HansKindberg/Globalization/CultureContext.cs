using System.Globalization;

namespace HansKindberg.Globalization
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