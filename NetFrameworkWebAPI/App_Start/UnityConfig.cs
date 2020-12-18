using System.Web.Http;
using AssessmentDemo.Foundation.Interfaces;
using AssessmentDemo.Foundation.Services;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace NetFrameworkWebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IAmUseless, AmUseless>(new HierarchicalLifetimeManager());
            container.RegisterType<IGiftsService, GiftsService>(new HierarchicalLifetimeManager());

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}