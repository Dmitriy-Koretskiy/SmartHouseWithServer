using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseWithServer
{
    public static class CastleWindsorInit
    {
        private static IWindsorContainer container;

        public static void BootstrapContainer()
        {
            container = new WindsorContainer().Install(FromAssembly.This());
        }
    }
}
