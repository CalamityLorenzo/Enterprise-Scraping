
using DbService;
using Microsoft.EntityFrameworkCore;
using ScrapingAppDefinitions;

namespace ScrapingBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddHttpClient();
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration["DbConn"]));
            builder.Services.AddScoped<IDbService, DbRepository>();
            if (!String.IsNullOrEmpty(builder.Configuration["ApplicationInsightsConn"]))
            {
                builder.Logging.AddApplicationInsights(
                  configureTelemetryConfiguration: (config) =>
                config.ConnectionString = builder.Configuration["ApplicationInsightsConn"],
                configureApplicationInsightsLoggerOptions: (options) => { });
            }

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
