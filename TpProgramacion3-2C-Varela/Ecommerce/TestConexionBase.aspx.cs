using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;


namespace Ecommerce
{
    public partial class TestConexionBase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ArticuloNegocio articulo = new ArticuloNegocio(); //devuelve una lista de Datos

            dgvArticulos.DataSource = articulo.listar();
            dgvArticulos.DataBind();
        }
    }
}