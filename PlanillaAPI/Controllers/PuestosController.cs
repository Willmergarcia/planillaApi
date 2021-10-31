using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanillaAPI.Datos;
using PlanillaAPI.DtoModels;
using PlanillaAPI.Repositorys.IRepositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanillaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuestosController : ControllerBase
    {
        private readonly IPuestoRepository puestoRepository;
        private readonly IMapper mapper;

        public PuestosController(IPuestoRepository repository, IMapper _mapper)
        {
            puestoRepository = repository;
            mapper = _mapper; 
        }

        [HttpGet("[action]")]
        public IActionResult GetPuestos()
        {
            var puestos = puestoRepository.GetPuestos();
            var dtoPuestos = new List<DtoPuesto>();

            try
            {
                foreach (var lista in puestos)
                {
                    dtoPuestos.Add(mapper.Map<DtoPuesto>(lista));
                }
                return Ok(dtoPuestos);

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al mostrar los datos {e.Message}");
                return StatusCode(500, ModelState);
            }
        }

        [HttpPost("[action]")]
        public IActionResult CreatePuesto([FromBody] DtoPuesto dtoPuesto)
        {
            if (dtoPuesto == null)
            {
                return BadRequest(ModelState);
            }

            if (puestoRepository.ExistePuesto(dtoPuesto.Nombre))
            {
                ModelState.AddModelError("", $"El puesto {dtoPuesto.Nombre} ya existe");
                return StatusCode(404, ModelState);
            }

            try
            {
                var puesto = mapper.Map<Puesto>(dtoPuesto);
                puestoRepository.CreatePuesto(puesto); 

                return Ok("Se ha registrado el puesto");

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al agregar el puesto {dtoPuesto.Nombre}, {e.Message}");
                return StatusCode(500, ModelState);
            }
        }

        [HttpPut("[action]/{puestoId}")]
        public IActionResult UpdatePuesto(int puestoId, [FromBody] DtoPuesto dtoPuesto)
        {
            if (dtoPuesto == null || puestoId != dtoPuesto.Idpuesto)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var puesto = mapper.Map<Puesto>(dtoPuesto);
                puestoRepository.UpdatePuesto(puesto); 

                return Ok("Los datos fueron actualizados ");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al actualizar los datos, {e.Message}");
                return StatusCode(500, ModelState);
            }
        }

        [HttpPut("[action]/{puestoId}")]
        public IActionResult DeletePuesto(int puestoId)
        {
            if (!puestoRepository.ExistePuesto(puestoId))
            {
                return NotFound();
            }

            try
            {
                var puesto = puestoRepository.GetPuesto(puestoId);
                puestoRepository.Delete(puesto); 

                return Ok("El puesto fue desabilitado");

            }
            catch (Exception e)
            {
                ModelState.AddModelError("",$"Ha ocurrido un error al desabilitar el puesto, {e.Message}");
                return StatusCode(500, ModelState);
            }
        }
    }
}
