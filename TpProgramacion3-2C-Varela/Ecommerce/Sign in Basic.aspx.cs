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
    public partial class Sign_in_Basic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
       

        }

        protected void ButtonRegistrarse_Click(object sender, EventArgs e)
        {
            Usuario U = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();  

            U.User = TextBoxAgregaMail.Text;
            U.Pass = TextBoxPass.Text;


            negocio.AltaUsuarioSP(U);

            Response.Redirect("Log In.aspx");            
            
                       

        }
    }
}