using PlanillaAPI.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanillaAPI.Repositorys.IRepositorys
{
    public interface IEmpresaRepository
    {
        ICollection<Empresa> GetEmpresas();
        Empresa GetEmpresa(int empresaId);
        bool ExisteEmpresa(int empresaId);
        bool ExisteEmpresa(string nombre);
        bool Create(Empresa empresa);
        bool Update(Empresa empresa);
        bool Delete(Empresa empresa);
        bool Save(); 
    }
}
