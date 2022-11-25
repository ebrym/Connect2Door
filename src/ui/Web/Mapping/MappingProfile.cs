
using Autofac;
using AutoMapper;
using connect2door.Data.Entity;
using connect2door.Repository.Dto;
using connect2door.Repository.Interface;
using connect2door.Web.Models;
using System;
using System.Linq;
using System.Reflection;

namespace connect2door.Web.Mapping
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class MappingProfile :  Profile
    {
        public MappingProfile()
        {
            CreateMap<Driver, DriverDto>().ReverseMap();
            CreateMap<DriverDto, DriverModel>().ReverseMap();
            CreateMap<DriverDto, DriverViewModel>().ReverseMap();


            CreateMap<Shipment, ShipmentDto>().ReverseMap();
            CreateMap<ShipmentDto, ShipmentModel>().ReverseMap();
            CreateMap<ShipmentDto, ShipmentViewModel>().ReverseMap();
        }
    }

    public class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            return mapperConfig.CreateMapper();
        }
    }
}