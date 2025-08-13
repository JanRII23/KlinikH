
namespace KlinikH.Application.Helpers
{
    public static class CustomViewHelper
    {
        //TODO: need to define validation on the areas that are allowed across the application
        //TODO: also I think I can just define this as a switch case right onto a single function?

        public static string DefineCustomUserRoute(string bundleFolder, string viewName)
        {
            return $"~/Areas/User/{bundleFolder}/Views/{viewName}.cshtml";
        }

        public static string DefineCustomAdminRoute(string bundleFolder, string viewName)
        {
            return $"~/Areas/Admin/{bundleFolder}/Views/{viewName}.cshtml";
        }

        public static string DefineCustomIdentityRoute(string bundleFolder, string viewName) 
        {
            return $"~/Areas/Identity/{bundleFolder}/Views/{viewName}.cshtml";
        }
    }
}
