using System;
using System.Reflection;
using EPiServer.Shell;

namespace HansKindberg.EPiServer.Shell
{
	public class PathsWrapper : IPaths
	{
		#region Properties

		public virtual string ProtectedRootPath
		{
			get { return Paths.ProtectedRootPath; }
		}

		public virtual string PublicRootPath
		{
			get { return Paths.PublicRootPath; }
		}

		public virtual string ShellModuleName
		{
			get { return Paths.ShellModuleName; }
		}

		#endregion

		#region Methods

		public virtual string ToClientResource(Assembly moduleAssembly, string moduleRelativeClientResourcePath)
		{
			return Paths.ToClientResource(moduleAssembly, moduleRelativeClientResourcePath);
		}

		public virtual string ToClientResource(string moduleName, string moduleRelativeClientResourcePath)
		{
			return Paths.ToClientResource(moduleName, moduleRelativeClientResourcePath);
		}

		public virtual string ToClientResource(Type typeInModuleAssembly, string moduleRelativeClientResourcePath)
		{
			return Paths.ToClientResource(typeInModuleAssembly, moduleRelativeClientResourcePath);
		}

		public virtual string ToResource(Assembly moduleAssembly, string moduleRelativeResourcePath)
		{
			return Paths.ToResource(moduleAssembly, moduleRelativeResourcePath);
		}

		public virtual string ToResource(string moduleName, string moduleRelativeResourcePath)
		{
			return Paths.ToResource(moduleName, moduleRelativeResourcePath);
		}

		public virtual string ToResource(Type typeInModuleAssembly, string moduleRelativeResourcePath)
		{
			return Paths.ToResource(typeInModuleAssembly, moduleRelativeResourcePath);
		}

		public virtual string ToShellClientResource(string shellModuleRelativeClientResourcePath)
		{
			return Paths.ToShellClientResource(shellModuleRelativeClientResourcePath);
		}

		public virtual string ToShellResource(string shellModuleRelativeResourcePath)
		{
			return Paths.ToShellResource(shellModuleRelativeResourcePath);
		}

		#endregion
	}
}