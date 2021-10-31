using PlanillaAPI.Datos;
using PlanillaAPI.Repositorys.IRepositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanillaAPI.Repositorys
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly PlanillaContext db;

        public EmpleadoRepository(PlanillaContext planillaContext)
        {
            db = planillaContext; 
        }
        public bool CreateEmpleado(Empleado empleado)
        {
            empleado.Estado = 1;
            db.Empleados.Add(empleado);
            return Save(); 
        }

        public bool DeleteEmpleado(Empleado empleado)
        {
            empleado.Estado = 0;
            db.Empleados.Update(empleado);
            return Save(); 
        }

        public bool ExisteEmpleado(int empleadoId)
        {
            return db.Empleados.Any(e => e.Id == empleadoId);
        }

        public bool ExisteEmpleado(string nombre)
        {
            return db.Empleados.Any(e => e.Nombre.ToLower().Trim() == nombre); 
        }

        public Empleado GetEmpleado(int empleadoId)
        {
            return db.Empleados.FirstOrDefault(e => e.Id == empleadoId); 
        }

        public ICollection<Empleado> GetEmpleados()
        {
            return (from e in db.Empleados where e.Estado == 1 select e).ToList(); 
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

        public bool UpdateEmpleado(Empleado empleado)
        {
            empleado.Estado = 1;
            db.Empleados.Update(empleado);
            return Save(); 
        }
    }
}
