using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
     public class CarritoC
    {
        //public int ID { get; set; }
        public int NROCOMPROBANTE { get; set; }
        public Articulo ARTICULO { get; set; }
        public int CANTIDAD { get; set; }
        public decimal MONTO { get; set; }
        public bool ESTADO { get; set; }
       
          
    }
}
