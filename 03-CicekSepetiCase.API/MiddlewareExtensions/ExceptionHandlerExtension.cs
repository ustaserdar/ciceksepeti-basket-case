using CicekSepetiCase.API.Models;
using CicekSepetiCase.Core.Helpers;
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
                            serverResponse.Error = new ErrorModel
                            {
                                StatusCode = serviceException.StatusCode,
                                ErrorException = serviceException.ExceptionMessage,
                                ErrorMessage = serviceException.ExceptionMessage
                            };
                            applicationContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                            break;
                        default:
                            serverResponse.Error = new ErrorModel
                            {
                                StatusCode = HttpStatusCode.InternalServerError,
                                ErrorException = ex.Message,
                                ErrorMessage = "An error was encountered!"
                            };
                            break;
                    }

                    await applicationContext.Response.WriteAsync(serverResponse.ToJSON());
                });
            });
        }
    }
}
