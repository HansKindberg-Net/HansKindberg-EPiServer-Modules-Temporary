using System.Security.Principal;
using System.Web;
using HansKindberg.EPiServer.Modules.TestApplication.Business.Security;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.Web.Security
{
	public class SecurityContext : ISecurityContext
	{
		#region Properties

		public virtual IPrincipal Principal
		{
			get { return HttpContext.Current != null ? HttpContext.Current.User : null; }
		}

		#endregion
	}
}