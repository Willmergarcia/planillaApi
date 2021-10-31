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
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadoRepository empleadoRepository;
        private readonly IMapper mapper;

        public EmpleadosController(IEmpleadoRepository repository, IMapper _mapper)
        {
            empleadoRepository = repository;
            mapper = _mapper; 
        }

        [HttpGet("[action]")]
        public IActionResult GetEmpleados()
        {
            var empleados = empleadoRepository.GetEmpleados();
            var dtoEmpleados = new List<DtoEmpleado>();

            try
            {
                foreach(var lista in empleados)
                {
                    dtoEmpleados.Add(mapper.Map<DtoEmpleado>(lista)); 
                }

                return Ok(dtoEmpleados); 

            }catch(Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al mostrar los datos, {e.Message}");
                return StatusCode(500, ModelState); 
            }
        }

        [HttpPost("[action]")]
        public IActionResult CreateEmpleados([FromBody] DtoEmpleado dtoEmpleado)
        {
            if(dtoEmpleado == null)
            {
                return BadRequest(ModelState);
            }

            if(empleadoRepository.ExisteEmpleado(dtoEmpleado.Nombre))
            {
                ModelState.AddModelError("", $"El empleado {dtoEmpleado.Nombre} ya esta registrado");
                return StatusCode(404, ModelState); 
            }

            try
            {
                var empleado = mapper.Map<Empleado>(dtoEmpleado);
                empleadoRepository.CreateEmpleado(empleado);

                return Ok("Registro exitoso"); 

            }catch(Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al agregar a {dtoEmpleado.Nombre}");
                return StatusCode(500, ModelState); 
            }
        }

        [HttpPut("[action]/{empleadoId}")]
        public IActionResult UpdateEmpleado(int empleadoId, [FromBody] DtoEmpleado dtoEmpleado)
        {
            if(dtoEmpleado == null || empleadoId != dtoEmpleado.Id)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var empleado = mapper.Map<Empleado>(dtoEmpleado);
                empleadoRepository.UpdateEmpleado(empleado);

                return Ok("Actualizacion exitosa");

            }catch(Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al actualizar los datos de {dtoEmpleado.Nombre}, {e.Message}");
                return StatusCode(500, ModelState); 
            }
        }

        [HttpPut("[action]/{empleadoId}")]
        public IActionResult DeleteEmpleado(int empleadoId)
        {
            if (!empleadoRepository.ExisteEmpleado(empleadoId))
            {
                return NotFound();
            }

            try
            {
                var empleado = empleadoRepository.GetEmpleado(empleadoId);
                empleadoRepository.DeleteEmpleado(empleado); 

                return Ok($"Se dio de baja al empleado");

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Ha ocurrido un error al dar de baja al empleado");
                return StatusCode(500, ModelState);
            }
        }
    }
}
