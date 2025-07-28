using System.Reflection;
using Contracts.RegisterServices;
namespace WebAPI_OnionArchitecture.Configurations
{
    public static class ServiceExtensions
    {

        public static void ConfigureCors(this IServiceCollection services)
        {
            //Todo Will Be Modifed based on requirments
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
            });
        }

        /// <summary>
        /// Registers all services implementing <see cref="ISingletone"/> from the specified assemblies 
        /// into the dependency injection container with a transient lifetime. Each class is registered 
        /// for all interfaces it implements, as well as itself.
        /// </summary>
        public static void ConfigureISingletoneService(this IServiceCollection services)
        {
           // Assembly targetAssemply = Assembly.Load("LoggerService");  
                Type interfaceType = typeof(ISingletone);

            Assembly[] assemblies = {
                                    Assembly.Load("LoggerService")
                                };

            foreach (Assembly targetAssemply in assemblies)
            {
                //Get Any thing implements ISingletone
                IEnumerable<Type> singletoneServices = targetAssemply.GetTypes()
                    .Where(t => interfaceType.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract);

                foreach (Type serviceType in singletoneServices)
                {
                    IEnumerable<Type> interfaces = serviceType.GetInterfaces().Where(i => i != typeof(ISingletone));

                    foreach (Type serviceIntefarce in interfaces)
                    {
                        // Register the class type for each interface it implements
                        services.AddSingleton(serviceIntefarce, serviceType);
                    }
                    // Register the class itself
                    services.AddSingleton(serviceType);
                }
            }
        }


        /// <summary>
        /// Registers all services implementing <see cref="IScopedService"/> from the specified assemblies 
        /// into the dependency injection container with a transient lifetime. Each class is registered 
        /// for all interfaces it implements, as well as itself.
        /// </summary>
        public static void ConfigureIScopedService(this IServiceCollection services)
        {
            // Assembly targetAssemply = Assembly.Load("LoggerService");  
            Type interfaceType = typeof(IScopedService);

            Assembly[] assemblies = {
                                    Assembly.Load("Repository")
                                };

            foreach (Assembly targetAssemply in assemblies)
            {
                //Get Any thing implements ISingletone
                IEnumerable<Type> scopedServices = targetAssemply.GetTypes()
                    .Where(t => interfaceType.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract);

                foreach (Type serviceType in scopedServices)
                {
                    IEnumerable<Type> interfaces = serviceType.GetInterfaces().Where(i => i != typeof(IScopedService));

                    foreach (Type serviceIntefarce in interfaces)
                    {
                        // Register the class type for each interface it implements
                        services.AddScoped(serviceIntefarce, serviceType);
                    }
                    // Register the class itself
                    services.AddScoped(serviceType);
                }
            }
        }
    }
}
