using CicekSepetiCase.Core.Models;
using CicekSepetiCase.DataAccess.Entities;
using CicekSepetiCase.Service;
using MediatR;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace CicekSepetiCase.API.RequestHandlers
{
    public class AddProductToBasketHandler : IRequestHandler<AddProductToBasket, string>
    {
        private readonly IProductService ProductService;
        private readonly IBasketService BasketService;

        public AddProductToBasketHandler(IProductService productService, IBasketService basketService)
        {
            ProductService = productService;
            BasketService = basketService;
        }

        public async Task<string> Handle(AddProductToBasket request, CancellationToken cancellationToken)
        {
            if (!ObjectId.TryParse(request.ProductId, out ObjectId productId))
                throw new ServiceException("Not a BSON type ObjectId for Product.", HttpStatusCode.BadRequest);

            var isProductInStock = await ProductService.ProductStockExist(productId);

            if (!isProductInStock) throw new ServiceException("Out of stock", HttpStatusCode.NotFound);

            if (string.IsNullOrEmpty(request.BasketId))
                return await BasketService.AddProductToCart(new BasketEntity { ProductIds = new List<string> { request.ProductId } });

            if (!ObjectId.TryParse(request.BasketId, out ObjectId basketId))
                throw new ServiceException("Not a BSON type ObjectId for Basket.", HttpStatusCode.BadRequest);

            var productIds = await BasketService.GetBasketProducts(basketId);
            productIds = productIds.Count > 0 ? productIds : new List<string>();
            productIds.Add(request.ProductId);
            return await BasketService.AddProductToCart(new BasketEntity { Id = ObjectId.Parse(request.BasketId) });
        }
    }

    public class AddProductToBasket : IRequest<string>
    {
        internal string ProductId { get; set; }
        public string BasketId { get; set; }
    }
}
