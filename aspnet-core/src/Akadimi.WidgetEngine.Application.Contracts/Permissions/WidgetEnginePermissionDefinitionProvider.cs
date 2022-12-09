using Akadimi.WidgetEngine.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Akadimi.WidgetEngine.Permissions;

public class WidgetEnginePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var widgetEngineGroup = context.AddGroup(WidgetEnginePermissions.GroupName);

        var booksPermission = widgetEngineGroup.AddPermission(WidgetEnginePermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(WidgetEnginePermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(WidgetEnginePermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(WidgetEnginePermissions.Books.Delete, L("Permission:Books.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<WidgetEngineResource>(name);
    }
}
