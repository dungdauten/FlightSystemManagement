using AutoMapper;
using FlightSystemManagementAPI.Models.Data;
using FlightSystemManagementAPI.Models.DTO;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;

namespace FlightSystemManagementAPI.Configurations
{
    public class MapperInitilizer:Profile
    {
        public MapperInitilizer() 
        { 
            CreateMap<PlaneInfo,PlaneInfoDTO>().ReverseMap();
        }
    }
}
