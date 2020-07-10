using System.Net;

namespace CicekSepetiCase.API.Models
{
    public class BaseResponseModel
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public string Exception { get; set; }
    }

    public class BaseResponse<T>
    {
        public T ReturnValue { get; set; }
    }
}
