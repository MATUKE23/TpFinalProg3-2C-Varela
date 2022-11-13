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
    public partial class caja : System.Web.UI.Page
    {
        public List<Articulo> carrito { get; set; }
        public decimal total { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            carrito = (List<Articulo>)Session["carritoCompra"];
            EjecutarAccion();

            total = 0;
            foreach (Articulo aux in carrito)
            {
                total += (aux.CANTIDAD * aux.PRECIO);
            }

        }

        private void EjecutarAccion()
        {
            int cont;
            string accion;
            if (Request.QueryString["contador"] != null)
            {
                cont = int.Parse(Request.QueryString["contador"].ToString());
                accion = Request.QueryString["accion"].ToString();

                switch (accion)
                {
                    case "agregar":
                        carrito[cont].CANTIDAD++;
                        break;

                    case "quitar":
                        if (carrito[cont].CANTIDAD > 1)
                        {
                            carrito[cont].CANTIDAD--;
                        }
                        else
                        {
                            carrito.RemoveAt(cont);
                        }
                        break;
                    case "quitarTodo":
                        carrito.RemoveAt(cont);
                        break;
                }

                Session.Add("carritoCompra", carrito);
                Response.Redirect("Caja.aspx");
            }
        }

        protected void VaciarCarrito(object sender, EventArgs e)
        {
            carrito.Clear();
            Session.Add("carritoCompra", carrito);
            Response.Redirect("Caja.aspx");
        }

        protected void Pagar(object sender, EventArgs e)
        {
            Response.Redirect("Pagar.aspx");
        }

    }
}