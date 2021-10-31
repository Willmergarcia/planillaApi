using PlanillaAPI.Datos;
using PlanillaAPI.Repositorys.IRepositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanillaAPI.Repositorys
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly PlanillaContext db;

        public DepartamentoRepository(PlanillaContext planillaContext)
        {
            db = planillaContext;
        }
        public bool Create(Departamento departamento)
        {
            departamento.Estado = 1; 
            db.Departamentos.Add(departamento);
            return Save();
        }

        public bool Delete(Departamento departamento)
        {
            departamento.Estado = 0;
            db.Departamentos.Update(departamento);
            return Save(); 
        }

        public bool ExisteDepartamento(int departamentoId)
        {
            return db.Departamentos.Any(d => d.Iddepartamento == departamentoId);
        }

        public bool ExisteDepartamento(string nombre)
        {
            return db.Departamentos.Any(d => d.Nombre.ToLower().Trim() == nombre);
        }

        public Departamento GetDepartamento(int departamentoId)
        {
            return db.Departamentos.FirstOrDefault(d => d.Iddepartamento == departamentoId); 
        }

        public ICollection<Departamento> GetDepartamentos()
        {
            return (from d in db.Departamentos where d.Estado == 1 select d).ToList(); 
        }

        public bool Save()
        {
            return db.SaveChanges() > 0; 
        }

        public bool Update(Departamento departamento)
        {
            departamento.Estado = 1;
            db.Departamentos.Update(departamento);
            return Save(); 
        }
    }
}
