using Microsoft.AspNetCore.Mvc;

namespace ProyectoDeCsharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NombreController : Controller
    {
        List<string> list = new List<string>() { "Rocio","Juana","Pepe" };

        [HttpGet]
        public string ObtenerNombre()
        {
            return "Rocio";
        }

        [HttpGet("listado")]
        public List<string> ObtenerListaDeNombres()
        {
            return this.list;
        }

        [HttpGet("listado/{id}")]
        public ActionResult<string> ObtenerNombrePorId(int id)
        {
            if (id < 0 || id >= list.Count)
            {
                return BadRequest(new { mensaje = "Numero ingresado no válido", status = 400 });
            }

            return this.list[id];
        }
    }
}
