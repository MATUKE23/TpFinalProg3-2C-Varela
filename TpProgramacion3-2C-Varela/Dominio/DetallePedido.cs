using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class DetallePedido
    {
        public int NROCOMPROBANTE { get; set; }
        public Cliente CLIENTE { get; set; }
        public CarritoC CARRITO { get; set; }
        public string FORMADEENVIO { get; set; }
        public Factura FACTURA { get; set; }
        public string FORMADEPAGO { get; set; }
        public DateTime FECHAMODIFICACION { get; set; }
        public DateTime FECHAALTA { get; set; }
        public string ESTADO { get; set; }

    }
}
