using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente
    {
        

        [DisplayName("Nombres")]
        public string NOMBRES { get; set; }

        [DisplayName("Apellidos")]

        public string APELLIDOS { get; set; }

        [DisplayName("D.N.I")]
        public int DNI { get; set; }

        [DisplayName("Telefono 1")]
        public string TELEFONO_1 { get; set; }

        [DisplayName("Telefono 2")]
        public string TELEFONO_2 { get; set; }

        [DisplayName("Fecha de Nacimiento")]
        
        public DateTime FECHA_NACIMIENTO { get; set; }

        [DisplayName("Estado")]
        public bool ESTADO { get; set; }


        [DisplayName("Id del Cliente")]
        public int IDCLIENTE { get; set; }

        public Domicilio DOMICILIO { get; set; }


    }
}
