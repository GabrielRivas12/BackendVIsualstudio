using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackendTest.Models;
using BackendTest.Services;

namespace BackendTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly EstudianteServices _estudianteServices;
        public EstudianteController(EstudianteServices estudianteServices)
        {
            _estudianteServices = estudianteServices;

        }

        [HttpGet]
        [Route("GetId/{id}")]

        public async Task<ActionResult<List<Estudiante>>>GetId(int id)
        {
            var estudiante = await _estudianteServices.GetEstudiante(id);
            
                return Ok(estudiante);
            
        }

        [HttpPost]
        [Route("Post")]

        public async Task<ActionResult> Post(Estudiante Oestudiante)
        {
            await _estudianteServices.PostEstudiante(Oestudiante);
            return Ok("Estudiante insertado");
        }

        [HttpPut]
        [Route("Put")]



        public async Task<ActionResult> Put(Estudiante Oestudiante)
        {
            await _estudianteServices.PutEstudiante(Oestudiante);
            return Ok("Estudiante Actualizado");
        }


       

        [HttpDelete]
        [Route("Delete{id}")]

        public async Task<ActionResult<List<Estudiante>>> DeleteEstudiante(int id)
        {
            var estudiante = await _estudianteServices.DeleteEstudiante(id);

            return Ok("Estudinte eliminado");
        }

       

        
    }
}
