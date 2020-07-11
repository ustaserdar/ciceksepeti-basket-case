using CicekSepetiCase.API.Models;
using CicekSepetiCase.Core.Helpers;
using FluentAssertions;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CicekSepetiCase.Test.Tests
{
    public class BasketIntegrationTest
    {
        private const string BasePath = "/api/basket/";

        [Theory]
        [InlineData("5f077905c6b57a2132621ce4")]
        public async Task Add_OutOfStock_Product_To_Basket_Should_Return_Not_Found_Exception(string productId)
        {
            using var httpClient = new ClientProvider().HttpClient;

            var response = await httpClient.PostAsync($"{BasePath}{productId}", new StringContent(new { }.ToJSON(), Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Theory]
        [InlineData("5f097bc6b23bd293904a2296")]
        public async Task Add_Product_To_New_Basket_Should_Return_BasketId(string productId)
        {
            using var httpClient = new ClientProvider().HttpClient;
            
            var response = await httpClient.PostAsync($"{BasePath}{productId}", new StringContent(new { }.ToJSON(), Encoding.UTF8, "application/json"));
            var basketId = JsonConvert.DeserializeObject<BaseResponse<string>>(await response.Content.ReadAsStringAsync()).ReturnValue;

            basketId.Should().NotBeNullOrEmpty();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        // Sample basketId should change after the first product added to any basket
        [Theory]
        [InlineData("5f097bc6b23bd293904a2297", "5f098077efddbccfc8ab13fd")]
        public async Task Add_Product_To_Same_Basket_Should_Return_BasketId(string productId, string basketId)
        {
            using var httpClient = new ClientProvider().HttpClient;

            var response = await httpClient.PostAsync($"{BasePath}{productId}", new StringContent(new { basketId }.ToJSON(), Encoding.UTF8, "application/json"));
            basketId = JsonConvert.DeserializeObject<BaseResponse<string>>(await response.Content.ReadAsStringAsync()).ReturnValue;

            basketId.Should().NotBeNullOrEmpty();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
