using Mongo.Web.Models;

namespace Mongo.Web.Services.IService
{
    public interface IAuthService
    {
        Task<ResponseDto?> LoginAync(LoginRequestDto loginRequestDto);
        Task<ResponseDto?> RegisterAync(RegistrationRequestDto assignRoleRequestDto);
        Task<ResponseDto?> AssignRoleAync(RegistrationRequestDto assignRoleRequestDto);
    }
}
