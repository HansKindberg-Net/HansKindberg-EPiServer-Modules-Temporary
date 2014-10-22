using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

namespace HansKindberg.EPiServer.Modules.TestApplication.Models.Files
{
	[ContentType]
	[MediaDescriptor(ExtensionString = "jpg,jpeg,jpe,gif,bmp,png")]
	public class ImageFile : ImageData
	{
		#region Properties

		[CultureSpecific]
		public virtual string AlternativeText { get; set; }

		[CultureSpecific]
		public virtual string Description { get; set; }

		#endregion
	}
}