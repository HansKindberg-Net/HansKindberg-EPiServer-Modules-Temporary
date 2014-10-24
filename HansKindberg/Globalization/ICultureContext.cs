using System.Globalization;

namespace HansKindberg.Globalization
{
	public interface ICultureContext
	{
		#region Properties

		CultureInfo Culture { get; }
		CultureInfo UiCulture { get; }

		#endregion
	}
}