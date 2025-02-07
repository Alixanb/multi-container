using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase, IDisposable
    {
        private readonly NpgsqlConnection _connection;

        public MessageController(IConfiguration configuration)
        {
            _connection = new NpgsqlConnection(configuration.GetConnectionString("Default"));
        }

        [HttpGet]
        public async Task<IActionResult> GetMessage()
        {
            try
            {
                await _connection.OpenAsync();
                using var command = new NpgsqlCommand("SELECT message FROM messages LIMIT 1", _connection);
                var message = await command.ExecuteScalarAsync();
                return Ok(new { message = message ?? "Hello from Database!" });
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}