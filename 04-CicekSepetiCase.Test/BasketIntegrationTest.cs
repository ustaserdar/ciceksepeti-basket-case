using CicekSepetiCase.Core.Helpers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CicekSepetiCase.API.Models;
using FluentAssertions;
using Xunit;
using System.Net;

namespace CicekSepetiCase.Test
{
    public class BasketIntegrationTest
    {
        private const string BasePath = "/api/basket/";

        // Should manuel add in the database with this product id and zero stock before test begins
        [Theory]
        [InlineData("5f077905c6b57a2132621ce4")]
        public async Task Add_OutOfStock_Product_To_Basket_Should_Return_Not_Found_Exception(string productId)
        {
            using var httpClient = new ClientProvider().HttpClient;

            var response = await httpClient.PostAsync($"{BasePath}{productId}", new StringContent(new { }.ToJSON(), Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Theory]
        [InlineData("5f0778cd6a7336fcfcfe4046")]
        public async Task Add_Product_To_New_Basket_Should_Return_BasketId(string productId)
        {
            using var httpClient = new ClientProvider().HttpClient;
            
            var response = await httpClient.PostAsync($"{BasePath}{productId}", new StringContent(new { }.ToJSON(), Encoding.UTF8, "application/json"));
            var basketId = JsonConvert.DeserializeObject<BaseResponse<string>>(await response.Content.ReadAsStringAsync()).ReturnValue;

            basketId.Should().NotBeNullOrEmpty();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("5f0778d6b66edb43f3dd9235", "5f077994562666433c45483f")]
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
