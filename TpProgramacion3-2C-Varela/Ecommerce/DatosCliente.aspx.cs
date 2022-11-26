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
    public partial class DatosCliente : System.Web.UI.Page
    {
        public Cliente UsuarioActual { get; set; } // cuando me logueo el obj usuario se sube a la session
        protected void Page_Load(object sender, EventArgs e)

        {
            UsuarioActual = (Cliente)Session["UsuarioActual"]; //me traigo la session

            ClienteNegocio negocio = new ClienteNegocio();// instancio un clientenegocio para invocar al metodo listar cliente
            Cliente seleccionado = negocio.ListarCliente(id:UsuarioActual.IDCLIENTE); // le paso al metodo listar cliente el id de la session.
                
                //ClienteNegocio.ListarCliente((int)UsuarioActual.IDUSUARIO);

            //guardo CLiente seleccionado en session
            Session.Add("UsuarioActual", seleccionado);


            //pre cargar todos los campos...

            Nombre.Text = seleccionado.NOMBRES;
            Apellido.Text = seleccionado.APELLIDOS;
            

        }

        protected void BTNHacerPedido_Click(object sender, EventArgs e)
        {



            Response.Redirect("FormaDeEnvioPagoFactura.aspx");
        }
    }
}