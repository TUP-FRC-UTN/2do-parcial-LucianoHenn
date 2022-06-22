using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resultados.Usuarios;

namespace API.Controllers

{


    [ApiController]
    public class DeporteController : ControllerBase
    {
        private readonly prog3Context _context;

        public DeporteController(prog3Context context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/deporte/")]
        public async Task<DeporteResultado> ObtenerTodosLosDeportes()
        {
            var resultado = new DeporteResultado();

          
            resultado.ListaDeportes = await _context.Deportes.ToListAsync();
          
            resultado.Ok = true;
            resultado.StatusCode = 200;

            return resultado;

        }

   




    }
}

