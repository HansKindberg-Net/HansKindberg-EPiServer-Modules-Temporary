using System;
using StructureMap;

namespace HansKindberg.EPiServer.Modules.Web.Mvc.Models
{
	public class ModelFactory : IModelFactory
	{
		#region Fields

		private readonly IContainer _container;

		#endregion

		#region Constructors

		public ModelFactory(IContainer container)
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

		public virtual T Create<T>()
		{
			return default(T);
		}

		#endregion
	}
}