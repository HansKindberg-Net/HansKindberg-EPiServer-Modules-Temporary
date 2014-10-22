using EPiServer.Filters;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Filters
{
	public interface ICountFilter : IContentFilter
	{
		#region Properties

		int Count { get; set; }

		#endregion
	}
}