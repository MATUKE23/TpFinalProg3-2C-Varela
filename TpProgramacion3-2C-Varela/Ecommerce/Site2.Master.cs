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
    public partial class Site2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e) // VALIDACION QUE EVITA SALTEAR EL LOGUEO INSERTANDO LA DIRECION ADMIN X URL
        {
            if (!(Session["usuarioActual"] != null && ((Dominio.Usuario)Session["usuarioActual"]).TipoUsuario == Dominio.TipoUsuario.Admin))
            {
                Session.Add("error", "No tienes permisos para ingresar a esta pantalla. Necesitas nivel admin.");
                Response.Redirect("Error0.aspx", false);
            }
        }

        public Usuario usuarioActual { get; set; }

        protected void Desloguear(object sender, EventArgs e)
        {
            usuarioActual = null;
            Session.Add("usuarioActual", usuarioActual);
            Response.Redirect("Default.aspx");
        }

    }
}