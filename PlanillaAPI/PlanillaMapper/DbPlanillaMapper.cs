using AutoMapper;
using PlanillaAPI.Datos;
using PlanillaAPI.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanillaAPI.PlanillaMapper
{
    public class DbPlanillaMapper : Profile
    {
        public DbPlanillaMapper()
        {
            CreateMap<Empresa, DtoEmpresa>().ReverseMap();
            CreateMap<Departamento, DtoDepartamento>().ReverseMap();
            CreateMap<Puesto, DtoPuesto>().ReverseMap();
            CreateMap<Empleado, DtoEmpleado>().ReverseMap();
            CreateMap<Asistencia, DtoAsistencia>().ReverseMap();
            CreateMap<Usuario, DtoUsuario>().ReverseMap(); 
        }
    }
}
