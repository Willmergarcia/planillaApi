using PlanillaAPI.Datos;
using PlanillaAPI.Repositorys.IRepositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanillaAPI.Repositorys
{
    public class PuestoRepository : IPuestoRepository
    {
        private readonly PlanillaContext db;

        public PuestoRepository(PlanillaContext planillaContext)
        {
            db = planillaContext; 
        }
        public bool CreatePuesto(Puesto puesto)
        {
            puesto.Estado = 1;
            db.Puestos.Add(puesto);
            return Save();
        }

        public bool Delete(Puesto puesto)
        {
            puesto.Estado = 0;
            db.Puestos.Update(puesto);
            return Save(); 
        }

        public bool ExistePuesto(int puestoId)
        {
            return db.Puestos.Any(p => p.Idpuesto == puestoId);
        }

        public bool ExistePuesto(string nombre)
        {
            return db.Puestos.Any(p => p.Nombre.ToLower().Trim() == nombre);
        }

        public Puesto GetPuesto(int puestoId)
        {
            return db.Puestos.FirstOrDefault(p => p.Idpuesto == puestoId);
        }

        public ICollection<Puesto> GetPuestos()
        {
            return (from p in db.Puestos where p.Estado == 1 select p).ToList(); 
        }

        public bool Save()
        {
            return db.SaveChanges() > 0; 
        }

        public bool UpdatePuesto(Puesto puesto)
        {
            puesto.Estado = 1;
            db.Puestos.Update(puesto);
            return Save(); 
        }
    }
}
