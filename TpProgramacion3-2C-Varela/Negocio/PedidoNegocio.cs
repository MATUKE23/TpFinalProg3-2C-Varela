using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;


namespace Negocio
{
   public class PedidoNegocio
    {
        /*  public List<Pedido> Listar()
          {
              List<Pedido> Lista = new List<Pedido>();
              return Lista;


          }

        public List<Pedido> ListarPorCliente()
        {

            List<Pedido> listar0()
            {
                List<Pedido> lista = new List<Pedido>();
                SqlConnection conexion = new SqlConnection();
                SqlCommand comando = new SqlCommand();
                SqlDataReader lector;

                try
                {
                    conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security=true";
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.CommandText = "select p.NroComprobante, p.Estado, p.FechaAlta, p.FechaModificacion, p.FormaDePago, p.Total from Pedidos as p where Cliente = 'TUKE'";
                    comando.Connection = conexion;

                    conexion.Open();
                    lector = comando.ExecuteReader();

                    while (lector.Read())
                    {
                        Pedido aux = new Pedido();
                        aux.nroComprobante = (int)lector["NroComprobante"];
                        aux.estado = (string)lector["Estado"];
                        aux.fechaAlta = (DateTime)lector["FechaAlta"];
                        aux.fechaModificacion = (DateTime)lector["FechaModificacion"];
                        aux.Total = decimal.Parse(lector["Total"].ToString());
                        aux.formaPago = (string)lector["FormaDePago"];


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
    */
        public void AltaPedidoyDetallePedidoSP(Pedido nuevo)
        {
            AccesoaDatos datos = new AccesoaDatos();

            datos.setearSP("AltaPedido");
            datos.setearParametro("@cliente", nuevo.cliente);
            datos.setearParametro("@FormaDePago", nuevo.formaPago);
            datos.setearParametro("@Total", nuevo.Total);
            datos.ejecutarAccion();
        }

        public void ListarPedidosXUsuario(Pedido nuevo)
        {
            AccesoaDatos datos = new AccesoaDatos();

            datos.setearSP("ListarPedidosXUsuario");
            datos.setearParametro("@Cliente", nuevo.cliente);
            datos.ejecutarAccion();
        }



    }
}
