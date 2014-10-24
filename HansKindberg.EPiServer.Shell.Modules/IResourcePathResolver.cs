namespace HansKindberg.EPiServer.Shell.Modules
{
	public interface IResourcePathResolver
	{
		#region Methods

		string GetResourcePath(string moduleRelativeResourcePath);
		string GetResourcePath(string moduleName, string moduleRelativeResourcePath);

		#endregion
	}
}