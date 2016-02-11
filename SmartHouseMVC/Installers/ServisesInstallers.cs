using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DTO.Services;
using Interfaces.DTO;
using Interfaces.MappingServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouseWebSite.Installers
{
    public class ServisesInstallers : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IRoomMappingService>().ImplementedBy<RoomMappingService>().LifestylePerWebRequest());
            container.Register(Component.For<IGenericMappingService>().ImplementedBy<GenericMappingService>().LifestylePerWebRequest());
            container.Register(Component.For<ISensorsValueMappingService>().ImplementedBy<SensorsValueMappingService>().LifestylePerWebRequest());
            container.Register(Component.For<IMappingService<HouseControllerDTO>>().ImplementedBy<HouseControllerMappingService>().LifestylePerWebRequest());
            container.Register(Component.For<IMappingService<SensorDTO>>().ImplementedBy<SensorMappingService>().LifestylePerWebRequest());
            container.Register(Component.For<IMappingService<TriggerDTO>>().ImplementedBy<TriggerMappingService>().LifestylePerWebRequest());
            container.Register(Component.For<IMappingService<TriggersActionDTO>>().ImplementedBy<TriggersActionMappingService>().LifestylePerWebRequest());
        }
    }
}