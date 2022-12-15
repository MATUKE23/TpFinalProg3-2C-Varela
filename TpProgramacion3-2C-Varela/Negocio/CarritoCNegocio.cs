using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CarritoCNegocio
    {
        public void AgregarCarritoCconSP(CarritoC NuevoCarrito)// insert
        {
            AccesoaDatos datos = new AccesoaDatos();

            try
            {
                /*
                  * @NROCOMPROBANTE BIGINT
                    @IDARTICULO INT,
                    @CANTIDAD INT,
                    @MONTO FLOAT
              
                */

                datos.setearSP("AgregarCarritoCconSP");

                datos.setearParametro("@NROCOMPROBANTE", NuevoCarrito.NROCOMPROBANTE);
                datos.setearParametro("@IDARTICULO", NuevoCarrito.ARTICULO.ID);
                datos.setearParametro("@CANTIDAD", NuevoCarrito.CANTIDAD);
                datos.setearParametro("@MONTO", NuevoCarrito.MONTO);
                datos.setearParametro("@TOTAL", NuevoCarrito.TOTAL);


                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

       

    }
}
