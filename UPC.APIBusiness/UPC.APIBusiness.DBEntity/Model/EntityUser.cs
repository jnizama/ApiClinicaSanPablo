using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityUser : EntityBase
    {
        public int IdUsuario { get; set; } // MEJORA: Reemplazar por Key, ID - Alias BD
        public String Usuario { get; set; }        
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Token { get; set; }
    }
}
