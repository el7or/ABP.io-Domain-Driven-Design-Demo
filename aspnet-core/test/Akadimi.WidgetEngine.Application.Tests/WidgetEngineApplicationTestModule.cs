using Volo.Abp.Modularity;

namespace Akadimi.WidgetEngine;

[DependsOn(
    typeof(WidgetEngineApplicationModule),
    typeof(WidgetEngineDomainTestModule)
    )]
public class WidgetEngineApplicationTestModule : AbpModule
{

}
