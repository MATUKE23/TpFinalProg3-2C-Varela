using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Web;
using System.Web.Services.Discovery;
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



        protected void dgvDetalleVentasAdmin_RowCommand1(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "Domicilio")
            {

                int index = Convert.ToInt32(e.CommandArgument);

                //GridViewRow selectedRow = dgvDetalleVentasAdmin.Rows[index];

                //object TableCell = selectedRow.Cells[0];

                dgvDetalleVentasAdmin.SelectedIndex = index;

                index = 0;

                int id = int.Parse(dgvDetalleVentasAdmin.SelectedDataKey.Values[index].ToString());

                Response.Redirect("DetalleDomicilioAdmin.aspx?id=" + id);


            }

            if (e.CommandName == "Carrito")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                dgvDetalleVentasAdmin.SelectedIndex = index;

                index = 0;

                int id = int.Parse(dgvDetalleVentasAdmin.SelectedDataKey.Values[index].ToString());

                Response.Redirect("DetalleCarritoConformadoAdmin.aspx?id=" + id);


            }


        }
    }
}