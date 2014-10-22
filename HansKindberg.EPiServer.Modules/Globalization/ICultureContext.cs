using System.Globalization;

namespace HansKindberg.EPiServer.Modules.Globalization
{
	public interface ICultureContext
	{
		#region Properties

		CultureInfo Culture { get; }
		CultureInfo UiCulture { get; }

		#endregion
	}
}