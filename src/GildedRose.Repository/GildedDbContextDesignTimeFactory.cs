using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace GildedRose.Repository
{
    public class GildedDbContextDesignTimeFactory : IDesignTimeDbContextFactory<GildedDbContext>
    {
        public GildedDbContext CreateDbContext(string[] args)
        {
            var config = BuildConfiguration();
            var connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<GildedDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new GildedDbContext(optionsBuilder.Options);
        }

        private static IConfiguration BuildConfiguration()
        {
            var config = new ConfigurationBuilder();
            var localMigrationSettingPath = $"{Directory.GetCurrentDirectory()}/migrationsettings.json";
            var ciMigrationSettingsPath = $"{Directory.GetCurrentDirectory()}/../GildedRose.Repository/migrationsettings.json";

            AddJsonFileToConfiguration(config, localMigrationSettingPath, ciMigrationSettingsPath);
            config.AddEnvironmentVariables();

            return config.Build();
        }

        private static void AddJsonFileToConfiguration(IConfigurationBuilder config, params string[] jsonFilepaths)
        {
            var found = false;

            foreach (var jsonFilePath in jsonFilepaths)
            {
                if (File.Exists(jsonFilePath))
                {
                    found = true;
                    config.AddJsonFile(jsonFilePath);
                };
            }
        }
    }
}
