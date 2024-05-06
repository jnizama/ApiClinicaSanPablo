using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBEntity
{
    public class EntityCita
    {
		public Int32 idcita { get; set; }

		public Int32 idmedico { get; set; }

		public Int32 idusuario { get; set; }

		public Int32 idpago { get; set; }

		public Int32 idespecialidad { get; set; }

		public Int32 idsede { get; set; }

		public String estadocita { get; set; }

		public String descripcion { get; set; }

		public DateTime fechacita { get; set; }

		public DateTime fenvarcharegistro { get; set; }

	}
}
