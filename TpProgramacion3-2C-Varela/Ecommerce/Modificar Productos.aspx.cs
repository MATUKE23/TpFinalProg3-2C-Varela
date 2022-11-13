using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace Ecommerce
{
    public partial class Modificar_Productos : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            ArticuloNegocio aux = new ArticuloNegocio();
            ListaArticulos = aux.listar();

            List<Imagen> listaImagen = new List<Imagen>();
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            listaImagen = imagenNegocio.listar();

            foreach (Articulo auxArticulo in ListaArticulos)
            {
                auxArticulo.URLIMAGEN = "https://socialistmodernism.com/wp-content/uploads/2017/07/placeholder-image.png";
            }

            foreach (Articulo auxArticulo in ListaArticulos)
            {
                foreach (Imagen auxImagen in listaImagen)
                {
                    if (auxArticulo.ID == auxImagen.id_articulo && auxImagen.orden == 1)
                    {
                        auxArticulo.URLIMAGEN = auxImagen.url;
                    }
                }
            }
            Session.Add("ListaArticulos", ListaArticulos);

        }
    }
}