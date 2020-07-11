using System.Net;

namespace CicekSepetiCase.API.Models
{
    public class BaseResponseModel
    {
        public ErrorModel Error { get; set; }
    }

    public class BaseResponse<T>
    {
        public T ReturnValue { get; set; }
    }

    public class ErrorModel
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorException { get; set; }
    }
}
