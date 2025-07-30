
namespace KlinikH.Application.Helpers
{
    public static class CustomViewHelper
    {
        public static string DefineCustomUserRoute(string bundleFolder, string viewName)
        {
            return $"~/Areas/User/{bundleFolder}/Views/{viewName}.cshtml";
        }

        public static string DefineCustomAdminRoute(string bundleFolder, string viewName)
        {
            return $"~/Areas/Admin/{bundleFolder}/Views/{viewName}.cshtml";
        }
    }
}
