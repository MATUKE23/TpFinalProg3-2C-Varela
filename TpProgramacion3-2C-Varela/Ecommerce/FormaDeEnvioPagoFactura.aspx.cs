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
    // public DetallePedido Test { get; set; }

    public partial class FormaDeEnvio : System.Web.UI.Page
    {
        public List<Articulo> carrito { get; set; }
        public CarritoC nuevoCarritoC { get; set; }
        public decimal total { get; set; }
        public Usuario usuarioActual { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            usuarioActual = (Usuario)Session["usuarioActual"];

            if (!IsPostBack)
            {
                lbCondFiscal.Visible = false;
                ddlCondFiscal.Visible = false;
                lbCUIT.Visible = false;
                txtCUIT.Visible = false;
                lbFormaDePago.Visible = false;
                ddlFormaDePago.Visible = false;
                btnHacerPedido.Visible = false;
                SolicitaFactura.Visible = false;
                rdbSI.Visible = false;
                rdbNO.Visible = false;
            }

        }


        protected void txtCUIT_TextChanged(object sender, EventArgs e)
        {
            lbFormaDePago.Visible = true;
            ddlFormaDePago.Visible = true;

        }

        protected void ddlFormaDePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnHacerPedido.Visible = true;
        }

        protected void ddlFormadeEnvio_SelectedIndexChanged(object sender, EventArgs e)
        {
            SolicitaFactura.Visible = true;

            rdbSI.Visible = true;
            rdbNO.Visible = true;

            //btnSi.Visible = true;
            // btnNo.Visible = true;

            DetallePedido nuevo = new DetallePedido();

            nuevo.FORMADEENVIO = ddlFormadeEnvio.SelectedValue;

            Session.Add("EnvioSeleccionado", nuevo.FORMADEENVIO);

        }

        protected void SI_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSI.Checked)
            {
                lbCondFiscal.Visible = true;
                ddlCondFiscal.Visible = true;
                lbCUIT.Visible = true;
                txtCUIT.Visible = true;

                DetallePedido nuevo = new DetallePedido();

                // nuevo.FACTURA.PIDE = rdbSI.Checked;
                bool fact = rdbSI.Checked;

                Session.Add("Factura", rdbSI.Checked);


            }

        }

        protected void NO_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbNO.Checked)
            {
                lbFormaDePago.Visible = true;
                ddlFormaDePago.Visible = true;

                DetallePedido nuevo = new DetallePedido();

                //nuevo.FACTURA.PIDE = rdbNO.Checked;

                Session.Add("Factura", rdbNO.Checked);

            }
        }

        protected void btnHacerPedido_Click(object sender, EventArgs e)
        {
            // bajar de la session DEL CARRITO un objeto articulo 
            // pasar el objeto articulo a un metodo agregarDetallePedido
            // Revisar tabla detalle pedido y crear SP

            DetallePedidoNegocio detallePedidoNegocio = new DetallePedidoNegocio();

            DetallePedido nuevoDetallePedido = new DetallePedido();

            nuevoDetallePedido.CLIENTE = new Cliente();
            nuevoDetallePedido.CLIENTE.IDCLIENTE = usuarioActual.IDUSUARIO;
            nuevoDetallePedido.FORMADEENVIO = ddlFormadeEnvio.SelectedValue;
            nuevoDetallePedido.FACTURA = new Factura();
            nuevoDetallePedido.FACTURA.PIDE = rdbSI.Checked;
            nuevoDetallePedido.FACTURA.CONDICIONFISCAL = ddlCondFiscal.SelectedValue;
            nuevoDetallePedido.FACTURA.NROCUIT = txtCUIT.ToString();
            nuevoDetallePedido.FORMADEPAGO = ddlFormaDePago.SelectedValue;
            nuevoDetallePedido.CARRITO = new CarritoC();
            nuevoDetallePedido.CARRITO.MONTO = total;

            detallePedidoNegocio.AgregarDetallePedidoConSP(nuevoDetallePedido);



            CarritoC nuevoCarritoC = new CarritoC();


            CarritoCNegocio carritocNegocio = new CarritoCNegocio();


            carrito = (List<Articulo>)Session["carritoCompra"];


            foreach (Articulo aux in carrito)

            {
                nuevoCarritoC.NROCOMPROBANTE = detallePedidoNegocio.ObtenerNroComprobante();

                nuevoCarritoC.ARTICULO.ID = aux.ID;

                nuevoCarritoC.CANTIDAD = aux.CANTIDAD;

                //nuevoCarritoC.TOTAL  += (aux.CANTIDAD * aux.PRECIO);

                nuevoCarritoC.MONTO = aux.CANTIDAD * aux.PRECIO;

                //total += (aux.CANTIDAD * aux.PRECIO);


                carritocNegocio.AgregarCarritoCconSP(nuevoCarritoC);
            }

        }
    }
}