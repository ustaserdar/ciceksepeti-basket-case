using CicekSepetiCase.API.Models;
using CicekSepetiCase.Core.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;

namespace CicekSepetiCase.API.MiddlewareExtensions
{
    public static class ExceptionHandlerExtension
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async applicationContext =>
                {
                    var feature = applicationContext.Features.Get<IExceptionHandlerFeature>();
                    var ex = feature.Error;

                    applicationContext.Response.StatusCode = (int)HttpStatusCode.ServiceUnavailable;
                    applicationContext.Response.ContentType = "application/json";

                    var serverResponse = new BaseResponseModel();

                    switch (ex)
                    {
                        case ServiceException serviceException:
                            serverResponse.StatusCode = serviceException.StatusCode;
                            serverResponse.ErrorMessage = serviceException.ExceptionMessage;
                            serverResponse.Exception = serviceException.ExceptionMessage;
                            break;
                        default:
                            serverResponse.StatusCode = HttpStatusCode.InternalServerError;
                            serverResponse.ErrorMessage = "An error was encountered!";
                            serverResponse.Exception = ex.Message;
                            break;
                    }

                    var jsonResponse = JsonConvert.SerializeObject(serverResponse);

                    await applicationContext.Response.WriteAsync(jsonResponse);
                });
            });
        }
    }
}
