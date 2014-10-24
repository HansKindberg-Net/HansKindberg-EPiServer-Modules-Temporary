namespace HansKindberg.EPiServer.Shell.Modules.Web.Mvc.Models
{
	public interface ILayoutViewModel : IResourcePathResolver
	{
		#region Properties

		string Description { get; }
		ILayoutModel Layout { get; }
		string Name { get; }

		#endregion
	}
}