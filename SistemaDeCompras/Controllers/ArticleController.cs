using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using SistemaDeCompras.Models;

namespace SistemaDeCompras.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        public  List<Article> sellers;

        public ArticleController(ILogger<ArticleController> logger)
        {
            // Convertimos el json en un arreglo de objetos que podemos utilizar.
            var jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Controllers", "articulos.json");
            var json = System.IO.File.ReadAllText(jsonFilePath);
            sellers = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Article>>(json);
        }

        // Generamos un endpoint de tipo Get para obtener los valores que convertimos del json
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(sellers);
        }

        /* Generamos un endpoint post para realizar la suma de los productos, 
         * en este caso tenemos una validación para evitar arreglos nulos,
         * devolvemos la suma.
         */
        [HttpPost("add")]
        public IActionResult Post([FromBody] List<Article> order)
        {
            if(order.Count() > 0)
            {
                var orderSum = order.Sum(item => item.precio);
                return Ok(orderSum); 
               
            }
            return BadRequest("La orden no es correcta");
        }
    }
}
