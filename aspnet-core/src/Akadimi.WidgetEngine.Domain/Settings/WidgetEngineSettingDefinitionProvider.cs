using Volo.Abp.Settings;

namespace Akadimi.WidgetEngine.Settings;

public class WidgetEngineSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(WidgetEngineSettings.MySetting1));
    }
}
