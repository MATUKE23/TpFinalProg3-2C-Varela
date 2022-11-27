﻿using Dominio;
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
        //public Cliente UsuarioActual { get; set; } // cuando me logueo el obj usuario se sube a la session
        protected void Page_Load(object sender, EventArgs e)

        {
            //UsuarioActual = (Cliente)Session["UsuarioActual"]; //me traigo la session

            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : ""; //guardo en una varible el ID que me traigo de la URL
            if (!IsPostBack)
            {
                ClienteNegocio negocio = new ClienteNegocio();// instancio un clientenegocio para invocar al metodo listar cliente
                Cliente seleccionado = (negocio.ListarCliente(id))[0]; // le paso al metodo listar cliente el id de la session.

                //(negocio.listar(id))[0];
                //ClienteNegocio.ListarCliente((int)UsuarioActual.IDUSUARIO);


                Session.Add("UserSelected", seleccionado);

                Nombre.Text = seleccionado.NOMBRES;
                DNI.Text = seleccionado.DNI.ToString();
                Apellido.Text = seleccionado.APELLIDOS;
                Telefono1.Text = seleccionado.TELEFONO_1;
                //FechaNac.Text = seleccionado.FECHA_NACIMIENTO.ToString();
                FechaNac.Text = seleccionado.FECHA_NACIMIENTO.Date.ToString("mm-dd-yyyy");
                Telefono2.Text = seleccionado.TELEFONO_2;


                //guardo CLiente seleccionado en session

            }





        }

        //pre cargar todos los campos...

        protected void BTNHacerPedido_Click(object sender, EventArgs e)
        {

            Response.Redirect("FormaDeEnvioPagoFactura.aspx");
        }

    }


}
