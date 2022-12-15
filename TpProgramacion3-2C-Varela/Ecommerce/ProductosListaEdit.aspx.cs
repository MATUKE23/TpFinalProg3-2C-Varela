using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class ProductosListaEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            dgvProductos.DataSource = negocio.listar();
            dgvProductos.DataBind();

        }


        protected void dgvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

            string id = dgvProductos.SelectedDataKey.Value.ToString();
            Response.Redirect("Modificar Productos.aspx?id=" + id);

        }

        protected void dgvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvProductos.PageIndex = e.NewPageIndex;
            dgvProductos.DataBind();
        }
    }
}