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
        public List<Articulo> listar(string id = "")
        {
            List<Articulo> lista = new List<Articulo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                //comando.CommandText = "SELECT a.ID as ID, A.CODIGO,  a.Descripcion DART, a.Descripcion_AD DART_AD,  A.PRECIO, A.TIPO, a.OBS, A.ESTADO, a.ID_CATEGORIA IDCATEGORIA, a.urlimagen from ARTICULOS a";
                comando.CommandText = "select a.ID as ID, a.CODIGO, a.DESCRIPCION DART, a.DESCRIPCION_AD DART_AD, a.PRECIO, a.TIPO, A.OBS, A.ESTADO, A.ID_CATEGORIA IDCATEGORIA, A.URLIMAGEN, C.DESCRIPCION DESC_CAT from ARTICULOS as A, CATEGORIAS AS C where C.ID = A.ID_CATEGORIA ";
                if (id != "")
                    comando.CommandText += " and a.Id = " + id;
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

                    aux.CATEG = new Categoria();
                    aux.CATEG.ID = (int)lector["IDCATEGORIA"];
                    aux.CATEG.DESCRIPCION = (string)lector["DESC_CAT"];
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

        public void ModificarArticuloconSP(Articulo arti)
        {
            AccesoaDatos datos = new AccesoaDatos();
            try
            {

                /*@CODIGO VARCHAR(10),
                @CODIGO VARCHAR(10),
                @DESC VARCHAR(50),
                @DESCAD VARCHAR(100),
                @OBS VARCHAR(200),
                @ESTADO BIT,
                @PRECIO FLOAT,
                @URLIMAGEN VARCHAR(400),
                @ID INT
                */
                datos.setearSP("ModificarArticuloconSP");

                datos.setearParametro("@CODIGO", arti.CODIGO);
                datos.setearParametro("@DESC", arti.DESCRIPCION);
                datos.setearParametro("@DESCAD", arti.DESCRIPCION_AD);
                datos.setearParametro("@OBS", arti.OBS);
                datos.setearParametro("@ESTADO", arti.ESTADO);
                datos.setearParametro("@PRECIO", arti.PRECIO);
                //datos.setearParametro("@IDCAT", arti.CATEGORIA.ID);
                datos.setearParametro("URLIMAGEN", arti.URLIMAGEN);
                datos.setearParametro("@ID", arti.ID);

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


        public void eliminarLogico(int id, bool activo = false)
        {
            try
            {
                AccesoaDatos datos = new AccesoaDatos();
                datos.setearConsulta("update ARTICULOS set ESTADO = @activo Where id = @id");
                datos.setearParametro("@id", id);
                datos.setearParametro("@activo", activo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Articulo> ListarSoloActivos()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoaDatos datos = new AccesoaDatos();

            try
            {
                datos.setearSP("ListarSoloActivos");

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.ID = (int)datos.Lector["ID"];
                    aux.CODIGO = (string)datos.Lector["CODIGO"]; //entre comillas es el el nombre que tiene en la base
                    aux.DESCRIPCION = (string)datos.Lector["DART"];
                    aux.DESCRIPCION_AD = (string)datos.Lector["DART_AD"];
                    aux.PRECIO = decimal.Parse(datos.Lector["PRECIO"].ToString());
                    aux.TIPO = (string)datos.Lector["TIPO"];
                    aux.OBS = (string)datos.Lector["OBS"];
                    aux.ESTADO = (bool)datos.Lector["ESTADO"];
                    aux.CATEG = new Categoria();
                    aux.CATEG.ID = (int)datos.Lector["IDCATEGORIA"];
                    aux.CATEG.DESCRIPCION = (string)datos.Lector["DESC_CAT"];
                    aux.URLIMAGEN = (string)datos.Lector["URLIMAGEN"];

                                    

                    lista.Add(aux);
                }

                return lista;

            }
            catch (Exception)
            {

                throw;
            }



        }
    }
}
