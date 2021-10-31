using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanillaAPI.DtoModels
{
    public class DtoEmpleado
    {
        public int Id { get; set; }
        public string Dpi { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public int EmpresaId { get; set; }
        public int PuestoId { get; set; }
        public int Estado { get; set; }
        public int DepartamentoId { get; set; }
        public decimal Salario { get; set; }
    }
}
