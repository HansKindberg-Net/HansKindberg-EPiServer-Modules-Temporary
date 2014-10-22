using System;
using System.Collections.Generic;
using System.Linq;
using EPiServer;
using EPiServer.Web.Routing;
using HansKindberg.EPiServer.Modules.TestApplication.Models.Pages;
using StructureMap;
using StructureMap.Pipeline;

namespace HansKindberg.EPiServer.Modules.TestApplication.Models.ViewModels
{
	public class ViewModelFactory : IViewModelFactory
	{
		#region Fields

		private readonly IContainer _container;
		private readonly IDictionary<Type, bool> _isPageViewModelTypeCache = new Dictionary<Type, bool>();

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

		protected internal virtual IDictionary<Type, bool> IsPageViewModelTypeCache
		{
			get { return this._isPageViewModelTypeCache; }
		}

		protected internal virtual PageRouteHelper PageRouteHelper
		{
			get { return this.Container.GetInstance<PageRouteHelper>(); }
		}

		#endregion

		#region Methods

		public virtual IPageViewModel<SitePageData> CreatePageViewModel()
		{
			var currentPage = (SitePageData) this.PageRouteHelper.Page;

			var pageViewModelType = typeof(PageViewModel<>).MakeGenericType(currentPage.GetOriginalType());

			return (IPageViewModel<SitePageData>) this.Container.GetInstance(pageViewModelType, new ExplicitArguments(new Dictionary<string, object> {{"currentPage", currentPage}}));
		}

		//public virtual IPageViewModel<TModel> CreatePageViewModel<TModel>(TModel page) where TModel : SitePageData
		//{
		//	var pageViewModelType = typeof(PageViewModel<>).MakeGenericType(page.GetOriginalType());

		//	return (IPageViewModel<TModel>) this.Container.GetInstance(pageViewModelType, new ExplicitArguments(new Dictionary<string, object> {{"currentPage", page}, {"layout", LayoutModel.Empty}}));
		//}
		public virtual T CreateViewModel<T>()
		{
			if(this.IsPageViewModelType(typeof(T)))
				return this.Container.GetInstance<T>(new ExplicitArguments(new Dictionary<string, object> {{"currentPage", this.PageRouteHelper.Page}}));

			return this.Container.GetInstance<T>();
		}

		protected internal virtual bool IsAssignableToGenericType(Type type, Type genericType)
		{
			if(type == null)
				throw new ArgumentNullException("type");

			if(genericType == null)
				throw new ArgumentNullException("genericType");

			if(type.GetInterfaces().Any(interfaceType => interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == genericType))
				return true;

			if(type.IsGenericType && type.GetGenericTypeDefinition() == genericType)
				return true;

			Type baseType = type.BaseType;

			if(baseType == null)
				return false;

			return this.IsAssignableToGenericType(baseType, genericType);
		}

		protected internal virtual bool IsPageViewModelType(Type type)
		{
			bool isPageViewModelType;

			if(!this.IsPageViewModelTypeCache.TryGetValue(type, out isPageViewModelType))
			{
				isPageViewModelType = this.IsAssignableToGenericType(type, typeof(IPageViewModel<>));

				this.IsPageViewModelTypeCache.Add(type, isPageViewModelType);
			}

			return isPageViewModelType;
		}

		#endregion
	}
}