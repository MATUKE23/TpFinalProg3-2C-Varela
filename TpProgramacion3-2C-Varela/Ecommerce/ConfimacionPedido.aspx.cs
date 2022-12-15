using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Ecommerce
{


    public partial class ConfimacionPedido : System.Web.UI.Page
    {

        public Usuario usuarioActual { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            usuarioActual = (Usuario)Session["usuarioActual"];
        }

     

        protected void IraMisPedidos_Click1(object sender, EventArgs e)
        {
            int id = usuarioActual.IDUSUARIO;

            Response.Redirect("PedidosVistaCliente.aspx?id=" + id , false);
        }
    }
}