using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dominio
{
    public class DetallePedido
    {
        public Int64 NROCOMPROBANTE { get; set; }
        public Cliente CLIENTE { get; set; }
        public CarritoC CARRITO { get; set; }
        public string FORMADEENVIO { get; set; }
        public Factura FACTURA { get; set; }
        public string FORMADEPAGO { get; set; }
        public DateTime FECHAMODIFICACION { get; set; }
        public DateTime FECHAALTA { get; set; }
        public TimeSpan HORAALTA { get; set; }
        public string ESTADO { get; set; }
        public Double TOTAL { get; set; }

    }



   
}


