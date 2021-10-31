using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanillaAPI.DtoModels
{
    public class DtoDepartamento
    {
        public int Iddepartamento { get; set; }
        public string Nombre { get; set; }
        public int EmpresaId { get; set; }
        public int Estado { get; set; }
    }
}
