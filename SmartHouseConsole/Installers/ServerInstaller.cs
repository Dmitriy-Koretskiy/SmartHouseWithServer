using BLL;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DAL;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseWithServer.Installers
{
    public class ServerInstaller : IWindsorInstaller
    {
         public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            
              container.Register(Component.For<IServer>().ImplementedBy<Server>().LifestyleSingleton());
        }
    }
}
