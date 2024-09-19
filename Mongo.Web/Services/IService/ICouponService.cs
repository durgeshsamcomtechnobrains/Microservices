using Mongo.Web.Models;

namespace Mongo.Web.Services.IService
{
    public interface ICouponService 
    {
        Task<ResponseDto?> GetCoupon (string couponCode);
        Task<ResponseDto?> GetAllCouponAsync();
        Task<ResponseDto?> GetCouponByIdAsync(int Id);
        Task<ResponseDto?> CreateCouponAsync(CouponDto couponDto);
        Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto);
        Task<ResponseDto?> DeleteCouponAsync(int Id);        

    }
}
