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

            Mapper.CreateMap<SensorsValueDTO, SensorsValue>();
            Mapper.CreateMap<SensorsValue, SensorsValue>();
            Mapper.CreateMap<SensorsValueViewModel, SensorsValueDTO>();
            Mapper.CreateMap<SensorsValueDTO, SensorsValue>();

            Mapper.CreateMap<TriggerDTO, TriggerViewModel>();
            Mapper.CreateMap<Trigger, TriggerDTO>();
            Mapper.CreateMap<TriggerViewModel, TriggerDTO>();
            Mapper.CreateMap<TriggerDTO, Trigger>();

            Mapper.CreateMap<TriggersActionDTO, TriggersActionViewModel>();
            Mapper.CreateMap<TriggersAction, TriggersActionDTO>();
            Mapper.CreateMap<TriggersActionViewModel, TriggersActionDTO>();
            Mapper.CreateMap<TriggersActionDTO, TriggersAction>();
        }
    }
}