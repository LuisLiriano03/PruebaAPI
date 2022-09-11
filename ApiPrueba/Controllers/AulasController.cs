using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using ApiPrueba.Models;
using System;

namespace ApiPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AulasController : ControllerBase
    {

        public readonly APIBDContext _dbcontext;

        public AulasController(APIBDContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Aula> lista = new List<Aula>();

            try
            {
                lista = _dbcontext.Aulas.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });
            }

        }



        [HttpGet]
        [Route("Obtener/{idAula}")]
        public IActionResult Obtener(int idAula)
        {
            Aula oAula = _dbcontext.Aulas.Find(idAula);

            if (oAula == null)
            {
                return BadRequest("Aula no encontrada");
            }


            try
            {
                oAula = _dbcontext.Aulas.Where(p => p.Idaulas == idAula).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oAula });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oAula });
            }

        }



        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Aula objeto)
        {

            try
            {
                _dbcontext.Aulas.Add(objeto);
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
        public IActionResult Editar([FromBody] Aula objeto)
        {

            Aula oAula = _dbcontext.Aulas.Find(objeto.Idaulas);


            if (oAula == null)
            {
                return BadRequest("Aula no encontrada");
            }

            try
            {

               
                oAula.Profesor = objeto.Profesor is null ? oAula.Profesor : objeto.Profesor;
                oAula.Alumnos = objeto.Alumnos is null ? oAula.Alumnos : objeto.Alumnos;



                _dbcontext.Aulas.Update(oAula);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }


        }



        [HttpDelete]
        [Route("Eliminar/{idAula:int}")]
        public IActionResult Eliminar(int idAula)
        {
            Aula oAula = _dbcontext.Aulas.Find(idAula);


            if (oAula == null)
            {
                return BadRequest("Aula no encontrada");
            }

            try
            {

                _dbcontext.Aulas.Remove(oAula);
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
