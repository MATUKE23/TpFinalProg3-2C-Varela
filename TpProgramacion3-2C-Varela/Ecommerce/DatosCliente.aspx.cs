﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class DatosCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BTNHacerPedido_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormaDeEnvioPagoFactura.aspx");
        }
    }
}