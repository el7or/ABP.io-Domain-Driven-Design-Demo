using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Akadimi.WidgetEngine.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class WidgetEngineDbContextFactory : IDesignTimeDbContextFactory<WidgetEngineDbContext>
{
    public WidgetEngineDbContext CreateDbContext(string[] args)
    {
        WidgetEngineEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<WidgetEngineDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new WidgetEngineDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Akadimi.WidgetEngine.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
