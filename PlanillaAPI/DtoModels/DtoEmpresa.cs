
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanillaAPI.DtoModels
{
    public class DtoEmpresa
    {
        public int Idempresa { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int Estado { get; set; }
    }
}
