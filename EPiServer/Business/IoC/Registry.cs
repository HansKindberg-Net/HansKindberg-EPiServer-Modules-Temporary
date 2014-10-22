using System;
using System.Diagnostics.CodeAnalysis;
using System.Web;
using System.Web.Caching;
using System.Web.SessionState;
using EPiServer.Filters;
using EPiServer.Security;
using HansKindberg.EPiServer.Modules.TestApplication.Business.Collections;
using HansKindberg.EPiServer.Modules.TestApplication.Business.Collections.Specialized;
using HansKindberg.EPiServer.Modules.TestApplication.Business.Configuration;
using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Collections;
using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Core;
using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Filters;
using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Web;
using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Web.Html;
using HansKindberg.EPiServer.Modules.TestApplication.Business.Globalization;
using HansKindberg.EPiServer.Modules.TestApplication.Business.Pagination;
using HansKindberg.EPiServer.Modules.TestApplication.Business.Web;
using HansKindberg.EPiServer.Modules.TestApplication.Business.Web.Collections.Specialized;
using HansKindberg.EPiServer.Modules.TestApplication.Models.ViewModels;
using StructureMap.Configuration.DSL;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.IoC
{
	public class Registry : StructureMap.Configuration.DSL.Registry
	{
		#region Constructors

		public Registry()
		{
			Register(this);
		}

		#endregion

		#region Methods

		[SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling")]
		public static void Register(IRegistry registry)
		{
			if(registry == null)
				throw new ArgumentNullException("registry");

			registry.For<FilterAccess>().Singleton().Use(new FilterAccess(AccessLevel.Read));
			//registry.For<FilterTemplate>().Singleton().Use<FilterTemplate>();

			registry.For<IAnchorLinks>().Singleton().Use<DefaultAnchorLinks>();
			registry.For<IApplicationConfiguration>().Singleton().Use<AreaConfiguration>();
			registry.For<IApplicationConfiguration>().Singleton().Use<BundleConfiguration>();
			registry.For<IApplicationConfiguration>().Singleton().Use<FilterConfiguration>();
			registry.For<IContentCollectionFactory>().Singleton().Use<ContentCollectionFactory>().Ctor<IContentFilter>("visibleInMenuFilter").Is<VisibleInMenuFilter>().Ctor<bool>("cast").Is(true);
			registry.For<IContentFilter>().Singleton().Use<FilterContentForVisitor>();
			registry.For<IContentHtmlLinkFactory>().Singleton().Use<ContentHtmlLinkFactory>();
			registry.For<IContentLinkResolver>().Singleton().Use<ContentLinkResolver>();
			registry.For<IContentReferenceRepository>().Singleton().Use<ContentReferenceRepository>();
			registry.For<ICultureContext>().Singleton().Use<CultureContext>();
			registry.For<IHttpEncoder>().Singleton().Use<HttpUtilityWrapper>();
			registry.For<IItemCollectionFactory>().Singleton().Use<ItemCollectionFactory>();
			registry.For<ILayoutModel>().HybridHttpOrThreadLocalScoped().Use<LayoutModel>();
			registry.For<INameValueCollectionParser>().Singleton().Use<NameValueCollectionParser>();
			registry.For<IPaginationFactory>().Singleton().Use<PaginationFactory>();
			registry.For<IPaginationValidator>().Singleton().Use<Web.Pagination.PaginationValidator>();
			registry.For<IViewModelFactory>().Singleton().Use<ViewModelFactory>();

			//registry.For<ClientSection>().Use((ClientSection) ConfigurationManager.GetSection("system.serviceModel/client"));

			//registry.For<ICache>().Singleton().Use<CacheWrapper>();
			//registry.For<ICacheHandlerFactory>().Singleton().Use<CacheHandlerFactory>();
			//registry.For<ICommissionMemberParser>().Singleton().Use<CommissionMemberParser>();
			//registry.For<IContentFilter>().Singleton().Use<FilterContentForVisitor>();
			//registry.For<IContentIdentityMapContext>().Singleton().Use<ContentIdentityMapContext>();
			//registry.For<IContentIdentityMapFactory>().Singleton().Use<SqlContentIdentityMapFactory>().Ctor<DbProviderFactory>("dbProviderFactory").Is(DbProviderFactories.GetFactory(ExtensionDatabaseConnectionStringSettings.ProviderName)).Ctor<string>("connectionString").Is(ExtensionDatabaseConnectionStringSettings.ConnectionString);
			//registry.For<IDateTimeContext>().Singleton().Use<DateTimeContext>();
			//registry.For<IDateTimeParser>().Singleton().Use<DateTimeParser>();
			//registry.For<IDateTimeParseSetting>().Singleton().Use(new DateTimeParseSetting(new[] {"yyyyMMddHHmmss'Z'", "yyyy-MM-dd"}) {Local = true, Provider = CultureInfo.InvariantCulture, Styles = DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal});
			//registry.For<IDateTimeParseSetting>().Singleton().Use(new DateTimeParseSetting(new[] {"yyyyMMddHHmmss'Z'"}) {Local = true, Provider = CultureInfo.InvariantCulture, Styles = DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal});
			//registry.For<IDirectoryFactory>().Singleton().Use<CachedDirectoryFactory>();
			//registry.For<IDirectoryPrincipalRepositoryFactory>().Singleton().Use<DirectoryPrincipalRepositoryFactory>();
			//registry.For<IEventProviderService>().Singleton().Use<EventProviderServiceWrapper>();
			//registry.Forward<IEventProviderService, IEventPublisher>();
			//registry.Forward<IEventProviderService, IEventSubscriber>();
			//registry.For<IEventSubscriptionStore>().Singleton().Use<EventSubscriptionStore>();
			//registry.For<IFormsAuthentication>().Singleton().Use<FormsAuthenticationWrapper>();
			//registry.For<IFullNameResolver>().Singleton().Use<OrganizationDirectoryFullNameResolver>().Ctor<IOrganizationDirectory>("organizationDirectory").Is((structureMap) => structureMap.GetInstance<IOrganizationDirectoryContext>().Get("OrganizationDirectory"));
			//registry.For<IIdentityMappedContentVersionRepositoryFactory>().Singleton().Use<SqlIdentityMappedContentVersionRepositoryFactory>().Ctor<DbProviderFactory>("dbProviderFactory").Is(DbProviderFactories.GetFactory(ExtensionDatabaseConnectionStringSettings.ProviderName)).Ctor<string>("connectionString").Is(ExtensionDatabaseConnectionStringSettings.ConnectionString);

			//registry.For<IMembership>().Singleton().Use<MembershipWrapper>();
			//registry.For<IMultipleUserNameFormatsMembershipProvider>().Singleton().Use<MembershipWrapper>();
			//registry.For<IOrganizationDirectoryContext>().Singleton().Use<OrganizationDirectoryContext>();
			//registry.For<IOrganizationDirectoryFactory>().Singleton().Use<CachedOrganizationDirectoryFactory>()
			//	.Ctor<ILog>("log").Is(LogManager.GetLogger(typeof(OrganizationDirectory)));
			//registry.For<IOrganizationDirectorySettings>().Singleton().Use<OrganizationDirectorySettings>();

			//registry.For<IParameterKeys>().Singleton().Use<DefaultParameterKeys>();
			//registry.For<IPrincipalConnectionParser>().Singleton().Use(new PrincipalConnectionParser());
			//registry.For<IPrincipalRepositoryContext>().Singleton().Use<PrincipalRepositoryContext>();
			//registry.For<IPrincipalRepositoryFactory>().Singleton().Use<PrincipalRepositoryFactory>();
			//registry.For<IProfileRepository>().Singleton().Use<ProfileRepository>();
			//registry.For<IPropertyValueResolverFactory>().Singleton().Use<PropertyValueResolverFactory>()
			//	.Ctor<ILog>("log").Is(LogManager.GetLogger(typeof(PropertyValueResolver)));
			//registry.For<IRoles>().Singleton().Use<RolesWrapper>();
			//registry.For<ISecurityContext>().Singleton().Use<SecurityContext>();
			//registry.For<ISecurityIdentifierRepository>().Singleton().Use<SecurityIdentifierRepository>();
			//registry.For<IThread>().Singleton().Use<ThreadWrapper>();
			//registry.For<ITranslationExtension>().Singleton().Use<DefaultTranslationExtension>();
			//registry.For<IUrlSegmentFactory>().Singleton().Use<UrlSegmentFactory>();
			//registry.For<IWildcardHandler>().Singleton().Use<WildcardHandler>();
			//registry.For<IWindowsCredentialsValidator>().Singleton().Use<WindowsCredentialsValidator>();
			//registry.For<ServicesSection>().Use((ServicesSection) ConfigurationManager.GetSection("system.serviceModel/services"));

			// Web
			registry.For<Cache>().Singleton().Use(() => HttpRuntime.Cache);
			registry.For<HttpApplicationState>().HybridHttpOrThreadLocalScoped().Use(() => HttpContext.Current.Application);
			registry.For<HttpApplicationStateBase>().HybridHttpOrThreadLocalScoped().Use<HttpApplicationStateWrapper>();
			registry.For<HttpContext>().HybridHttpOrThreadLocalScoped().Use(() => HttpContext.Current);
			registry.For<HttpContextBase>().HybridHttpOrThreadLocalScoped().Use<HttpContextWrapper>();
			registry.For<HttpRequest>().HybridHttpOrThreadLocalScoped().Use(() => HttpContext.Current.Request);
			registry.For<HttpRequestBase>().HybridHttpOrThreadLocalScoped().Use<HttpRequestWrapper>();
			registry.For<HttpResponse>().HybridHttpOrThreadLocalScoped().Use(() => HttpContext.Current.Response);
			registry.For<HttpResponseBase>().HybridHttpOrThreadLocalScoped().Use<HttpResponseWrapper>();
			registry.For<HttpServerUtility>().HybridHttpOrThreadLocalScoped().Use(() => HttpContext.Current.Server);
			registry.For<HttpServerUtilityBase>().HybridHttpOrThreadLocalScoped().Use<HttpServerUtilityWrapper>();
			registry.For<HttpSessionState>().HybridHttpOrThreadLocalScoped().Use(() => HttpContext.Current.Session);
			registry.For<HttpSessionStateBase>().HybridHttpOrThreadLocalScoped().Use<HttpSessionStateWrapper>();
		}

		#endregion
	}
}