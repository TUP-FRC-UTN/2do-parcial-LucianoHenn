using API.Models;
using Comandos.Usuario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resultados.Usuarios;

namespace API.Controllers

{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly prog3Context _context;

        public UserController(prog3Context context)
        {
            _context = context;
        
        }

        [HttpPost]
        [Route("api/usuario/login")]
        public async Task<LoginResultado> Login(LoginComando comando)
        {
            var resultado = new LoginResultado();
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(c => c.Email.Equals(comando.Email) && c.Password.Equals(comando.Password));

            if (usuario == null)
            {
                resultado.SetError("Credenciales incorrectas!");
                return resultado;
            }
            if(usuario.Activo == false)
            {
                resultado.SetError("Usuario se encuentra inactivo!");
                return resultado;
            }


            resultado.LoginResult = true;
            resultado.Ok = true;
            resultado.StatusCode = 200;
            return resultado;



        }



        [HttpGet]
        [Route("api/usuario/")]
        public async Task<UsuariosResultado> ObtenerUsuarios()
        {
            var resultado = new UsuariosResultado();


            resultado.ListaUsuarios = await _context.Usuarios.ToListAsync();
            resultado.Ok = true;
            resultado.StatusCode = 200;

            return resultado;

        }


    }
}

