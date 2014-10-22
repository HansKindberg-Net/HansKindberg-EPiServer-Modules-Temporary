using System;
using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyDescription("My first EPiServer-module.")]
[assembly: CLSCompliant(true)]
[assembly: Guid("17e1560c-12dc-47d0-a993-742582fa349d")]

// ReSharper disable CheckNamespace
internal static class AssemblyInfo
// ReSharper restore CheckNamespace
{
	#region Fields

	internal const string AssemblyName = "HansKindberg.EPiServer.Modules.ModuleTemplate";

	#endregion
}