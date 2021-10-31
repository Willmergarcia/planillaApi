using System;
using System.Collections.Generic;

#nullable disable

namespace PlanillaAPI.Datos
{
    public partial class Usuario
    {
        public int Idusuario { get; set; }
        public string User { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public int Estado { get; set; }
        public int Tipo { get; set; }
        public int? EmpresaId { get; set; }

        public virtual Empresa Empresa { get; set; }
    }
}
