using Akadimi.WidgetEngine.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Akadimi.WidgetEngine.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(WidgetEngineEntityFrameworkCoreModule),
    typeof(WidgetEngineApplicationContractsModule)
    )]
public class WidgetEngineDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
