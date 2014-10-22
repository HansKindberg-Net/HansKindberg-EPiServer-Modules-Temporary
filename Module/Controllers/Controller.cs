using System;
using HansKindberg.EPiServer.Modules.Web.Mvc.Models;

namespace HansKindberg.EPiServer.Modules.ModuleTemplate.Controllers
{
	public abstract class Controller
	{
		#region Fields

		private readonly IModelFactory _modelFactory;

		#endregion

		#region Constructors

		protected Controller(IModelFactory modelFactory)
		{
			if(modelFactory == null)
				throw new ArgumentNullException("modelFactory");

			this._modelFactory = modelFactory;
		}

		#endregion

		#region Properties

		protected internal virtual IModelFactory ModelFactory
		{
			get { return this._modelFactory; }
		}

		#endregion
	}
}