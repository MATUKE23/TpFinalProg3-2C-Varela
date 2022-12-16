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
    public partial class DetalleDomicilioAdmin : System.Web.UI.Page
    {

        public Usuario usuarioActual { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

            DomicilioNegocio negocio = new DomicilioNegocio();// ME PERMITE DEVOLVER UNA LISTA DE DATOS
            dgvDatosDetalleDomicilioAdmin.DataSource = negocio.listarDetalleDomicilio(id);
            dgvDatosDetalleDomicilioAdmin.DataBind();

            usuarioActual = (Usuario)Session["usuarioActual"];
        }

        protected void IraMisPedidos_Click(object sender, EventArgs e)
        {
            int id = usuarioActual.IDUSUARIO;

            Response.Redirect("PedidosVistaAdmin.aspx?id=" + id, false);
        }
    }
}