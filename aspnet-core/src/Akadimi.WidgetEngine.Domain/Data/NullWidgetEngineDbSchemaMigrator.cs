using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Akadimi.WidgetEngine.Data;

/* This is used if database provider does't define
 * IWidgetEngineDbSchemaMigrator implementation.
 */
public class NullWidgetEngineDbSchemaMigrator : IWidgetEngineDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
