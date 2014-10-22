using System.ComponentModel.DataAnnotations;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace HansKindberg.EPiServer.Modules.TestApplication.Models.Pages
{
	[ContentType(GUID = "DAE07158-63ED-4572-AFE1-BAD9AF636E19", Order = 10000)]
	public class StartPage : MainBodyPage
	{
		#region Properties

		[CultureSpecific]
		[Display(GroupName = SystemTabNames.Settings, Order = 200)]
		public virtual string NavigationItemName { get; set; }

		#endregion
	}
}