using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Ecommerce
{
    public partial class Producto : System.Web.UI.Page
    {
        public Articulo articulo { get; set; }
        public Usuario usuarioActual { get; set; }

        protected void Page_Load(object sender, EventArgs e)

        {
            usuarioActual = (Usuario)Session["usuarioActual"];


            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : ""; //guardo en una varible el ID que me traigo de la URL
            //int id = int.Parse(Request.QueryString["id"].ToString()); //guardo en una varible el ID que me traigo de la URL
            List<Articulo> lista = (List<Articulo>)Session["ListaArticulos"]; //crea una lista de articulos a partir de la session abierta
            foreach (Articulo arti in lista)
            {
                if (arti.ID == int.Parse(id))
                {
                    articulo = arti; //asigno al obj  articulo lo que esta en la session y esta contiene la lista de articulos

                }

            }



            if (articulo.CATEG.ID == 1)

            {
                btnAgregar.Text = "Agregar al carrito";
            }
            else btnAgregar.Text = "Pedir Presupuesto";

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (usuarioActual.User == null)
            {
                Response.Redirect("Log in.aspx");

            }

            agregar();


        }

        protected void btnIrAlCarritoClick(object sender, EventArgs e)
        {
            //agregar();
            Response.Redirect("Carrito.aspx");
        }

        protected void agregar()
        {
            List<Articulo> carrito = (List<Articulo>)Session["carritoCompra"];
            Articulo aux = new Articulo();
            aux = articulo;
            bool nuevo = true; //Bandera para identificar si es nueva compra o no

            foreach (Articulo art in carrito)
            {
                if (art.CODIGO == articulo.CODIGO) // si esta en session entonces no es nuevo
                {
                    art.CANTIDAD += int.Parse(txtCantidad.Text);//atributo que actua como un acumulador
                    nuevo = false;
                    break;
                }
            }

            if (nuevo)
            {
                aux.CANTIDAD = int.Parse(txtCantidad.Text);
                carrito.Add(aux); // si es nuevo agrega al carrigo el articulo
            }

            Session.Add("carritoCompra", carrito);
        }

        protected void ContinuarComprando_Click(object sender, EventArgs e)
        {
            Response.Redirect("Productos.aspx", false);
        }
    }
}