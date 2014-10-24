using System;
using StructureMap;

namespace HansKindberg.EPiServer.Shell.Modules.Web.Mvc.Models
{
	public class ViewModelFactory : IViewModelFactory
	{
		#region Fields

		private readonly IContainer _container;

		#endregion

		#region Constructors

		public ViewModelFactory(IContainer container)
		{
			if(container == null)
				throw new ArgumentNullException("container");

			this._container = container;
		}

		#endregion

		#region Properties

		protected internal virtual IContainer Container
		{
			get { return this._container; }
		}

		#endregion

		#region Methods

		public virtual T Create<T>() where T : ILayoutViewModel
		{
			return this.Container.GetInstance<T>();
		}

		#endregion
	}
}