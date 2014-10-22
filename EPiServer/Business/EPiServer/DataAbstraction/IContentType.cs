using System;
using EPiServer.Data.Entity;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.DataAbstraction
{
	public interface IContentType : IEquatable<IContentType>, IReadOnly<IContentType>
	{
		#region Properties

		string Description { get; set; }
		string DisplayName { get; set; }
		string FullName { get; }
		string GroupName { get; set; }
		Guid Guid { get; set; }
		int Id { get; set; }
		bool IsAvailable { get; set; }
		bool IsNew { get; }
		string LocalizedDescription { get; }
		string LocalizedFullName { get; }
		string LocalizedGroupName { get; }
		string LocalizedName { get; }
		string Name { get; set; }
		int SortOrder { get; set; }

		#endregion
	}
}