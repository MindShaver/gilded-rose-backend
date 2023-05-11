using GildedRose.Repository;
using GildedRose.Repository.Commands.Items;
using GildedRose.Repository.Queries.Items;
using MediatR;
using Microsoft.EntityFrameworkCore;

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

            // Add services to the container.
            RegisterQueries(builder.Services);
            RegisterDependencies(builder.Services);

            var startup = new Startup(builder.Configuration);
            startup.ConfigureServices(builder.Services);

            builder.Services.AddControllers();
            builder.Services.AddMediatR(typeof(Program).Assembly);


            var app = builder.Build();
            startup.Configure(app, builder.Environment);

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        private static void RegisterQueries(IServiceCollection serviceCollection)
        {
            //serviceCollection.AddTransient<IGetPagedProductsQuery, GetPagedProductsQuery>();
            serviceCollection.AddTransient<ISeedItemsCommand, SeedItemsCommand>();
            serviceCollection.AddTransient<IGetAllItemsQuery, GetAllItemsQuery>();
            serviceCollection.AddTransient<IDeleteAllItemsCommand, DeleteAllItemsCommand>();
            serviceCollection.AddTransient<IUpdateProcessedItemsCommand, UpdateProcessedItemsCommand>();
        }

        private static void RegisterDependencies(IServiceCollection serviceCollection)
        {
            //serviceCollection.AddTransient<IJsonApiLinkFactory, JsonApiLinkFactory>();
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