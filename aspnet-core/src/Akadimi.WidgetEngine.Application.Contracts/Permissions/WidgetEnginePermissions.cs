namespace Akadimi.WidgetEngine.Permissions;

public static class WidgetEnginePermissions
{
    public const string GroupName = "WidgetEngine";

    public static class Books
    {
        public const string Default = GroupName + ".Books";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}
