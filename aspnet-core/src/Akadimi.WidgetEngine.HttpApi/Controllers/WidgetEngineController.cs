using Akadimi.WidgetEngine.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Akadimi.WidgetEngine.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class WidgetEngineController : AbpControllerBase
{
    protected WidgetEngineController()
    {
        LocalizationResource = typeof(WidgetEngineResource);
    }
}
