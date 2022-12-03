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


        protected void Page_Load(object sender, EventArgs e)
        {
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
                //btnSi.Visible=false;
                //btnNo.Visible = false;
                rdbSI.Visible = false;
                rdbNO.Visible = false;
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

            // si hay muchas opciones puede ir un enumerable+
            //    DetallePedido.a = true;
            //else if (rdbNO.Checked)
            //    aaa.importado = false;

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
    }
}