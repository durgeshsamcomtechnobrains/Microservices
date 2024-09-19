using Mongo.Web.Models;

namespace Mongo.Web.Services.IService
{
    public interface IBaseServices
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto);
    }
}
