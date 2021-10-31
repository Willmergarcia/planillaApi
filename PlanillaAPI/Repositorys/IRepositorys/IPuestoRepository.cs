using PlanillaAPI.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanillaAPI.Repositorys.IRepositorys
{
    public interface IPuestoRepository
    {
        ICollection<Puesto> GetPuestos();
        Puesto GetPuesto(int puestoId);
        bool ExistePuesto(int puestoId);
        bool ExistePuesto(string nombre);
        bool CreatePuesto(Puesto puesto);
        bool UpdatePuesto(Puesto puesto);
        bool Delete(Puesto puesto);
        bool Save(); 
    }
}
