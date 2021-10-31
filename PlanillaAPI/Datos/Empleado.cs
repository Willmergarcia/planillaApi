using System;
using System.Collections.Generic;

#nullable disable

namespace PlanillaAPI.Datos
{
    public partial class Empleado
    {
        public Empleado()
        {
            Asistencia = new HashSet<Asistencia>();
        }

        public int Id { get; set; }
        public string Dpi { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public int EmpresaId { get; set; }
        public int PuestoId { get; set; }
        public int Estado { get; set; }
        public int DepartamentoId { get; set; }
        public decimal Salario { get; set; }

        public virtual Departamento Departamento { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual Puesto Puesto { get; set; }
        public virtual ICollection<Asistencia> Asistencia { get; set; }
    }
}
