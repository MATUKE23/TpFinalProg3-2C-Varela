using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using System.Security.Cryptography;


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
                comando.CommandText = "SELECT a.ID as ID, A.CODIGO,  a.Descripcion DART, a.Descripcion_AD DART_AD,  A.PRECIO, A.TIPO, a.OBS, A.ESTADO, a.ID_CATEGORIA IDCATEGORIA, a.urlimagen from ARTICULOS a";
               // comando.CommandText = "select a.ID as ID, a.CODIGO, a.DESCRIPCION DART, a.DESCRIPCION_AD DART_AD, a.PRECIO, a.TIPO, A.OBS, A.ESTADO, A.ID_CATEGORIA IDCATEGORIA, C.DESCRIPCION CATEGORIA from ARTICULOS  as A, CATEGORIAS where C.ID = A.ID_CATEGORIA ";
                //if (id != "")
                //    comando.CommandText += " and P.Id = " + id;
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.ID = (int)lector["ID"];
                    aux.CODIGO = (string)lector["CODIGO"]; //entre comillas es el el nombre que tiene en la base
                    aux.DESCRIPCION = (string)lector["DART"];
                    aux.DESCRIPCION_AD = (string)lector["DART_AD"];
                    aux.PRECIO = decimal.Parse(lector["PRECIO"].ToString());
                    aux.TIPO = (string)lector["TIPO"];
                    aux.OBS = (string)lector["OBS"];
                    aux.ESTADO = (bool)lector["ESTADO"];
                    //aux.ID_CATEGORIA = new Categoria();
                    // aux.ID_CATEGORIA.ID = (int)lector["IDCATEGORIA"];
                    //aux.ID_CATEGORIA.DESCRIPCION = (string)lector["CATEGORIA"];
                    aux.URLIMAGEN = (string)lector["URLIMAGEN"];

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

        public void AgregarProductoConSP(Articulo nuevo)
        {
            AccesoaDatos datos = new AccesoaDatos();

            try
            {
                /*
                @code varchar(10),
                @desc varchar(50),
                @descAD varchar(1000),
                @precio float,
                @tipo varchar(3), dummy
                @Obs varchar(200),
                @estado bit,
                @IdCat int,dummy
                @URLimagen varchar(400)
                */


                datos.setearSP("AgregarProductoConSP");
                datos.setearParametro("@code", nuevo.CODIGO);
                datos.setearParametro("@desc", nuevo.DESCRIPCION);
                datos.setearParametro("@descAD", nuevo.DESCRIPCION_AD);
                datos.setearParametro("@precio", nuevo.PRECIO);
                //datos.setearParametro("@tipo", nuevo.TIPO);dummy
                datos.setearParametro("@Obs", nuevo.OBS);
                //datos.setearParametro("@estado", nuevo.ESTADO);
                //datos.setearParametro("@IdCat", nuevo.ID_CATEGORIA);dummy
                datos.setearParametro("@URLimagen", nuevo.URLIMAGEN);
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
