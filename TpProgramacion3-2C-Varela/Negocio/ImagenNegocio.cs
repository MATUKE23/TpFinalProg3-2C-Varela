using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ImagenNegocio
    {
        public List<Imagen> listar()
        {
            List<Imagen> auxLista = new List<Imagen>();
            AccesoaDatos datos = new AccesoaDatos();

            try
            {
                datos.setearConsulta("SELECT ID, URL, ORDEN, ID_ARTICULO FROM ECOMMERCE.dbo.IMAGENES WHERE ESTADO = '1'");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Imagen aux = new Imagen();
                    aux.id = (int)datos.Lector["id"];
                    aux.url = (string)datos.Lector["URL"];
                    aux.orden = (int)datos.Lector["ORDEN"];
                    aux.id_articulo = (int)datos.Lector["ID_ARTICULO"];

                    auxLista.Add(aux);
                }

                return auxLista;
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
