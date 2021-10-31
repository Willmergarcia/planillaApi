using PlanillaAPI.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanillaAPI.Repositorys.IRepositorys
{
    public interface IEmpleadoRepository
    {
        ICollection<Empleado> GetEmpleados();
        Empleado GetEmpleado(int empleadoId);
        bool ExisteEmpleado(int empleadoId);
        bool ExisteEmpleado(string nombre);
        bool CreateEmpleado(Empleado empleado);
        bool UpdateEmpleado(Empleado empleado);
        bool DeleteEmpleado(Empleado empleado);
        bool Save(); 
    }
}
