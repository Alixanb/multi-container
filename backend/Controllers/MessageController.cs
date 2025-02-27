using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly string _connectionString;

        public MessageController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default") 
                ?? throw new InvalidOperationException("Connection string 'Default' not found.");
        }

        [HttpGet]
        public async Task<IActionResult> GetMessage()
        {
            try
            {
                await using var connection = new NpgsqlConnection(_connectionString);
                await connection.OpenAsync();
                
                await using var command = new NpgsqlCommand("SELECT message FROM messages LIMIT 1", connection);
                var message = await command.ExecuteScalarAsync();
                
                return Ok(new { message = message?.ToString() ?? "Hello from Database!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Database connection failed", details = ex.Message });
            }
        }
    }
}