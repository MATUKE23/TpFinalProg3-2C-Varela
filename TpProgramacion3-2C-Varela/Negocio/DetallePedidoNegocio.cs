using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class DetallePedidoNegocio
    {

        public void AgregarDetallePedidoConSP(DetallePedido NuevoDetallePedido)// insert
        {
            AccesoaDatos datos = new AccesoaDatos();

            try
            {
                /*
                    @IDCLIENTE INT,
                    @FORMADEENVIO VARCHAR(120),
                    @PIDEFACTURA BIT,
                    @FORMADEPAGO VARCHAR(120),
                    @FECHAMODIFICACION DATE,
                    @FECHAALTA DATE
                */

                datos.setearSP("AgregarDetallePedidoConSP");

                datos.setearParametro("@IDCLIENTE", NuevoDetallePedido.CLIENTE.IDCLIENTE);
                datos.setearParametro("@FORMADEENVIO", NuevoDetallePedido.FORMADEENVIO);
                datos.setearParametro("@PIDEFACTURA", NuevoDetallePedido.FACTURA.PIDE);
                datos.setearParametro("@FORMADEPAGO", NuevoDetallePedido.FORMADEPAGO);
                //datos.setearParametro("@FECHAMODIFICACION", NuevoDetallePedido.FECHAMODIFICACION);
                //datos.setearParametro("@FECHAALTA", NuevoDetallePedido.FECHAALTA);
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


        public int ObtenerNroComprobante()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            int nrocomp;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT TOP (1) NROCOMPROBANTE FROM DETALLEPEDIDO ORDER BY FECHAALTA DESC";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();


                while (lector.Read())
                {

                    nrocomp = (int)lector["NROCOMPROBANTE"];


                }

                conexion.Close();
                return nrocomp;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }


            public List<DetallePedido> Listar()
        {
            List<DetallePedido> Lista = new List<DetallePedido>();
            return Lista;
        }

        public List<DetallePedido> ListarPorComprobante(int nroComprobante)
        {
            List<DetallePedido> Lista = new List<DetallePedido>();
            return Lista;
        }

   

    }
}
