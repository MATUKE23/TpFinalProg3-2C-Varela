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
        public string CALLE { get; set; }

        [DisplayName("Numero")]
        public int NUMERO { get; set; }

        [DisplayName("Entre Calles")]
        public string ENTRECALLES { get; set; }


        [DisplayName("Codigo Postal")]
        public int CODIGO_POSTAL { get; set; }

        [DisplayName("Provincia")]
        public string PROVINCIA { get; set; }

        [DisplayName("Partido")]
        public string PARTIDO { get; set; }

        [DisplayName("Localidad")]
        public string LOCALIDAD { get; set; }

        [DisplayName("Numero de Departamento")]
        public string NUMERO_DEPTO { get; set; }

        [DisplayName("PISO")]
        public string PISO { get; set; }

        [DisplayName("Observaciones")]
        public string OBSERVACIONES { get; set; }
    }
}
