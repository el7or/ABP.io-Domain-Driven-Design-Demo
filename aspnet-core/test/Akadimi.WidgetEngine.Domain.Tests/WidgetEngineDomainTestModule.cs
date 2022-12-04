using Akadimi.WidgetEngine.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Akadimi.WidgetEngine;

[DependsOn(
    typeof(WidgetEngineEntityFrameworkCoreTestModule)
    )]
public class WidgetEngineDomainTestModule : AbpModule
{

}
