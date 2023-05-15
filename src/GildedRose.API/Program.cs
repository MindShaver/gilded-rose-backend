using GildedRose.Repository;
using GildedRose.Repository.Commands.Items;
using GildedRose.Repository.Queries.Items;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace GildedRose.API
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var config = BuildConfiguration();
            var connectionString = config.GetSection("ConnectionStrings").GetValue<string>("DefaultConnection");

            builder.Services.AddDbContext<GildedDbContext>(optionsBuilder =>
            optionsBuilder.UseNpgsql(connectionString ?? "Host=localhost")
            );

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gilded Rose API", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            // Add services to the container.
            RegisterQueries(builder.Services);
            RegisterDependencies(builder.Services);

            var startup = new Startup(builder.Configuration);
            startup.ConfigureServices(builder.Services);

            builder.Services.AddControllers();
            builder.Services.AddMediatR(typeof(Program).Assembly);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseHttpsRedirection();
            app.UseRouting();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gilded Rose API V1");
            });

            app.UseAuthorization();
            startup.Configure(app, builder.Environment);

            app.MapControllers();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }


        private static void RegisterQueries(IServiceCollection serviceCollection)
        {
            //serviceCollection.AddTransient<IGetPagedProductsQuery, GetPagedProductsQuery>();
            serviceCollection.AddTransient<ISeedItemsCommand, SeedItemsCommand>();
            serviceCollection.AddTransient<IGetAllItemsQuery, GetAllItemsQuery>();
            serviceCollection.AddTransient<IDeleteAllItemsCommand, DeleteAllItemsCommand>();
            serviceCollection.AddTransient<IUpdateProcessedItemsCommand, UpdateProcessedItemsCommand>();
            serviceCollection.AddTransient<IGetItemByIdQuery, GetItemByIdQuery>();
            serviceCollection.AddTransient<ICreateItemCommand, CreateItemCommand>();
            serviceCollection.AddTransient<IDeleteItemByIdCommand, DeleteItemByIdCommand>();
        }

        private static void RegisterDependencies(IServiceCollection serviceCollection)
        {
            
        }

        private static IConfiguration BuildConfiguration()
        {
            var config = new ConfigurationBuilder();

            if (File.Exists("appsettings.json"))
            {
                config.AddJsonFile("appsettings.json");
            }

            config.AddEnvironmentVariables();

            return config.Build();
        }
    }
}