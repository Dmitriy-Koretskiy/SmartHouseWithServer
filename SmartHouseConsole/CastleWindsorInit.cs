using Castle.Windsor;
using Castle.Windsor.Installer;
using CommonServiceLocator.WindsorAdapter;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseWithServer
{
    public static class CastleWindsorInit
    {
        public static IWindsorContainer container;

        public static void BootstrapContainer()
        {
            container = new WindsorContainer().Install(FromAssembly.This());
            ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));
        }
    }
}
