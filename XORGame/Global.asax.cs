using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using XORGame.Engines;

namespace XORGame
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            CompositionContainer container = new CompositionContainer();
            AggregateCatalog catalog = new AggregateCatalog();
            var test = HostingEnvironment.ApplicationPhysicalPath + "bin";
            catalog.Catalogs.Add(new DirectoryCatalog(HostingEnvironment.ApplicationPhysicalPath + "bin"));


            //container.ComposeParts(this);

            AbilityFactory abilityFactory = container.GetExportedValue<AbilityFactory>();
            container.ComposeParts(abilityFactory);
        }
    }
}
