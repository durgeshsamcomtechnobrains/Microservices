using Mongo.Web.Models;

namespace Mongo.Web.Services
{
    public interface IBaseServices
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto);
    }
}
