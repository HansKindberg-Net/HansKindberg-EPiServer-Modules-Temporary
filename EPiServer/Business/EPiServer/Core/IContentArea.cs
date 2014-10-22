using System.Collections.Generic;
using EPiServer.Core;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Core
{
	public interface IContentArea
	{
		#region Properties

		IList<ContentAreaItem> Items { get; }

		#endregion
	}
}