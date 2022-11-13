using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
     public class DetallePedido
    {
        public int nroComprobante { get; set; }
        public int idArticulo { get; set; }
        public int cantidad { get; set; }
        public decimal monto { get; set; }
    }
}
