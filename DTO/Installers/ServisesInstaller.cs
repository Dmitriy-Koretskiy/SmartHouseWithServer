using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Servises.MappingServices;
using Interfaces.DTO;
using Interfaces.MappingServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servises.Installers
{
    public class ServisesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IRoomMappingService>().ImplementedBy<RoomMappingService>().LifestylePerWebRequest());
            container.Register(Component.For<IGenericMappingService>().ImplementedBy<GenericMappingService>().LifestylePerWebRequest());
            container.Register(Component.For<ISensorsValueMappingService>().ImplementedBy<SensorsValueMappingService>().LifestylePerWebRequest());
            container.Register(Component.For<ITriggersStateMappingService>().ImplementedBy<TriggersStateMappingService>().LifestylePerWebRequest());
            container.Register(Component.For<IMappingService<HouseControllerDTO>>().ImplementedBy<HouseControllerMappingService>().LifestylePerWebRequest());
            container.Register(Component.For<IMappingService<SensorDTO>>().ImplementedBy<SensorMappingService>().LifestylePerWebRequest());
            container.Register(Component.For<IMappingService<TriggersSettingDTO>>().ImplementedBy<TriggerMappingService>().LifestylePerWebRequest());
            container.Register(Component.For<IMappingService<TriggersActionDTO>>().ImplementedBy<TriggersActionMappingService>().LifestylePerWebRequest());
        }
    }
}