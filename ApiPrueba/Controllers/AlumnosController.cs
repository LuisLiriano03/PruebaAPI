using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using ApiPrueba.Models;
using System;

namespace ApiPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {


        public readonly APIBDContext _dbcontext;

        public AlumnosController(APIBDContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Alumno> lista = new List<Alumno>();

            try
            {
                lista = _dbcontext.Alumnos.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });
            }

        }


        [HttpGet]
        [Route("Obtener/{idAlumno}")]
        public IActionResult Obtener(int idAlumno)
        {
            Alumno oAlumno = _dbcontext.Alumnos.Find(idAlumno);

            if (oAlumno == null)
            {
                return BadRequest("Alumno no encontrado");
            }


            try
            {
                oAlumno = _dbcontext.Alumnos.Where(p => p.Idalumnos == idAlumno).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oAlumno });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oAlumno });
            }

        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Alumno objeto)
        {

            try
            {
                _dbcontext.Alumnos.Add(objeto);
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
        public IActionResult Editar([FromBody] Alumno objeto)
        {

            Alumno oAlumno = _dbcontext.Alumnos.Find(objeto.Idalumnos);


            if (oAlumno == null)
            {
                return BadRequest("Alumno no encontrado");
            }

            try
            {

                oAlumno.ApellidoPaterno = objeto.ApellidoPaterno is null ? oAlumno.ApellidoPaterno : objeto.ApellidoPaterno;
                oAlumno.ApellidoPaterno = objeto.ApellidoMaterno is null ? oAlumno.ApellidoMaterno : objeto.ApellidoMaterno;
                oAlumno.Nombre = objeto.Nombre is null ? oAlumno.Nombre : objeto.Nombre;
                oAlumno.FechaNacimiento = objeto.FechaNacimiento is null ? oAlumno.FechaNacimiento : objeto.FechaNacimiento;
                oAlumno.Genero = objeto.Genero is null ? oAlumno.Genero : objeto.Genero;
                oAlumno.LugarDeNacimiento = objeto.LugarDeNacimiento is null ? oAlumno.LugarDeNacimiento : objeto.LugarDeNacimiento;
                oAlumno.Nacionalidad = objeto.Nacionalidad is null ? oAlumno.Nacionalidad : objeto.Nacionalidad;
                oAlumno.Calle = objeto.Calle is null ? oAlumno.Calle : objeto.Calle;
                oAlumno.NumeroDeCalle = objeto.NumeroDeCalle is null ? oAlumno.NumeroDeCalle : objeto.NumeroDeCalle;
                oAlumno.NumeroDeTelefono = objeto.NumeroDeTelefono is null ? oAlumno.NumeroDeTelefono : objeto.NumeroDeTelefono;
                oAlumno.Email = objeto.Email is null ? oAlumno.Email : objeto.Email;



                _dbcontext.Alumnos.Update(oAlumno);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }


        }



        [HttpDelete]
        [Route("Eliminar/{idAlumno:int}")]
        public IActionResult Eliminar(int idAlumno)
        {
            Alumno oAlumno = _dbcontext.Alumnos.Find(idAlumno);


            if (oAlumno == null)
            {
                return BadRequest("Alumno no encontrado");
            }

            try
            {

                _dbcontext.Alumnos.Remove(oAlumno);
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
