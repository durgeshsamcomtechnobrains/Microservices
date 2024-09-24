using AutoMapper;
using Azure;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/coupon")]
    [ApiController]
    //[Authorize]
    public class CouponAPIController : ControllerBase
    {
        public readonly AppDbContext _db;
        public ResponseDto _response;
        private readonly IMapper _mapper;
        public CouponAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _response = new ResponseDto();
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Coupon> objlist = _db.coupons.ToList();
                _response.Result = _mapper.Map<IEnumerable<CouponDto>>(objlist);            
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Coupon obj = _db.coupons.First(u=> u.CouponId == id);
                _response.Result = _mapper.Map<Coupon>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetCouponByCode/{code}")]
        public ResponseDto GetCouponByCode(string code)
        {
            try
            {
                Coupon obj = _db.coupons.First(u => u.CouponCode== code);
                if(obj is null)
                {
                    _response.IsSuccess = false;
                }
                _response.Result = _mapper.Map<Coupon>(obj);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        [Authorize(Roles ="ADMIN")]
        public ResponseDto Post([FromBody]CouponDto couponDto)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);
                _db.coupons.Add(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<Coupon>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess =false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto put ([FromBody]CouponDto couponDto)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);
                _db.coupons.Update(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<Coupon>(obj);
            }
            catch(Exception ex)
            {
                _response.IsSuccess=false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto delete(int Id)
        {
            try
            {
                Coupon obj = _db.coupons.First(u => u.CouponId == Id);
                _db.Remove(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<Coupon>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
