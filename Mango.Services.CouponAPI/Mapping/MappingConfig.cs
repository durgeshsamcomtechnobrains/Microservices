using AutoMapper;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Mango.Services.CouponAPI.Mapping
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(Config =>
            {
                Config.CreateMap<Coupon,CouponDto>().ReverseMap();                
            });
            return mappingConfig;
        }
    }
}
