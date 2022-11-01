
using Autofac;
using AutoMapper;
using connect2door.Api.Models.Request;
using connect2door.Api.Models.Response;
using connect2door.Data.Entity;
using connect2door.Repository.Dto;
using connect2door.Repository.Interface;
using System;
using System.Linq;
using System.Reflection;

namespace connect2door.Api.Mapping
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
            CreateMap<DriverDto, CreateDriverRequestModel>().ReverseMap();
            CreateMap<DriverDto, DriverRequestModel>().ReverseMap();
            CreateMap<DriverDto, DriverResponseModel>().ReverseMap();


            CreateMap<Shipment, ShipmentDto>().ReverseMap();
            CreateMap<ShipmentDto, CreateShipmentRequestModel>().ReverseMap();
            CreateMap<ShipmentDto, ShipmentRequestModel>().ReverseMap();
            CreateMap<ShipmentDto, ShipmentResponseModel>().ReverseMap();
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