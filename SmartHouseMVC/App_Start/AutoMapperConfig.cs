using AutoMapper;
using Interfaces.Tables;
using SmartHouseWebSite.Models;
using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouseWebSite.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<HouseControllerDTO, HouseControllerViewModel>();
            Mapper.CreateMap<HouseController, HouseControllerDTO>();
            Mapper.CreateMap<HouseControllerViewModel, HouseControllerDTO>();
            Mapper.CreateMap<HouseControllerDTO, HouseController>();

            Mapper.CreateMap<HouseControllersTypeDTO, HouseControllersTypeViewModel>();
            Mapper.CreateMap<HouseControllersType, HouseControllersTypeDTO>();

            Mapper.CreateMap<RoomDTO, RoomViewModel>();
            Mapper.CreateMap<Room, RoomDTO>();

            Mapper.CreateMap<SensorDTO, SensorViewModel>();
            Mapper.CreateMap<Sensor, SensorDTO>();
            Mapper.CreateMap<SensorViewModel, SensorDTO>();
            Mapper.CreateMap<SensorDTO, Sensor>();

            Mapper.CreateMap<SensorsTypeDTO, SensorsTypeViewModel>();
            Mapper.CreateMap<SensorsType, SensorsTypeDTO>();

            Mapper.CreateMap<SensorsValueDTO, SensorsValueViewModel>();
            Mapper.CreateMap<SensorsValue, SensorsValueDTO>()
                .ForMember(sv => sv.SensorName, opt => opt.MapFrom(s => s.Sensor.Name));
            Mapper.CreateMap<SensorsValueViewModel, SensorsValueDTO>();
            Mapper.CreateMap<SensorsValueDTO, SensorsValue>()
                .ForMember(sv => sv.SensorId, opt => opt.Ignore());

            Mapper.CreateMap<TriggerDTO, TriggerViewModel>();
            Mapper.CreateMap<Trigger, TriggerDTO>()
                .ForMember(t => t.SensorName, opt => opt.MapFrom(s => s.Sensor.Name))
                .ForMember(t => t.HouseControllerName, opt => opt.MapFrom(s => s.HouseController.Name));
            Mapper.CreateMap<TriggerViewModel, TriggerDTO>();
            Mapper.CreateMap<TriggerDTO, Trigger>()
               .ForMember(t => t.Sensor, opt => opt.Ignore())
               .ForMember(t => t.HouseController, opt => opt.Ignore())
               .ForMember(t => t.Room, opt => opt.Ignore())
               .ForMember(t => t.TriggersType, opt => opt.Ignore());

            Mapper.CreateMap<TriggersActionDTO, TriggersActionViewModel>();
            Mapper.CreateMap<TriggersAction, TriggersActionDTO>()
                .ForMember(ta =>ta.TriggerName, opt => opt.MapFrom(s => s.Trigger.Name));
            Mapper.CreateMap<TriggersActionViewModel, TriggersActionDTO>();
            Mapper.CreateMap<TriggersActionDTO, TriggersAction>()
                .ForMember(ta => ta.TriggerId, opt => opt.Ignore());

            Mapper.CreateMap<TriggersTypeDTO, TriggersTypeViewModel>();
            Mapper.CreateMap<TriggersType, TriggersTypeDTO>();
        }
    }
}