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
          
            Mapper.CreateMap<HouseController, HouseControllerDTO>()
                .ForMember(t => t.RoomName, opt => opt.MapFrom(s => s.Room.Name))
                .ForMember(t => t.HouseControllersTypeName, opt => opt.MapFrom(s => s.HouseControllersType.Name));
            Mapper.CreateMap<HouseControllerDTO, HouseController>()
               .ForMember(t => t.Room, opt => opt.Ignore())
               .ForMember(t => t.HouseControllersType, opt => opt.Ignore());

            Mapper.CreateMap<HouseControllersType, HouseControllersTypeDTO>();


            Mapper.CreateMap<Room, RoomDTO>();

            Mapper.CreateMap<Sensor, SensorDTO>()
                .ForMember(t => t.RoomName, opt => opt.MapFrom(s => s.Room.Name))
                .ForMember(t => t.SensorsTypeName, opt => opt.MapFrom(s => s.SensorsType.Name));
            Mapper.CreateMap<SensorDTO, Sensor>()
               .ForMember(t => t.Room, opt => opt.Ignore())
               .ForMember(t => t.SensorsType, opt => opt.Ignore());

            Mapper.CreateMap<SensorsType, SensorsTypeDTO>();

            Mapper.CreateMap<SensorsValue, SensorsValueDTO>()
                .ForMember(sv => sv.SensorName, opt => opt.MapFrom(s => s.Sensor.Name));
            Mapper.CreateMap<SensorsValueDTO, SensorsValue>()
                .ForMember(sv => sv.SensorId, opt => opt.Ignore());

            Mapper.CreateMap<Trigger, TriggerDTO>()
                .ForMember(t => t.SensorName, opt => opt.MapFrom(s => s.Sensor.Name))
                .ForMember(t => t.HouseControllerName, opt => opt.MapFrom(s => s.HouseController.Name))
                .ForMember(t => t.RoomName, opt => opt.MapFrom(s => s.Room.Name))
                .ForMember(t => t.TriggersTypeName, opt => opt.MapFrom(s => s.TriggersType.Name));
            Mapper.CreateMap<TriggerDTO, Trigger>()
                .ForMember(t => t.Sensor, opt => opt.Ignore())
                .ForMember(t => t.HouseController, opt => opt.Ignore())
                .ForMember(t => t.Room, opt => opt.Ignore())
                .ForMember(t => t.TriggersType, opt => opt.Ignore());

            Mapper.CreateMap<TriggersAction, TriggersActionDTO>()
                .ForMember(ta => ta.TriggerName, opt => opt.MapFrom(s => s.Trigger.Name));
            Mapper.CreateMap<TriggersActionDTO, TriggersAction>()
                .ForMember(ta => ta.TriggerId, opt => opt.Ignore());

            Mapper.CreateMap<TriggersType, TriggersTypeDTO>();

            Mapper.CreateMap<TriggersAction, RoomContentDTO>()
                .ForMember(rc => rc.Name, opt => opt.MapFrom(ta => ta.Trigger.Name))
                .ForMember(rc => rc.LastState, opt => opt.MapFrom(ta => ta.Description))
                .ForMember(rc => rc.TriggerId, opt => opt.MapFrom(ta => ta.Trigger.Id))
                .ForMember(rc => rc.SensorId, opt => opt.MapFrom(ta => ta.Trigger.Sensor.Id));
        }
    }
}