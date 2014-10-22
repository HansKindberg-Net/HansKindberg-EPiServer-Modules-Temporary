using System;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Sorting
{
	public interface ISortable
	{
		#region Properties

		DateTime Changed { get; }
		DateTime Created { get; }
		int Index { get; }
		string Name { get; }
		int Rank { get; }
		DateTime Saved { get; }
		DateTime StartPublish { get; }

		#endregion
	}
}