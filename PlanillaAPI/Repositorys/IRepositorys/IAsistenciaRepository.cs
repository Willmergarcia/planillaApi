using PlanillaAPI.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanillaAPI.Repositorys.IRepositorys
{
    public interface IAsistenciaRepository
    {
        ICollection<Asistencia> GetAsistencias();
        Asistencia GetAsistencia(int asistenciaId);
        bool ExisteAsistencia(int asistenciaId);
        bool CreateAsistencia(Asistencia asistencia);
        bool UpdateAsistencia(Asistencia asistencia);
        bool DeleteAsistencia(Asistencia asistencia);
        bool Save(); 
    }
}
