using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class DetalleCarritoConformado : System.Web.UI.Page
    {

        public Usuario usuarioActual { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

            CarritoCNegocio negocio = new CarritoCNegocio();// ME PERMITE DEVOLVER UNA LISTA DE DATOS
            dgvDatosDetalleCarritoConformado.DataSource = negocio.listarDetallePedidoCarritoConformado(id);
            dgvDatosDetalleCarritoConformado.DataBind();

            usuarioActual = (Usuario)Session["usuarioActual"];
        }

        protected void IraMisPedidos_Click(object sender, EventArgs e)
        {
            int id = usuarioActual.IDUSUARIO;

            Response.Redirect("PedidosVistaCliente.aspx?id=" + id, false);
        }


    }
}