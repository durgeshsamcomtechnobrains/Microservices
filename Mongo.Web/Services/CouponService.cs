using Mongo.Web.Models;
using Mongo.Web.Services.IService;
using Mongo.Web.Utility;

namespace Mongo.Web.Services
{
    public class CouponService : ICouponService
    {
        private readonly IBaseServices _baseServices;
        public CouponService(IBaseServices baseServices)
        {
            _baseServices = baseServices;
        }
        public async Task<ResponseDto?> CreateCouponAsync(CouponDto couponDto)
        {
            return await _baseServices.SendAsync(new RequestDto() 
            { 
                ApiType = Utility.SD.ApiType.POST, 
                Data  = couponDto,
                Url = SD.CouponAPIBase + "/api/coupon" 
            });
        }

        public async Task<ResponseDto?> DeleteCouponAsync(int Id)
        {
            return await _baseServices.SendAsync(new RequestDto() 
            { 
                ApiType = Utility.SD.ApiType.DELETE, 
                Url = SD.CouponAPIBase + "/api/coupon/"+Id 
            });
        }

        public async Task<ResponseDto?> GetAllCouponAsync()
        {
            return await _baseServices.SendAsync(new RequestDto()
            {
                ApiType = Utility.SD.ApiType.GET,
                Url = SD.CouponAPIBase + "/api/coupon/"
            });
        }

        public async Task<ResponseDto?> GetCoupon(string couponCode)
        {
            return await _baseServices.SendAsync(new RequestDto()
            {
                ApiType = Utility.SD.ApiType.GET,
                Url = SD.CouponAPIBase + "/api/coupon/GetCouponByCode/" + couponCode
            });
        }

        public async Task<ResponseDto?> GetCouponByIdAsync(int Id)
        {
            return await _baseServices.SendAsync(new RequestDto()
            {
                ApiType = Utility.SD.ApiType.GET,
                Url = SD.CouponAPIBase + "/api/coupon/" + Id
            });
        }

        public async Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto)
        {
            return await _baseServices.SendAsync(new RequestDto() 
            { 
                ApiType = Utility.SD.ApiType.PUT, 
                Data = couponDto,
                Url = SD.CouponAPIBase + "/api/coupon/" 
            });
        }
    }
}
