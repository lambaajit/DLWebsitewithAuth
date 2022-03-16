using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DLWebsiteWithAuth
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            routes.IgnoreRoute("");

            routes.MapRoute(
                name: "Confirm",
                url: "{id}",
                defaults: new { controller = "Home", action = "Confirmation", id = UrlParameter.Optional },
                constraints: new { id = @"^[A-Za-z:./_\d-]+(Confirmation)[A-Za-z/._\d-]*$" }
                );

            routes.MapRoute(
                name: "OurTeam",
                url: "{dept}/{htmlpage}",
                defaults: new { controller = "Home", action = "ParsePage", htmlpage = UrlParameter.Optional, dept = UrlParameter.Optional },
                constraints: new { dept = @"^[A-Za-z:./_\d-]+(_ourteam)[A-Za-z/._\d-]*$" }
                );

            routes.MapRoute(
                name: "OurTeamNew",
                url: "{htmlpage}",
                defaults: new { controller = "Home", action = "ParsePage", htmlpage = UrlParameter.Optional },
                constraints: new { htmlpage = @"^[A-Za-z:.\d-]+-(Lawyer|Solicitor)-(Barnet|Birmingham|Bradford|Cardiff|Croydon|Hackney|Harrow|Islington|Leeds|Leicester|Liverpool|Luton|Milton-Keynes|New-Cross-Gate|Shepherds-Bush|Slough|Swansea|Tonbridge|Tooting|Dalston|Lewisham)-[A-Za-z\d-]*$" }
            );



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CaptchaMvcRoute",
                url: "DefaultCaptcha/Generate",
                defaults: new { controller = "DefaultCaptcha", action = "Generate" }
            );
        }
    }
}
