using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class Administrar_Pedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            DetallePedidoNegocio negocio = new DetallePedidoNegocio();// ME PERMITE DEVOLVER UNA LISTA DE DATOS
            dgvDetalleVentasAdmin.DataSource = negocio.listarDetallePedidoVistaAdmin();
            dgvDetalleVentasAdmin.DataBind();

            
        }

        protected void dgvDetalleVentas_SelectedIndexChanged(object sender, EventArgs e)
        {
           string id = dgvDetalleVentasAdmin.SelectedDataKey.Value.ToString();
            Response.Redirect("DetalleCarritoConformadoAdmin.aspx?id=" + id);
        }

        protected void dgvDetalleVentas_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            dgvDetalleVentasAdmin.PageIndex = e.NewSelectedIndex;
            dgvDetalleVentasAdmin.DataBind();
        }
    }
}