using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanillaAPI.DtoModels
{
    public class DtoAsistencia
    {
        public int Idasistencia { get; set; }
        public DateTime Fecha { get; set; }
        public int EmpleadoId { get; set; }
        public int Estado { get; set; }
    }
}
