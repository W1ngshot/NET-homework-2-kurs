using System.Net;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;

namespace Tests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override IHostBuilder CreateHostBuilder()
        {
            var builder = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(x =>
                {
                    x.UseStartup<Program.Startup>().UseTestServer();
                });
            return builder;
        }
    }
    
    public class ProgramTests
        : IClassFixture<CustomWebApplicationFactory<Program.Startup>>
        {
            private readonly CustomWebApplicationFactory<Program.Startup> _factory;

            public ProgramTests(CustomWebApplicationFactory<Program.Startup> factory)
            {
                _factory = factory;
            }

            [Theory]
            [InlineData("1.3", "^", "2.2", 3.5)]
            [InlineData("2.1", "-", "1.2", 0.9)]
            [InlineData("2.0", "*", "3.2", 6.4)]
            [InlineData("10.0", "/", "2.5", 4)]
            public async Task PositiveTests(string v1, string op, string v2, decimal expectedResult)
            {
                var client = _factory.CreateClient();
                var url = $"/calculate?v1={v1}&op={op}&v2={v2}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                Assert.Equal(expectedResult, decimal.Parse(result));
            }

            [Theory]
            [InlineData("2", "+", "a", "Could not parse value 'a' to type System.Decimal.")]
            [InlineData("b", "+", "2", "Could not parse value 'b' to type System.Decimal.")]
            [InlineData("2", "||", "2", "Could not parse value '||' to type System.Char.")]
            public async Task NegativeTests(string v1, string op, string v2, string expectedError)
            {
                var client = _factory.CreateClient();
                var url = $"/calculate?v1={v1}&op={op}&v2={v2}";
                var response = await client.GetAsync(url);
                Assert.True(response.StatusCode == HttpStatusCode.BadRequest);
                var result = await response.Content.ReadAsStringAsync();
                Assert.Equal(expectedError, result);
            }
            
            [Fact]
            public async Task Error404()
            {
                var client = _factory.CreateClient();
                var url = "/abc";
                var expectedResult = "Not Found";
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();
                Assert.Equal(expectedResult, result);
            }
        }
}