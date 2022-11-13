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
    public partial class Pagar : System.Web.UI.Page
    {
        public decimal total { get; set; }
        public List<Articulo> carrito { get; set; } 

        protected void Page_Load(object sender, EventArgs e)
        {
            carrito = (List<Articulo>)Session["carritoCompra"];

            dgvArticulos.DataSource = carrito;
            dgvArticulos.DataBind();

            DbxFormaPago.Items.Add("EFECTIVO");
            DbxFormaPago.Items.Add("TARJETA");
            DbxFormaPago.Items.Add("TRANSFERENCIA");

            total = 0;
            foreach (Articulo aux in carrito)
            {
                total += (aux.CANTIDAD * aux.PRECIO);
            }

            
            
        }

        protected void EnviarPedido_click(object sender, EventArgs e)
        {
            DetallePedidoNegocio negocio = new DetallePedidoNegocio();

            Usuario auxUsuario = new Usuario();
            auxUsuario = (Usuario)Session["usuarioActual"];

            Pedido auxPedido = new Pedido();
            DetallePedido auxDetallePedido = new DetallePedido();

            PedidoNegocio negocio1 = new PedidoNegocio();

            auxPedido.cliente = auxUsuario.User; //cargo el cliente
            auxPedido.formaPago = DbxFormaPago.Text;
            auxPedido.Total = total;
                                      
            auxDetallePedido.idArticulo = carrito[0].ID;
            auxDetallePedido.cantidad = carrito[0].CANTIDAD;
            auxDetallePedido.monto = carrito[0].CANTIDAD * carrito[0].PRECIO;



            negocio1.AltaPedidoyDetallePedidoSP(auxPedido);

            Response.Redirect("Default.aspx");



        }
    }
}