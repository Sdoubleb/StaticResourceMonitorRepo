using System;
using System.Web;
using StaticResourceMonitor.Downloads;
using StaticResourceMonitor.Statistics;
using StaticResourceMonitor.Users;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Injection;
using Unity.Lifetime;

namespace StaticResourceMonitor
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            container.RegisterInstance<IUserStorage>(new UserStorage());
            container.RegisterInstance<IDownloadStorage>(new DownloadStorage());

            container.RegisterType<IUserProvider>(new PerRequestLifetimeManager(),
                new InjectionFactory(c => new CookieUserProvider(CurrentHttpContext,
                    container.Resolve<IUserStorage>())));
            container.RegisterType<UserInfo>(new PerRequestLifetimeManager(),
                new InjectionFactory(c => c.Resolve<IUserProvider>().ProvideUser()));
            container.RegisterType<IDownloadStatisticCalculator>(new TransientLifetimeManager(),
                new InjectionFactory(c => new DownloadStatisticCalculator(c.Resolve<IDownloadStorage>())));
        }

        private static HttpContextBase CurrentHttpContext
            => HttpContext.Current.Request.RequestContext.HttpContext;
    }
}