using AutoMapper;
using Interfaces.Tables;
using SmartHouseWebSite.Models;
using BLL.DTO;
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

            Mapper.CreateMap<SensorDTO, SensorViewModel>();
            Mapper.CreateMap<Sensor, SensorDTO>();
            Mapper.CreateMap<SensorViewModel, SensorDTO>();
            Mapper.CreateMap<SensorDTO, Sensor>();

            Mapper.CreateMap<SensorsValueDTO, SensorsValueViewModel>();
            Mapper.CreateMap<SensorsValue, SensorsValueDTO>()
                .ForMember("Sensor", opt => opt.MapFrom(s => s.Sensor.Name));
            Mapper.CreateMap<SensorsValueViewModel, SensorsValueDTO>();
            Mapper.CreateMap<SensorsValueDTO, SensorsValue>()
                .ForMember("SensorId", opt => opt.Ignore());

            Mapper.CreateMap<TriggerDTO, TriggerViewModel>();
            Mapper.CreateMap<Trigger, TriggerDTO>()
                .ForMember("Sensor", opt => opt.MapFrom(s => s.Sensor.Name))
                .ForMember("HouseController", opt => opt.MapFrom(s => s.HouseController.Name));
            Mapper.CreateMap<TriggerViewModel, TriggerDTO>();
            Mapper.CreateMap<TriggerDTO, Trigger>()
               .ForMember(t => t.SensorId, opt => opt.Ignore())
               .ForMember(t => t.HouseControllerId, opt => opt.Ignore())
               .ForMember(t => t.Sensor, opt => opt.Ignore())
               .ForMember(t => t.HouseController, opt => opt.Ignore());

            Mapper.CreateMap<TriggersActionDTO, TriggersActionViewModel>();
            Mapper.CreateMap<TriggersAction, TriggersActionDTO>()
                .ForMember("Trigger", opt => opt.MapFrom(s => s.Trigger.Name));
            Mapper.CreateMap<TriggersActionViewModel, TriggersActionDTO>();
            Mapper.CreateMap<TriggersActionDTO, TriggersAction>()
                .ForMember("TriggerId", opt => opt.Ignore());
        }
    }
}