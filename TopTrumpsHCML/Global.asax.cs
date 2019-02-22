using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TopTrumpsHCML.Controllers;
using TopTrumpsHCML.Entities;
using TopTrumpsHCML.Mappings;
using TopTrumpsHCML.Models;
using Unity;
using Unity.Injection;

namespace TopTrumpsHCML
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Initilise and register object mappings 
            AutoMapperConfiguration.RegisterMappings();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //register mapping injectors 
            using (var container = new UnityContainer())
            {
                container.RegisterType<IEnityViewModelMappers<Starship, CardViewModel>, CardMapper>();
            }

        }
    }
}
