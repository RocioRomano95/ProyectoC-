using Microsoft.AspNetCore.Mvc;
using Proyecto_finalRocioBRomano.models;

namespace ProyectoDeCsharp.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioService usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpGet("listado")]
        public IActionResult ObtenerListadoDeUsuarios()
        {
            List<Usuario> usuarios = this.usuarioService.ObtenerTodosLosUsuarios();

            if (usuarios != null && usuarios.Any())
            {
                return Ok(usuarios);
            }
            else
            {
                return NoContent();
            }
        }

    }
}
