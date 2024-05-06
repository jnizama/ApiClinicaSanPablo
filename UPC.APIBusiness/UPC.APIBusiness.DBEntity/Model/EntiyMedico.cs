using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBEntity
{
    public class EntiyMedico
    {
		public Int32 idmedico { get; set; }

		public Int32 idespecialidad { get; set; }		

		public String nombre { get; set; }

		public String apellidos { get; set; }

		public String genero { get; set; }

		public String colegiatura { get; set; }

		public String correo { get; set; }

		public String telefono { get; set; }

		public String estado { get; set; }

		public DateTime fenvarcharegistro { get; set; }

		public DateTime fechaingreso { get; set; }

	}
}
