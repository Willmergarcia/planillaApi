using PlanillaAPI.Datos;
using PlanillaAPI.Repositorys.IRepositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanillaAPI.Repositorys
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly PlanillaContext db;

        public EmpresaRepository(PlanillaContext planillaContext)
        {
            db = planillaContext;
        }

        public bool Create(Empresa empresa)
        {
            empresa.Estado = 1;
            db.Empresas.Add(empresa);
            return Save();
        }

        public bool Delete(Empresa empresa)
        {
            empresa.Estado = 0;
            db.Empresas.Update(empresa);
            return Save();
        }

        public bool ExisteEmpresa(int empresaId)
        {
            return db.Empresas.Any(e => e.Idempresa == empresaId);
        }

        public bool ExisteEmpresa(string nombre)
        {
            return db.Empresas.Any(e => e.Nombre.ToLower().Trim() == nombre);
        }

        public Empresa GetEmpresa(int empresaId)
        {
            return db.Empresas.FirstOrDefault(e => e.Idempresa == empresaId);
        }

        public ICollection<Empresa> GetEmpresas()
        {
            return (from e in db.Empresas where e.Estado ==1 select e).ToList(); 
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

        public bool Update(Empresa empresa)
        {
            empresa.Estado = 1;
            db.Empresas.Update(empresa);
            return Save(); 
        }
    }
}
