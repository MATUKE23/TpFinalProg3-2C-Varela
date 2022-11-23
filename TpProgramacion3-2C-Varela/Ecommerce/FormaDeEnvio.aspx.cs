using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class FormaDeEnvio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbCondFiscal.Visible = false;
                ddlCondFiscal.Visible = false;
                lbCUIT.Visible = false; 
                txtCUIT.Visible = false;
                lbFormaDePago.Visible = false;
                ddlFormaDePago.Visible=false;
                btnHacerPedido.Visible = false;
            }
        }

        protected void txtSI_Click(object sender, EventArgs e)
        {
            lbCondFiscal.Visible = true;
            ddlCondFiscal.Visible = true;  
            lbCUIT.Visible = true;  
            txtCUIT.Visible = true;
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
    }
}