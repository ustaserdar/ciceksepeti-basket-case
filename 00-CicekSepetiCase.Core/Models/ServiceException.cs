using System;
using System.Net;

namespace CicekSepetiCase.Core.Models
{
    public class ServiceException : Exception
    {
        public string ExceptionMessage { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public ServiceException(string exceptionMessage, HttpStatusCode statusCode)
        {
            ExceptionMessage = exceptionMessage;
            StatusCode = statusCode;
        }
    }
}
