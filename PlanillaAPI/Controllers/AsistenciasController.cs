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
    public class AsistenciasController : ControllerBase
    {
        private readonly IAsistenciaRepository asistenciaRepository;
        private readonly IMapper mapper;

        public AsistenciasController(IAsistenciaRepository repository, IMapper _mapper)
        {
            asistenciaRepository = repository;
            mapper = _mapper;
        }

        [HttpGet("[action]")]
        public IActionResult GetAsistencias()
        {
            var asistencias = asistenciaRepository.GetAsistencias();
            var dtoAsistencias = new List<DtoAsistencia>();

            try
            {
                foreach (var lista in asistencias)
                {
                    dtoAsistencias.Add(mapper.Map<DtoAsistencia>(lista));
                }

                return Ok(dtoAsistencias);

            } catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido al mostrar las asistencias, {e.Message}");
                return StatusCode(500, ModelState);
            }
        }

        [HttpGet("[action]")]
        public ActionResult GetEmpleadoFecha()  
        {
            try
            {
                using (PlanillaContext db = new PlanillaContext())
                {
                    var list = (from e in db.Empleados
                                join a in db.Asistencias on e.Id equals a.EmpleadoId
                                where a.Estado == 1
                                select new
                                {
                                    fecha = a.Fecha,
                                    nombre = e.Nombre,
                                    telefono = e.Telefono
                                }).ToList();

                    return Ok(list);
                }
            }
            catch(Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al mostrar los datos, {e.Message}");
                return StatusCode(500, ModelState); 
            }
        }

        [HttpGet("[action]")]
        public ActionResult ReporteNomina()
        {
            try
            {
                using (PlanillaContext db = new PlanillaContext())
                {
                   // decimal bono14;

                    var list = (from e in db.Empleados
                                join p in db.Puestos on e.PuestoId equals p.Idpuesto
                                select new
                                {
                                    nombre = e.Nombre,
                                    puesto = p.Nombre,
                                    salario = e.Salario,
                                    bono14 = e.Salario*(365/36)

                                }).ToList();

                    return Ok(list); 
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al mostrar los datos");
                return StatusCode(500, ModelState); 
            }
        }

        [HttpPost("[action]")]
        public IActionResult CreateAsistencia([FromBody] DtoAsistencia dtoAsistencia)
        {

            if (dtoAsistencia == null)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var asistencia = mapper.Map<Asistencia>(dtoAsistencia);
                asistenciaRepository.CreateAsistencia(asistencia);

                return Ok("Asistencia registrada");

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al ingresar la asistencia, {e.Message}");
                return StatusCode(500, ModelState);
            }
        }

        [HttpPut("[action]/{asitenciaId}")]
        public IActionResult UpdateAsistencias(int asitenciaId, [FromBody] DtoAsistencia dtoAsistencia)
        {

            if (dtoAsistencia == null || asitenciaId != dtoAsistencia.Idasistencia)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var asistencia = mapper.Map<Asistencia>(dtoAsistencia);
                asistenciaRepository.UpdateAsistencia(asistencia);

                return Ok("Los datos fueron actualizados ");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al actualizar los datos, {e.Message}");
                return StatusCode(500, ModelState);
            }
        }

        [HttpPut("[action]/{asistenciaId}")]
        public IActionResult DeleteAsistencia(int asistenciaId)
        {
            if (!asistenciaRepository.ExisteAsistencia(asistenciaId))
            {
                return NotFound();
            }

            try
            {
                var asistencia = asistenciaRepository.GetAsistencia(asistenciaId);
                asistenciaRepository.DeleteAsistencia(asistencia); 

                return Ok("la asistencia fue desabilitada");

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al desabilitar, {e.Message}");
                return StatusCode(500, ModelState);
            }
        }
    }
}
