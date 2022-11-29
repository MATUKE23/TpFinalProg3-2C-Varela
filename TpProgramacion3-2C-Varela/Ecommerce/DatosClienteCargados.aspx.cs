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
    public partial class DatosClienteCargados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClienteNegocio negocio1 = new ClienteNegocio();

            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            
            if (negocio1.ValidaDatosClienteCompletos(id) == 1 & !IsPostBack)//Valida si tiene los datos clave completos
                                                              // si entras es porque faltan cargar datos clave 
            {
                                              
                    ClienteNegocio negocio = new ClienteNegocio();// instancio un clientenegocio para invocar al metodo listar cliente
                                                                  //Cliente seleccionado = negocio.ListarCliente(id);
                    Cliente seleccionado = (negocio.ListarCliente(id))[0]; // le paso al metodo listar cliente el id de la session.

                    Session.Add("UserSelected", seleccionado);

                    Nombre.Text = seleccionado.NOMBRES;
                    DNI.Text = seleccionado.DNI.ToString();
                    Apellido.Text = seleccionado.APELLIDOS;
                    Telefono1.Text = seleccionado.TELEFONO_1;
                    FechaNac.Text = seleccionado.FECHA_NACIMIENTO.ToString("dd-MM-yyyy");
                    //FechaNac.Text = seleccionado.FECHA_NACIMIENTO.Date.ToString("mm-dd-yyyy");
                    Telefono2.Text = seleccionado.TELEFONO_2;
                    Calle.Text = seleccionado.DOMICILIO.CALLE;
                    EntreCalles.Text = seleccionado.DOMICILIO.ENTRECALLES;
                    CodigoPostal.Text = seleccionado.DOMICILIO.CODIGO_POSTAL.ToString();
                    Provincia.Text = seleccionado.DOMICILIO.PROVINCIA;
                    Partido.Text = seleccionado.DOMICILIO.PARTIDO;
                    Localidad.Text = seleccionado.DOMICILIO.LOCALIDAD;
                    NroDepto.Text = seleccionado.DOMICILIO.NUMERO_DEPTO;
                    Piso.Text = seleccionado.DOMICILIO.PISO;
                    Obs.Text = seleccionado.DOMICILIO.OBSERVACIONES;



                    //guardo CLiente seleccionado en session

                


            }

        }

    }

}
