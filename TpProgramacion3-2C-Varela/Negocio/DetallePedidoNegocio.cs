using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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


        public List<DetallePedido> listarDetallePedido(string id)
        {
            List<DetallePedido> lista = new List<DetallePedido>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT NROCOMPROBANTE, IDCLIENTE, FORMADEENVIO, PIDEFACTURA, FORMADEPAGO, FECHAALTA, ESTADO, HORAALTA, TOTAL from DETALLEPEDIDO ";
               // if (id != "")
                comando.CommandText += " WHERE IDCLIENTE = " + id;
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    DetallePedido aux = new DetallePedido();
                    aux.NROCOMPROBANTE = (Int64)lector["NROCOMPROBANTE"];

                    aux.CLIENTE = new Cliente();
                    aux.CLIENTE.IDCLIENTE = (int)lector["IDCLIENTE"]; //entre comillas es el el nombre que tiene en la base
                    aux.FORMADEENVIO = (string)lector["FORMADEENVIO"];

                    aux.FACTURA = new Factura();
                    aux.FACTURA.PIDE = (bool)lector["PIDEFACTURA"];

                    aux.FORMADEPAGO = (string)lector["FORMADEPAGO"];
                    aux.FECHAALTA = (DateTime)lector["FECHAALTA"];
                    aux.ESTADO = (string)lector["ESTADO"];
                    aux.HORAALTA = (TimeSpan)lector["HORAALTA"];
                    aux.TOTAL = (Double)lector["TOTAL"];


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

        
/*
        public List<DetallePedido> listar()
        {
            List<DetallePedido> lista = new List<DetallePedido>();

            lista.Add(new DetallePedido());
            lista.Add(new DetallePedido());

            lista[0].NROCOMPROBANTE = 1234;
            lista[1].NROCOMPROBANTE = 4567;

            return lista;

        }
*/

        public List<DetallePedido> listarDetallePedidoConSP()
        {
            List<DetallePedido> lista = new List<DetallePedido>();
            AccesoaDatos datos = new AccesoaDatos();
            try
            {
                datos.setearSP("listarDetallePedidoConSP");// ESTO LO AGREGO EN LA CLASE DE ACCESO A DATOS
                //CON ESTO EVITO LA CONSULTA EMBEBIDA QUE PUEDE FALLAR EN ALGUNA COMA Y ROMPE


                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    /*Pokemon aux = new Pokemon();
                    aux.Numero = datos.Lector.GetInt32(0);
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["UrlImagen"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["UrlImagen"];
                    aux.Tipo = new Elemento();
                    aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Descripcion = (string)datos.Lector["Debilidad"];

                    
                    lista.Add(aux);
                    */
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}

