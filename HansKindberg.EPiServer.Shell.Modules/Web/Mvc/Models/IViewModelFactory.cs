namespace HansKindberg.EPiServer.Shell.Modules.Web.Mvc.Models
{
	public interface IViewModelFactory
	{
		#region Methods

		T Create<T>() where T : ILayoutViewModel;

		#endregion
	}
}