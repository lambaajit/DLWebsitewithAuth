using AutoMapper;
using DLWebsiteWithAuth.Models;
using FluentValidation.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


namespace DLWebsiteWithAuth
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configure(WebApiConfig.Register);

            FluentValidationModelValidatorProvider.Configure();

            //Automapper Config
            var profiles = typeof(ContactModelMapping).Assembly.GetTypes().Where(x => typeof(Profile).IsAssignableFrom(x));
            Mapper.Initialize(x => {
                foreach (var profile in profiles)
                {
                    x.AddProfile(profile);
                }
                x.IgnoreUnmapped();
            });
        }
    }
}
