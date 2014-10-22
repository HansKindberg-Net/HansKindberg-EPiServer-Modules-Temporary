namespace HansKindberg.EPiServer.Modules.ModuleTemplate.Models
{
	public class TemplateViewModel : ViewModel
	{
		#region Constructors

		public TemplateViewModel(ILayoutModel layout) : base(layout) {}

		#endregion

		#region Properties

		public virtual string Heading
		{
			get { return "Heading coming from the view-model."; }
		}

		#endregion
	}
}