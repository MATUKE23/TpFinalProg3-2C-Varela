using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Ecommerce
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        public Usuario usuarioActual { get; set; }
        public List<Articulo> ListaArticulos { get; set; }
        public List<Articulo> carrito { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            carrito = (List<Articulo>)Session["carritoCompra"];

            usuarioActual = (Usuario)Session["usuarioActual"];


            if (carrito == null)
            {
                carrito = new List<Articulo>();
                Session.Add("carritoCompra", carrito);
            }

            if (usuarioActual == null)
            {
                usuarioActual = new Usuario();
                Session.Add("usuarioActual", usuarioActual);
            }

            if (usuarioActual.TipoUsuario == TipoUsuario.Admin)
            {
                Response.Redirect("DefaultAdmin.aspx");
            }

            ArticuloNegocio aux = new ArticuloNegocio();
            ListaArticulos = aux.listar();

        }

        protected void Desloguear(object sender, EventArgs e)
        {
            usuarioActual = null;
            Session.Add("usuarioActual", usuarioActual);
            Response.Redirect("Default.aspx");
        }
    }
}