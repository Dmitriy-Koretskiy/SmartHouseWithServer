using BLL.Installers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using CommonServiceLocator.WindsorAdapter;
using Microsoft.Practices.ServiceLocation;
using Servises.Installers;
using SmartHouseWebApi.App_Start;
using System.Web.Http.Dependencies;
using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http.WebHost;
using Castle.MicroKernel.Lifestyle;
using SmartHouseWebApi.CastleWindsorFactory;
using CommonServiceLocator.WindsorAdapter.Unofficial;

namespace SmartHouseWebApi
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer container;

        private static void BootstrapContainer()
        {
            container = new WindsorContainer().Install(FromAssembly.This(), FromAssembly.Named("DAL"),
                FromAssembly.Containing<ServerInstaller>(), FromAssembly.Containing<ServisesInstaller>());
            ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfig.RegisterMappings();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            WebApiApplication.BootstrapContainer();
            GlobalConfiguration.Configuration.DependencyResolver = new WindsorDependencyResolver(container.Kernel);
        }
               //.Services.Replace(typeof(IHttpControllerActivator), new WindsorCompositionRoot(container));
    }
}