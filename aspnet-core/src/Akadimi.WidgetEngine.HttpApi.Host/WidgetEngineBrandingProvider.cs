using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Akadimi.WidgetEngine;

[Dependency(ReplaceServices = true)]
public class WidgetEngineBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "WidgetEngine";
}
