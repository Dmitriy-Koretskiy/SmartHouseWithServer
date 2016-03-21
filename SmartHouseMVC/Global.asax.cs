using BLL.Installers;
using Servises.Installers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using CommonServiceLocator.WindsorAdapter;
using DAL.Installers;
using Microsoft.Practices.ServiceLocation;
using SmartHouseMVC.App_Start;
using SmartHouseMVC.CastleWindsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CommonServiceLocator.WindsorAdapter.Unofficial;

namespace SmartHouseMVC
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer container;

        private static void BootstrapContainer()
        {
            container = new WindsorContainer().Install(FromAssembly.This(), FromAssembly.Named("DAL"),
            FromAssembly.Containing<ServerInstaller>(), FromAssembly.Containing<ServisesInstaller>());
            ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));
            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            AutoMapperConfig.RegisterMappings();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MvcApplication.BootstrapContainer();
        }

        protected void Application_End()
        {
            container.Dispose();
        }
    }
}