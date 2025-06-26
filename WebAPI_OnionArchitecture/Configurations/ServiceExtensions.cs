namespace WebAPI_OnionArchitecture.Configurations
{
    public static class ServiceExtensions
    {

        public static void ConfigureCors(this IServiceCollection services)
        {
            //Todo Will Be Modifed based on requirments
            services.AddCors( options => {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
                });
        }
    }
}
