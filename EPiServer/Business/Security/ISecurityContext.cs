using System.Security.Principal;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.Security
{
	public interface ISecurityContext
	{
		#region Properties

		IPrincipal Principal { get; }

		#endregion
	}
}