using Mongo.Web.Models;
using Newtonsoft.Json;
using System.Text;

namespace Mongo.Web.Services
{
    public class BaseService : IBaseServices
    {
        public readonly IHttpClientFactory _httpClientFactory;
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ResponseDto?> SendAsync(RequestDto requestDto)
        {
            try
            {
                HttpClient Client = _httpClientFactory.CreateClient("MangoAPI");
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");
                //Token

                message.RequestUri = new Uri(requestDto.Url);
                if (requestDto.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data) , Encoding.UTF8, "application/json");
                }
                HttpResponseMessage? ApiResponse = null;

                switch(requestDto.ApiType)
                {
                    case Utility.SD.ApiType.POST:
                        message.Method=HttpMethod.Post;
                        break;

                    case Utility.SD.ApiType.DELETE:
                        message.Method=HttpMethod.Delete;
                        break;

                    case Utility.SD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;

                    case Utility.SD.ApiType.GET:
                        message.Method = HttpMethod.Get;
                        break;
                }
                ApiResponse = await Client.SendAsync(message);

                    switch (ApiResponse.StatusCode)
                    {
                        case System.Net.HttpStatusCode.NotFound:
                            return new() { IsSuccess = false, Message = "Not Found" };
                        case System.Net.HttpStatusCode.Forbidden:
                            return new() { IsSuccess = false, Message = "Access denied" };
                        case System.Net.HttpStatusCode.Unauthorized:
                            return new() { IsSuccess = false, Message = "Unauthorized" };
                        case System.Net.HttpStatusCode.InternalServerError:
                            return new() { IsSuccess = false, Message = "Interal Server Error" };
                        default:
                            var apiContent = await ApiResponse.Content.ReadAsStringAsync();
                            var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                            return apiResponseDto;
                    }
            }
            catch (Exception ex)
            {
                var dto = new ResponseDto()
                {
                    Message = ex.Message.ToString(),
                    IsSuccess = false
                };
                return dto;
            }
        }
    }
}
