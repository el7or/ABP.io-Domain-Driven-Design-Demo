using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Akadimi.WidgetEngine.Data;
using Volo.Abp.DependencyInjection;

namespace Akadimi.WidgetEngine.EntityFrameworkCore;

public class EntityFrameworkCoreWidgetEngineDbSchemaMigrator
    : IWidgetEngineDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreWidgetEngineDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the WidgetEngineDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<WidgetEngineDbContext>()
            .Database
            .MigrateAsync();
    }
}
