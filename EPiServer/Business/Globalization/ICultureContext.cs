using System.Globalization;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.Globalization
{
	public interface ICultureContext
	{
		#region Properties

		CultureInfo CurrentCulture { get; }
		CultureInfo CurrentUiCulture { get; }

		#endregion
	}
}