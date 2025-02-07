using backend.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace backend.Tests
{
    public class MessageControllerTests
    {
        [Fact]
        public async Task GetMessage_ReturnsOkResult()
        {
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    {"ConnectionStrings:Default", "Host=db;Database=test;Username=test;Password=test"}
                })
                .Build();
            
            var controller = new MessageController(configuration);
            
            var result = await controller.GetMessage();

            Assert.IsType<OkObjectResult>(result);
        }
    }
} 