using backend_upc_5_2023.Dominio;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace backend_upc_5_2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HProductosController : ControllerBase
    {
        readonly IConfiguration _configuration;
        readonly string connectionString;
        public HProductosController(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString =
            _configuration["SqlConnectionString:DefaultConnection"];
        }

        [HttpGet]
        public IActionResult Get()
        {
            var sql = "select * from H_PRODUCTO";
            var listHProductos = new List<HProductos>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                listHProductos = connection.Query<HProductos>(sql).ToList();
            }
            return StatusCode(200, listHProductos);
        }
    }
}
