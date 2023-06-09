using backend_upc_5_2023.Dominio;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace backend_upc_5_2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        readonly IConfiguration _configuration;
        readonly string connectionString;
        public ProductosController(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString =
            _configuration["SqlConnectionString:DefaultConnection"];
        }

        [HttpGet]
        public IActionResult Get()
        {
            var sql = "select * from PRODUCTO";
            var listProductos = new List<Productos>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                listProductos = connection.Query<Productos>(sql).ToList();
            }
            return StatusCode(200, listProductos);
        }
    }
}
