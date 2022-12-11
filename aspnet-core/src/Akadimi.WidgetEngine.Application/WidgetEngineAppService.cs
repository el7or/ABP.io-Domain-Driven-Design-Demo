using Akadimi.WidgetEngine.Localization;
using Volo.Abp.Application.Services;

namespace Akadimi.WidgetEngine;

/* Inherit your application services from this class.
 */
public abstract class WidgetEngineAppService : ApplicationService
{
    protected WidgetEngineAppService()
    {
        LocalizationResource = typeof(WidgetEngineResource);
    }
}
