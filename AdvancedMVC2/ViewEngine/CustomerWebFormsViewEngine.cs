using System.Web.Mvc;

namespace AdvancedMVC2.ViewEngine
{
    public class CustomerWebFormsViewEngine : WebFormViewEngine
    {
        public CustomerWebFormsViewEngine():base()
        {
            MasterLocationFormats = new[] {
                "~/Customer/Views/{1}/{0}.master",
                "~/Customer/Views/Shared/{0}.master",
                "~/Views/{1}/{0}.master",
                "~/Views/Shared/{0}.master",
            };

            AreaMasterLocationFormats = new[] {
                "~/Customer/Areas/{2}/Views/{1}/{0}.master",
                "~/Customer/Areas/{2}/Views/Shared/{0}.master",
                "~/Areas/{2}/Views/{1}/{0}.master",
                "~/Areas/{2}/Views/Shared/{0}.master",
            };

            ViewLocationFormats = new[] {
                "~/Customer/Views/{1}/{0}.aspx",
                "~/Customer/Views/{1}/{0}.ascx",
                "~/Customer/Views/Shared/{0}.aspx",
                "~/Customer/Views/Shared/{0}.ascx",
                "~/Views/{1}/{0}.aspx",
                "~/Views/{1}/{0}.ascx",
                "~/Views/Shared/{0}.aspx",
                "~/Views/Shared/{0}.ascx",
            };

            AreaViewLocationFormats = new[] {
                "~/Customer/Areas/{2}/Views/{1}/{0}.aspx",
                "~/Customer/Areas/{2}/Views/{1}/{0}.ascx",
                "~/Customer/Areas/{2}/Views/{1}/{0}.aspx",
                "~/Customer/Areas/{2}/Views/{1}/{0}.ascx",
                "~/Customer/Areas/{2}/Views/Shared/{0}.aspx",
                "~/Customer/Areas/{2}/Views/Shared/{0}.ascx",
                "~/Areas/{2}/Views/{1}/{0}.aspx",
                "~/Areas/{2}/Views/{1}/{0}.ascx",
                "~/Areas/{2}/Views/{1}/{0}.aspx",
                "~/Areas/{2}/Views/{1}/{0}.ascx",
                "~/Areas/{2}/Views/Shared/{0}.aspx",
                "~/Areas/{2}/Views/Shared/{0}.ascx",
            };

            PartialViewLocationFormats = ViewLocationFormats;
            AreaPartialViewLocationFormats = AreaViewLocationFormats;
        }
    }
}