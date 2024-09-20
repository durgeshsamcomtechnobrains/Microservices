using Mongo.Web.Models;
using Mongo.Web.Services.IService;
using Mongo.Web.Utility;

namespace Mongo.Web.Services
{
    public class AuthService : IAuthService
    {
        private readonly IBaseServices _baseServices;
        public AuthService(IBaseServices baseServices)
        {
            _baseServices = baseServices;
        }
        public async Task<ResponseDto?> AssignRoleAync(RegistrationRequestDto assignRoleRequestDto)
        {
            return await _baseServices.SendAsync(new RequestDto()
            {
                ApiType = Utility.SD.ApiType.POST,
                Data = assignRoleRequestDto,
                Url = SD.AuthAPIBase + "/api/auth/assignRole"
            });
        }

        public async Task<ResponseDto?> LoginAync(LoginRequestDto loginRequestDto)
        {
            return await _baseServices.SendAsync(new RequestDto()
            {
                ApiType = Utility.SD.ApiType.POST,
                Data = loginRequestDto,
                Url = SD.AuthAPIBase + "/api/auth/login"
            }, withBearer: false);
        }

        public async Task<ResponseDto?> RegisterAync(RegistrationRequestDto assignRoleRequestDto)
        {
            return await _baseServices.SendAsync(new RequestDto()
            {
                ApiType = Utility.SD.ApiType.POST,
                Data = assignRoleRequestDto,
                Url = SD.AuthAPIBase + "/api/auth/register"
            }, withBearer: false);
        }
    }
}