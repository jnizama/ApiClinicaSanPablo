using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBEntity
{
    public class EntityPago
    {
		public Int32 idpago { get; set; }

		public String descripcion { get; set; }

		public Int32 medio_pago { get; set; }

		public String tarjeta { get; set; }

		public String fechavencimiento { get; set; }

		public String ccv { get; set; }


	}
}
