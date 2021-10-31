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
    public class EmpresasController : ControllerBase
    {
        private readonly IEmpresaRepository empresaRepository;
        private readonly IMapper mapper;

        public EmpresasController(IEmpresaRepository repository, IMapper _mapper)
        {
            empresaRepository = repository;
            mapper = _mapper; 
        }

        [HttpGet("[action]")]
        public IActionResult GetEmpresas()
        {
            var empresas = empresaRepository.GetEmpresas();
            var dtoEmpresas = new List<DtoEmpresa>();

            try
            {
                foreach(var lista in empresas)
                {
                    dtoEmpresas.Add(mapper.Map<DtoEmpresa>(lista));
                }
                return Ok(dtoEmpresas); 

            }catch(Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al mostrar los datos {e.Message}");
                return StatusCode(500, ModelState); 
            }
        }

        [HttpPost("[action]")]
        public IActionResult CreateEmpresa([FromBody] DtoEmpresa dtoEmpresa)
        {
            if(dtoEmpresa == null)
            {
                return BadRequest(ModelState);
            }

            if(empresaRepository.ExisteEmpresa(dtoEmpresa.Nombre))
            {
                ModelState.AddModelError("", $"La empresa {dtoEmpresa.Nombre} ya existe");
                return StatusCode(404, ModelState); 
            }

            try
            {
                var empresa = mapper.Map<Empresa>(dtoEmpresa);
                empresaRepository.Create(empresa);

                return Ok("Se ha registrado la empresa"); 

            }catch(Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al agregar la empresa {dtoEmpresa.Nombre}, {e.Message}");
                return StatusCode(500, ModelState); 
            }
        }

        [HttpPut("[action]/{empresaId}")]
        public IActionResult UpdateEmpresas(int empresaId, [FromBody] DtoEmpresa dtoEmpresa)
        {
            if(dtoEmpresa == null || empresaId != dtoEmpresa.Idempresa)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var empresa = mapper.Map<Empresa>(dtoEmpresa);
                empresaRepository.Update(empresa);

                return Ok("Los datos fueron actualizados ");

            }catch(Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al actualizar los datos");
                return StatusCode(500, ModelState); 
            }
        }


        [HttpPut("[action]/{id}")]
        public IActionResult DeleteEmpresa(int id)
        {
            if(!empresaRepository.ExisteEmpresa(id))
            {
                return NotFound(); 
            }

            try
            {
                var empresa = empresaRepository.GetEmpresa(id);
                empresaRepository.Delete(empresa);

                return Ok("Se dio de baja la empresa"); 

            }catch(Exception e)
            {
                ModelState.AddModelError("", "Ha ocurrido un error al dar de baja la empresa");
                return StatusCode(500, ModelState); 
            }
        }
    }
}
