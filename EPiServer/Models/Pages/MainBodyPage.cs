using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace HansKindberg.EPiServer.Modules.TestApplication.Models.Pages
{
	public abstract class MainBodyPage : SitePageData
	{
		#region Properties

		[CultureSpecific]
		[Display(GroupName = SystemTabNames.Content, Order = 100)]
		public virtual XhtmlString MainBody { get; set; }

		#endregion
	}
}