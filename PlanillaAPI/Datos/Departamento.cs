using System;
using System.Collections.Generic;

#nullable disable

namespace PlanillaAPI.Datos
{
    public partial class Departamento
    {
        public Departamento()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int Iddepartamento { get; set; }
        public string Nombre { get; set; }
        public int EmpresaId { get; set; }
        public int Estado { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
