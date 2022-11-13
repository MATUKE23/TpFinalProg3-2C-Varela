using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pedido
    {
        public int nroComprobante { get; set; }
        public string estado { get; set; }
        public string cliente { get; set; }
        public DateTime fechaAlta { get; set; }
        public DateTime fechaModificacion { get; set; }
        public string formaPago { get; set; }
        public decimal Total { get; set; }
    }
}
