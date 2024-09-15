using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackendTest.Models;
using BackendTest.Services;

namespace BackendTest.Controllers
{
    [Route("api/Carrera")]
    [ApiController]

    public class CarreraController : ControllerBase
    {


        private readonly CarreraServices _carreraServices;
        public CarreraController(CarreraServices carreraServices)
        {
            _carreraServices = carreraServices;

        }

        [HttpGet]
        [Route("GetId/{id}")]

        public async Task<ActionResult<Carrera>> GetId(int id)
        {
            var carrera = await _carreraServices.GetCarrera(id);

            return Ok(carrera);

        }

        [HttpPost]
        [Route("Post")]

        public async Task<ActionResult> Post(Carrera Ocarrera)
        {
            await _carreraServices.PostCarrera(Ocarrera);
            return Ok("Carrera insertado");
        }

        [HttpPut]
        [Route("Put")]
        public async Task<ActionResult> Put(Carrera Ocarrera)
        {
            await _carreraServices.PutCarrera(Ocarrera);
            return Ok("Carrera Actualizado");
        }

        [HttpDelete]
        [Route("Delete{id}")]

        public async Task<ActionResult<List<Carrera>>> DeleteCarrera(int id)
        {
            var estudiante = await _carreraServices.DeleteCarrera(id);

            return Ok("carrera eliminado");
        }


    }
}
