using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;


namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT a.ID as ID, A.CODIGO,  a.Descripcion DART,  A.PRECIO, A.TIPO, a.OBS, A.ESTADO, a.ID_CATEGORIA IDCATEGORIA from ARTICULOS a";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.ID = (int)lector["ID"];
                    aux.CODIGO = (string)lector["CODIGO"];
                    aux.DESCRIPCION = (string)lector["DART"];
                    aux.PRECIO = decimal.Parse(lector["PRECIO"].ToString());
                    aux.TIPO = (string)lector["TIPO"];
                    aux.TIPO = (string)lector["OBS"];
                    //aux.TIPO = (bool)lector["ESTADO"];
                   // aux.ID_CATEGORIA = (int)lector["IDCATEGORIA"];


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
