using System;
using System.Collections.Generic;

#nullable disable

namespace PlanillaAPI.Datos
{
    public partial class Asistencia
    {
        public int Idasistencia { get; set; }
        public DateTime Fecha { get; set; }
        public int EmpleadoId { get; set; }
        public int Estado { get; set; }

        public virtual Empleado Empleado { get; set; }
    }
}
