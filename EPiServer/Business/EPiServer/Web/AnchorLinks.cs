namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Web
{
	public static class AnchorLinks
	{
		#region Fields

		private static volatile IAnchorLinks _instance;
		private static readonly object _lockObject = new object();

		#endregion

		#region Properties

		public static string Empty
		{
			get { return Instance.Empty; }
		}

		public static string Inactive
		{
			get { return Instance.Inactive; }
		}

		public static IAnchorLinks Instance
		{
			get
			{
				if(_instance == null)
				{
					lock(_lockObject)
					{
						if(_instance == null)
							_instance = new DefaultAnchorLinks();
					}
				}

				return _instance;
			}
			set
			{
				if(_instance == value)
					return;

				lock(_lockObject)
				{
					_instance = value;
				}
			}
		}

		#endregion
	}
}