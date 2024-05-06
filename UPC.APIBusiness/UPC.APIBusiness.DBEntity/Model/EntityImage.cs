using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBEntity
{
    public class EntityImage : EntityBase
    {
        public int IdImagen { get; set; }
        public string Nombre { get; set; }
        public string Ruta { get; set; }
        public int IdProyecto { get; set; }
        public int IdDepartamento { get; set; }
        public string Tipo { get; set; }
    }
}
