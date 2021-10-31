using System;
using System.Collections.Generic;

#nullable disable

namespace PlanillaAPI.Datos
{
    public partial class Puesto
    {
        public Puesto()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int Idpuesto { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
