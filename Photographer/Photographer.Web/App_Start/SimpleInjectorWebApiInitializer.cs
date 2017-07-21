[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(PhotographerPerformance.Web.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace PhotographerPerformance.Web.App_Start
{
    using System.Web.Http;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using System.Data.Entity;
    using PhotographerPerformance.Data;
    using System.Reflection;
    using System.Linq;
    using PhotographerPerformance.Data.Repositories;
    using PhotographerPerformance.Services;
    using SimpleInjector.Lifestyles;

    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            
            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
       
            container.Verify();
            
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void InitializeContainer(Container container)
        {
            // DbContext
            container.Register<DbContext, PhotographerDbContext>(Lifestyle.Scoped);

            // Repositories
            BatchRegistration(container, typeof(PhotographerRepository).Assembly, "PhotographerPerformance.Data.Repositories");

            // Services
            BatchRegistration(container, typeof(PhotographerService).Assembly, "PhotographerPerformance.Services");
        }

        private static void BatchRegistration(Container container, Assembly assembly, string typeNamespace)
        {
            var registrations = assembly.GetExportedTypes()
                .Where(type => type.Namespace == typeNamespace && type.IsClass && type.GetInterfaces().Any())
                .Select(type => new
                {
                    Service = type.GetInterfaces().Last(),
                    Implementation = type
                });

            foreach (var registration in registrations)
            {
                container.Register(registration.Service, registration.Implementation, Lifestyle.Scoped);
            }
        }
    }
}