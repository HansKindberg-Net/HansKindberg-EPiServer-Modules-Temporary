using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

namespace HansKindberg.EPiServer.Modules.TestApplication.Models.Files
{
	[ContentType]
	[MediaDescriptor(ExtensionString = "doc,docx,pdf,txt,xls,xlsx")]
	public class TextFile : MediaData
	{
		#region Properties

		[CultureSpecific]
		public virtual string Description { get; set; }

		#endregion
	}
}