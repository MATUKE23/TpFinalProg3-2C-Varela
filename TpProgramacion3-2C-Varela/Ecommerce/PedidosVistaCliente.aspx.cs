using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Ecommerce
{
    public partial class PedidosCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            
                string id = Request.QueryString["id"]; // != null ? Request.QueryString["id"].ToString() : "";

                DetallePedidoNegocio negocio = new DetallePedidoNegocio();// ME PERMITE DEVOLVER UNA LISTA DE DATOS
                dgvDatosCompra.DataSource = negocio.listarDetallePedido(id);
                dgvDatosCompra.DataBind();


/*
                DetallePedidoNegocio negocio2 = new DetallePedidoNegocio();// ME PERMITE DEVOLVER UNA LISTA DE DATOS
                XXX.DataSource = negocio2.listar();
                XXX.DataBind();
*/
                

            

        }

        /*
        protected void dgvDatosCompra_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvDatosCompra.SelectedDataKey.Value.ToString();
            Response.Redirect("Modificar Productos.aspx?id=" + id);
        }

        protected void dgvDatosCompra_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            dgvDatosCompra.PageIndex = e.NewSelectedIndex;
            dgvDatosCompra.DataBind();
        }

        */
    }
}