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
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IMapper mapper;

        public UsuariosController(IUsuarioRepository repository, IMapper _mapper)
        {
            usuarioRepository = repository;
            mapper = _mapper;
        }

        [HttpGet("[action]")]
        public IActionResult GetUsuarios()
        {
            var usuarios = usuarioRepository.GetUsuarios();
            var dtoUsuarios = new List<DtoUsuario>();

            try
            {
                foreach (var lista in usuarios)
                {
                    dtoUsuarios.Add(mapper.Map<DtoUsuario>(lista));
                }
                return Ok(dtoUsuarios);

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al mostrar los datos {e.Message}");
                return StatusCode(500, ModelState);
            }
        }

        [HttpPost("[action]")]
        public IActionResult CreateUsuario([FromBody] DtoUsuario dtoUsuario) 
        {
            if (dtoUsuario == null)
            {
                return BadRequest(ModelState);
            }

            if (usuarioRepository.ExisteUsuario(dtoUsuario.User))
            {
                ModelState.AddModelError("", $"El usuario {dtoUsuario.User} ya existe");
                return StatusCode(404, ModelState);
            }

            try
            {
                var usuario = mapper.Map<Usuario>(dtoUsuario);
                usuarioRepository.CreateUser(usuario); 

                return Ok("Registro exitoso");

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al agregar el usuario {dtoUsuario.User}, {e.Message}");
                return StatusCode(500, ModelState);
            }
        }
    }
}
