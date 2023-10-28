using API_GreenConnect.DAO;
using API_GreenConnect.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API_GreenConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public IActionResult ListaUsuario()
        {
            var dao = new UsuarioDAO();
            var usuario = dao.Lista();
            return Ok(usuario);
        }

        [HttpPost]
        [Route("login")]
        public IActionResult LoginUsuario([FromForm]UsuarioDTO usuario)
        {
            var dao = new UsuarioDAO();
            var usuarios = dao.Login(usuario);

            if (usuarios.ID == 0 || usuario.ID == null)
            {
                return NotFound("Usuário não encontrado");
            }
            else
            {
                return Ok(usuarios);
            }
        }
    }
}
