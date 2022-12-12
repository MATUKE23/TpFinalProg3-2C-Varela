using System;
using System.Collections.Generic;
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
                    @IDARTICULO INT,
                    @CANTIDAD INT,
                    @MONTO FLOAT
              
                */
 
                datos.setearSP("AgregarCarritoCconSP");

              

                datos.setearParametro("@IDARTICULO", NuevoCarrito.ARTICULO.ID);
                datos.setearParametro("@CANTIDAD", NuevoCarrito.CANTIDAD);
                datos.setearParametro("@MONTO", NuevoCarrito.MONTO);

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
