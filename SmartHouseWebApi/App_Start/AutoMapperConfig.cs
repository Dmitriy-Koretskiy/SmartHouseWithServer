using AutoMapper;
using Interfaces.Tables;
using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouseWebApi.App_Start
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

            Mapper.CreateMap<Trigger, TriggersSettingDTO>()
                .ForMember(t => t.SensorName, opt => opt.MapFrom(s => s.Sensor.Name))
                .ForMember(t => t.HouseControllerName, opt => opt.MapFrom(s => s.HouseController.Name))
                .ForMember(t => t.RoomName, opt => opt.MapFrom(s => s.Room.Name))
                .ForMember(t => t.TriggersTypeName, opt => opt.MapFrom(s => s.TriggersType.Name));
            Mapper.CreateMap<TriggersSettingDTO, Trigger>()
                .ForMember(t => t.Sensor, opt => opt.Ignore())
                .ForMember(t => t.HouseController, opt => opt.Ignore())
                .ForMember(t => t.Room, opt => opt.Ignore())
                .ForMember(t => t.TriggersType, opt => opt.Ignore());

            Mapper.CreateMap<TriggersAction, TriggersActionDTO>()
                .ForMember(ta => ta.TriggerName, opt => opt.MapFrom(s => s.Trigger.Name));
            Mapper.CreateMap<TriggersActionDTO, TriggersAction>()
                .ForMember(ta => ta.TriggerId, opt => opt.Ignore());

            Mapper.CreateMap<TriggersType, TriggersTypeDTO>();

            Mapper.CreateMap<TriggersAction, TriggersStateDTO>()
                .ForMember(ts => ts.Id, opt => opt.MapFrom(ta => ta.Trigger.Id))
                .ForMember(ts => ts.Name, opt => opt.MapFrom(ta => ta.Trigger.Name))
                .ForMember(ts => ts.LastState, opt => opt.MapFrom(ta => ta.Description));
            Mapper.CreateMap<TriggersStateDTO, TriggersAction>()
                .ForMember(ta => ta.TriggerId, opt => opt.MapFrom(ts => ts.Id))
                .ForMember(ta => ta.Description, opt => opt.MapFrom(ts => ts.LastState))
                .ForMember(ta => ta.TimeChange, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(ta => ta.Trigger, opt => opt.Ignore());

            Mapper.CreateMap<TriggersAction, TriggersStateInitDTO>()
            .ForMember(ts => ts.Id, opt => opt.MapFrom(ta => ta.Trigger.Id))
            .ForMember(ts => ts.Name, opt => opt.MapFrom(ta => ta.Trigger.Name))
            .ForMember(ts => ts.LastState, opt => opt.MapFrom(ta => ta.Description))
            .ForMember(ts => ts.Image, opt => opt.MapFrom(ta => ta.Trigger.TriggersType.Image));
        }
    }
}