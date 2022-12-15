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


        public List<CarritoC> listarDetallePedidoCarritoConformado(string id)
        {
            List<CarritoC> lista = new List<CarritoC>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select A.CODIGO AS CODIGOARTICULO, A.DESCRIPCION, C.CANTIDAD, A.PRECIO AS PRECIOUNITARIO, C.MONTO from CARRITOC AS C INNER JOIN ARTICULOS AS A ON C.IDARTICULO = A.ID ";
                comando.CommandText += " WHERE NROCOMPROBANTE = " + id;
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {

                    CarritoC aux = new CarritoC();

                    aux.ARTICULO = new Articulo();
                    aux.ARTICULO.CODIGO = (String)lector["CODIGOARTICULO"];
                    aux.ARTICULO.DESCRIPCION = (String)lector["DESCRIPCION"];
                    aux.CANTIDAD = (int)lector["CANTIDAD"];
                    aux.ARTICULO.PRECIO = decimal.Parse(lector["PRECIOUNITARIO"].ToString());
                    aux.MONTO = decimal.Parse(lector["MONTO"].ToString());


                    lista.Add(aux);

                }

                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }


    }
}
