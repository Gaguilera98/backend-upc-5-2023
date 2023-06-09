using backend_upc_5_2023.Dominio;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace backend_upc_5_2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoCompraController : ControllerBase
    {
        readonly IConfiguration _configuration;
        readonly string connectionString;
        public CarritoCompraController(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString =
            _configuration["SqlConnectionString:DefaultConnection"];
        }

        [HttpGet]
        public IActionResult Get()
        {
            var sql = "select * from CARRITO_COMPRA";
            var listCarritoCompra = new List<CarritoCompra>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                listCarritoCompra = connection.Query<CarritoCompra>(sql).ToList();
            }
            return StatusCode(200, listCarritoCompra);
        }
    }
}
