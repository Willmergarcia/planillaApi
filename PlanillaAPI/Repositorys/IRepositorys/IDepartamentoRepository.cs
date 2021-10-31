using PlanillaAPI.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanillaAPI.Repositorys.IRepositorys
{
    public interface IDepartamentoRepository
    {
        ICollection<Departamento> GetDepartamentos();
        Departamento GetDepartamento(int departamentoId);
        bool ExisteDepartamento(int departamentoId);
        bool ExisteDepartamento(string nombre);
        bool Create(Departamento departamento);
        bool Update(Departamento departamento);
        bool Delete(Departamento departamento);
        bool Save(); 
    }
}
