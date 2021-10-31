using System;
using System.Collections.Generic;

#nullable disable

namespace PlanillaAPI.Datos
{
    public partial class Empresa
    {
        public Empresa()
        {
            Empleados = new HashSet<Empleado>();
            Usuarios = new HashSet<Usuario>();
        }

        public int Idempresa { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int Estado { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
