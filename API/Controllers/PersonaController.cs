using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Comandos.Usuario;
using Resultados;

namespace API.Controllers

{
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly prog3Context _context;

        public PersonaController(prog3Context context)
        {
            _context = context;

        }


        [HttpPost]
        [Route("api/persona")]
        public async Task<ResultadoBase> crearNuevaPersona(RegisterComando comando)
        {
            var resultado = new ResultadoBase();
            var newPersona = new Persona();

            var user = _context.Personas.Max(p => p.Id);


            newPersona.Apellido = comando.Apellido;
            newPersona.Nombre = comando.Nombre;
            newPersona.Dni = comando.Dni;
            newPersona.Direccion = comando.Direccion;
           

            var result = _context.Personas.Add(newPersona);
            await _context.SaveChangesAsync();


            resultado.Ok = true;
            resultado.StatusCode = 200;
            return resultado;



        }


        [HttpGet]
        [Route("api/persona")]
        public async Task<List<Persona>> GetAll()
        {
            return await _context.Personas.ToListAsync();



        }



    }
}

