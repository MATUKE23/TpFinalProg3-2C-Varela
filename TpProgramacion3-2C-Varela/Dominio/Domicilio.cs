using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Domicilio
    {
        [DisplayName("Id del Domicilio")]
        public int IDDOMICILIO { get; set; }

        [DisplayName("Calle")]
        public int CALLE { get; set; }

        [DisplayName("Numero")]
        public int NUMERO { get; set; }

        [DisplayName("Codigo Postal")]
        public int CODIGO_POSTAL { get; set; }

        [DisplayName("Provincia")]
        public int PROVINCIA { get; set; }

        [DisplayName("Partido")]
        public int PARTIDO { get; set; }

        [DisplayName("Localidad")]
        public int LOCALIDAD { get; set; }

        [DisplayName("Numero de Departamento")]
        public int NUMERO_DEPTO { get; set; }

        [DisplayName("PISO")]
        public int PISO { get; set; }

        [DisplayName("Observaciones")]
        public int OBSERVACIONES { get; set; }
    }
}
