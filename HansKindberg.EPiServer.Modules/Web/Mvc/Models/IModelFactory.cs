namespace HansKindberg.EPiServer.Modules.Web.Mvc.Models
{
	public interface IModelFactory
	{
		#region Methods

		T Create<T>();

		#endregion
	}
}