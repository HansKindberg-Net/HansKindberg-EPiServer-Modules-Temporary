using System;
using System.Reflection;

namespace HansKindberg.EPiServer.Shell
{
	public interface IPaths
	{
		#region Properties

		string ProtectedRootPath { get; }
		string PublicRootPath { get; }
		string ShellModuleName { get; }

		#endregion

		#region Methods

		string ToClientResource(Assembly moduleAssembly, string moduleRelativeClientResourcePath);
		string ToClientResource(string moduleName, string moduleRelativeClientResourcePath);
		string ToClientResource(Type typeInModuleAssembly, string moduleRelativeClientResourcePath);
		string ToResource(Assembly moduleAssembly, string moduleRelativeResourcePath);
		string ToResource(string moduleName, string moduleRelativeResourcePath);
		string ToResource(Type typeInModuleAssembly, string moduleRelativeResourcePath);
		string ToShellClientResource(string shellModuleRelativeClientResourcePath);
		string ToShellResource(string shellModuleRelativeResourcePath);

		#endregion
	}
}