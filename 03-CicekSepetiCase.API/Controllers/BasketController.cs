using CicekSepetiCase.API.Models;
using CicekSepetiCase.API.RequestHandlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace CicekSepetiCase.API.Controllers
{
    [Route("api/basket")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IMediator Mediator;

        public BasketController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpPost("{productId}")]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromRoute] string productId, [FromBody] AddProductToBasket req)
        {
            req.ProductId = productId;
            var result = await Mediator.Send(req);

            return Ok(new BaseResponse<string> { ReturnValue = result });
        }
    }
}
