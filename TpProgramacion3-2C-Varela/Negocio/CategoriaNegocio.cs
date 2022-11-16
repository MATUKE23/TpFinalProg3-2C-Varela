using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listarCategoria()

        { 
        List<Categoria> lista = new List<Categoria>();
        AccesoaDatos datos = new AccesoaDatos();


            try
            {
                datos.setearConsulta("select ID, DESCRIPCION from CATEGORIAS");
                datos.ejecutarLectura();

                while(datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.ID = (int)datos.Lector["ID"];
                    aux.DESCRIPCION = (string)datos.Lector["DESCRIPCION"];

                    lista.Add(aux);

                }

                return lista;

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
