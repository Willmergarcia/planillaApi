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
    public class DepartamentosController : ControllerBase
    {
        private readonly IDepartamentoRepository departementoRepository;
        private readonly IMapper mapper;

        public DepartamentosController(IDepartamentoRepository repository, IMapper _mapper)
        {
            departementoRepository = repository;
            mapper = _mapper; 
        }

        [HttpGet("[action]")]
        public IActionResult GetDepartamentos()
        {
            var departamentos = departementoRepository.GetDepartamentos();
            var dtoDepartamentos = new List<DtoDepartamento>();

            try
            {
                foreach(var lista in departamentos)
                {
                    dtoDepartamentos.Add(mapper.Map<DtoDepartamento>(lista));
                }

                return Ok(dtoDepartamentos); 

            }catch(Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al mostrar los datos: {e.Message}");
                return StatusCode(500, ModelState); 
            }
        }


        [HttpPost("[action]")]
        public IActionResult Create([FromBody] DtoDepartamento dtoDepartamento)
        {
            if (dtoDepartamento == null)
            {
                return BadRequest(ModelState);
            }

            if (departementoRepository.ExisteDepartamento(dtoDepartamento.Nombre))
            {
                ModelState.AddModelError("", $"La empresa {dtoDepartamento.Nombre} ya existe");
                return StatusCode(404, ModelState);
            }

            try
            {
                var departamento = mapper.Map<Departamento>(dtoDepartamento);
                departementoRepository.Create(departamento);

                return Ok(" registro exitoso");

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al agregar el departamento {dtoDepartamento.Nombre}, {e.Message}");
                return StatusCode(500, ModelState);
            }
        }


        [HttpPut("[action]/{id}")]
        public IActionResult Update(int id, [FromBody] DtoDepartamento dtoDepartamento)
        {
            if (dtoDepartamento == null || id != dtoDepartamento.Iddepartamento)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var departamento = mapper.Map<Departamento>(dtoDepartamento);
                departementoRepository.Update(departamento); 

                return Ok("Los datos fueron actualizados ");

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al actualizar los datos");
                return StatusCode(500, ModelState);
            }
        }

        [HttpPut("[action]/{id}")]
        public IActionResult Delete(int id)
        {
            if (!departementoRepository.ExisteDepartamento(id))
            {
                return NotFound();
            }

            try
            {
                var departamento = departementoRepository.GetDepartamento(id);
                departementoRepository.Delete(departamento);

                return Ok("Se dio de baja el departamento");

            }
            catch (Exception e)
            {
                ModelState.AddModelError("",$"Ha ocurrido un error al dar de baja el departamento {e.Message}");
                return StatusCode(500, ModelState);
            }
        }
    } 
}
