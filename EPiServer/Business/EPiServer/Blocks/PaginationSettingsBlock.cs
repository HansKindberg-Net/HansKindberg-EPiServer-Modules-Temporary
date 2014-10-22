using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using HansKindberg.EPiServer.Modules.TestApplication.Business.Pagination;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Blocks
{
	[ContentType(AvailableInEditMode = false, GUID = "5442AFE4-9D1C-4DD4-9FEA-F4896A1B539F")]
	public class PaginationSettingsBlock : BlockData, IPaginationSettings
	{
		#region Properties

		[Display(Order = 1)]
		public virtual bool Enabled { get; set; }

		[Display(Order = 3)]
		public virtual int? MaximumNumberOfDisplayedPages { get; set; }

		[Display(Order = 2)]
		public virtual int? PageSize { get; set; }

		#endregion
	}
}