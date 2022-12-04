using System.Threading.Tasks;

namespace Akadimi.WidgetEngine.Data;

public interface IWidgetEngineDbSchemaMigrator
{
    Task MigrateAsync();
}
