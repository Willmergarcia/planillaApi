using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanillaAPI.DtoModels
{
    public class DtoUsuario
    {
        public int Idusuario { get; set; }
        public string User { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public int Estado { get; set; }
        public int Tipo { get; set; }
        public int? EmpresaId { get; set; }
    }
}
