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
    public partial class Log_In : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            Usuario usuario;
            UsuarioNegocio negocio = new UsuarioNegocio();

            try
            {
                usuario = new Usuario(TextBoxLogIn.Text, TextBoxLogInPassword.Text, false); //asigno a objeto usuario los datos cargados en txtbox
                if (negocio.Loguear(usuario))//valida el logueo en con la base
                {
                  
                    Session.Add("usuarioActual", usuario);//agrego al usuario al session
                    Response.Redirect("Default.aspx",false);//redirigo a la pantalla de inicial 

                }
                else
                     {//sino error y redirigo a pagina de error.
                    Session.Add("Error", "Usted a ingresado un Usuario o Password incorrecto");//SI ES INCORRECTO 
                    Response.Redirect("Error0.aspx", false);
                }

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error0.aspx", false);
            }

           // redireccionar();
        }

        private void redireccionar()
        {
            Response.Redirect("default.aspx");
            //Usuario usuario = new Usuario();
            //usuario = (Usuario)(Session["usuarioActual"]);
            //if (usuario.TipoUsuario == TipoUsuario.Normal)
            //{

            //    Response.Redirect("default.aspx"); // SI ES TRUE VA AL ALA PAGINA DEL MENU
            //}
            //else if (usuario.TipoUsuario == TipoUsuario.Admin)
            //{
            //    Response.Redirect("DefaultAdmin.aspx");
            //}
        }
    }
}