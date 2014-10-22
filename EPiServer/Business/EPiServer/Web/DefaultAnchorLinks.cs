namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Web
{
	public class DefaultAnchorLinks : IAnchorLinks
	{
		#region Fields

		private const string _empty = "#empty-link";
		private const string _inactive = "#inactive-link";

		#endregion

		#region Properties

		public virtual string Empty
		{
			get { return _empty; }
		}

		public virtual string Inactive
		{
			get { return _inactive; }
		}

		#endregion
	}
}