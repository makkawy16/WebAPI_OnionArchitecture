using Microsoft.EntityFrameworkCore;
using NLog;
using Repository.Context;
using WebAPI_OnionArchitecture.Configurations;

namespace WebAPI_OnionArchitecture
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            string? logPath = builder.Configuration.GetValue<string>("PathForLog");
            LogManager.Setup().LoadConfigurationFromFile(Path.Combine(logPath ?? "", "nlog.config"));

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"), b => b.MigrationsAssembly("WebAPI_OnionArchitecture"));
            });

            builder.Services.ConfigureCors();

            builder.Services.ConfigureISingletoneService();
            builder.Services.ConfigureIScopedService();
            //builder.Services.AddSingleton<ILoggerManager, LoggerManager>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
