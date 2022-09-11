using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using ApiPrueba.Models;

namespace ApiPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesoresController : ControllerBase
    {

        public readonly APIBDContext _dbcontext;

        public ProfesoresController(APIBDContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Profesore> lista = new List<Profesore>();

            try
            {
                lista = _dbcontext.Profesores.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });
            }

        }


        [HttpGet]
        [Route("Obtener/{idProfesores:int}")]
        public IActionResult Obtener(int idProfesores)
        {
            Profesore oProfesores = _dbcontext.Profesores.Find(idProfesores);

            if (oProfesores == null)
            {
                return BadRequest("Profesor no encontrado");
            }


            try
            {
                oProfesores = _dbcontext.Profesores.Where(p => p.Idempleado == idProfesores).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oProfesores });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oProfesores });
            }

        }


        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Profesore objeto)
        {

            try
            {
                _dbcontext.Profesores.Add(objeto);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }


        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Profesore objeto)
        {

            Profesore oProfesores = _dbcontext.Profesores.Find(objeto.Idempleado);

            if (oProfesores == null)
            {
                return BadRequest("Profesor no encontrado");
            }

            try
            {

                oProfesores.NombreCompleto = objeto.NombreCompleto is null ? oProfesores.NombreCompleto : objeto.NombreCompleto;
                oProfesores.Genero = objeto.Genero is null ? oProfesores.Genero : objeto.Genero;
                oProfesores.FechaNacimiento = objeto.FechaNacimiento is null ? oProfesores.FechaNacimiento : objeto.FechaNacimiento;
                oProfesores.LugarDeNacimiento = objeto.LugarDeNacimiento is null ? oProfesores.LugarDeNacimiento : objeto.LugarDeNacimiento;
                oProfesores.Nacionalidad = objeto.Nacionalidad is null ? oProfesores.Nacionalidad : objeto.Nacionalidad;
                oProfesores.Cedula = objeto.Cedula is null ? oProfesores.Cedula : objeto.Cedula;
                oProfesores.EstadoCivil = objeto.EstadoCivil is null ? oProfesores.EstadoCivil : objeto.EstadoCivil;
                oProfesores.DepartamentoEnseñar = objeto.DepartamentoEnseñar is null ? oProfesores.DepartamentoEnseñar : objeto.DepartamentoEnseñar;
                oProfesores.Telefono = objeto.Telefono is null ? oProfesores.Telefono : objeto.Telefono;
                oProfesores.Activo = objeto.Activo is null ? oProfesores.Activo : objeto.Activo;
                oProfesores.Email = objeto.Email is null ? oProfesores.Email : objeto.Email;



                _dbcontext.Profesores.Update(oProfesores);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }


        }





    }
}
