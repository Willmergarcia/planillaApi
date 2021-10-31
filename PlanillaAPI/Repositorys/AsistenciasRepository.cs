using PlanillaAPI.Datos;
using PlanillaAPI.Repositorys.IRepositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanillaAPI.Repositorys
{
    public class AsistenciasRepository : IAsistenciaRepository
    {
        private readonly PlanillaContext db;

        public AsistenciasRepository(PlanillaContext planillaContext)
        {
            db = planillaContext; 
        }
        public bool CreateAsistencia(Asistencia asistencia)
        {
            asistencia.Estado = 1;
            db.Asistencias.Add(asistencia);
            return Save(); 
        }

        public bool DeleteAsistencia(Asistencia asistencia)
        {
            asistencia.Estado = 0;
            db.Asistencias.Update(asistencia);
            return Save(); 
        }

        public bool ExisteAsistencia(int asistenciaId)
        {
            return db.Asistencias.Any(a => a.Idasistencia == asistenciaId);
        }

        public Asistencia GetAsistencia(int asistenciaId)
        {
            return db.Asistencias.FirstOrDefault(a => a.Idasistencia == asistenciaId);
        }


        public ICollection<Asistencia> GetAsistencias()
        {
            return (from a in db.Asistencias where a.Estado == 1 select a).ToList(); 
        }

       

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

        public bool UpdateAsistencia(Asistencia asistencia)
        {
            db.Asistencias.Update(asistencia);
            return Save(); 
        }
    }
}
