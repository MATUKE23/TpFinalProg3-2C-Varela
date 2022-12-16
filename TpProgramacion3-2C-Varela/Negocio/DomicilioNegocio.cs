using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class DomicilioNegocio
    {

        public List<Domicilio> listarDetalleDomicilio(string id)
        {
            List<Domicilio> lista = new List<Domicilio>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT do.IDDOMICILIO,  DO.PROVINCIA, DO.PARTIDO, Do.LOCALIDAD, do.CODIGO_POSTAL, DO.CALLE, do.NUMERO, do.ENTRE_CALLES as ENTRECALLES, do.NUMERO_DEPTO, do.PISO, do.OBSERVACIONES from DETALLEPEDIDO AS D INNER JOIN CLIENTES AS C ON D.IDCLIENTE= C.IDCLIENTE INNER JOIN DOMICILIOS AS DO ON C.IDCLIENTE = DO.IDDOMICILIO";
                comando.CommandText += " where NROCOMPROBANTE = " + id;
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Domicilio aux = new Domicilio();
                    

                    aux.IDDOMICILIO = (int)lector["IDDOMICILIO"];
                    aux.PROVINCIA = (string)lector["PROVINCIA"];
                    aux.PARTIDO = (string)lector["PARTIDO"];
                    aux.LOCALIDAD = (string)lector["LOCALIDAD"];
                    aux.CODIGO_POSTAL = (int)lector["CODIGO_POSTAL"];
                    aux.CALLE = (string)lector["CALLE"];
                    aux.NUMERO = (int)lector["NUMERO"];
                    aux.ENTRECALLES = (string)lector["ENTRECALLES"];
                    aux.NUMERO_DEPTO = (string)lector["NUMERO_DEPTO"];
                    aux.PISO = (string)lector["PISO"];

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
