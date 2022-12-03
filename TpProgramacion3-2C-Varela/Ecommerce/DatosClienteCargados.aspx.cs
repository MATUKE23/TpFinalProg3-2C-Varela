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
    public partial class DatosClienteCargados : System.Web.UI.Page
    {
        public int validador { get; set; }

        public List<Articulo> carrito { get; set; }

        public decimal total { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            carrito = (List<Articulo>)Session["carritoCompra"];

            total = 0;
            foreach (Articulo aux in carrito)
            {
                total += aux.CANTIDAD;
            }


            if (!IsPostBack && total == 0)
            {
                btneteHacerPedido.Visible = false;
            }
            else { btneteHacerPedido.Visible = true; }

            ClienteNegocio negocio1 = new ClienteNegocio();

            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

            validador = negocio1.ValidaDatosClienteCompletos(id);

            //Session["validador"] = negocio1.ValidaDatosClienteCompletos(id);

           


            if (!IsPostBack & negocio1.ValidaDatosClienteCompletos(id) == 1)//Valida si tiene los datos clave completos
                                                                            // si entras es porque no falta cargar datos clave 
            {
                ClienteNegocio negocio = new ClienteNegocio();// instancio un clientenegocio para invocar al metodo listar cliente
                                                              //Cliente seleccionado = negocio.ListarCliente(id);
                Cliente seleccionado = (negocio.ListarCliente(id))[0]; // le paso al metodo listar cliente el id de la session.

                Session.Add("UserSelected", seleccionado); // precargo datos, si no tiene rompe con null

                Nombre.Text = seleccionado.NOMBRES;
                DNI.Text = seleccionado.DNI.ToString();
                Apellido.Text = seleccionado.APELLIDOS;
                Telefono1.Text = seleccionado.TELEFONO_1;
                FechaNac.Text = seleccionado.FECHA_NACIMIENTO.ToString("dd-MM-yyyy");
                //FechaNac.Text = seleccionado.FECHA_NACIMIENTO.Date.ToString("mm-dd-yyyy");
                Telefono2.Text = seleccionado.TELEFONO_2;
                Calle.Text = seleccionado.DOMICILIO.CALLE;
                Numero.Text = seleccionado.DOMICILIO.NUMERO.ToString();
                EntreCalles.Text = seleccionado.DOMICILIO.ENTRECALLES;
                CodigoPostal.Text = seleccionado.DOMICILIO.CODIGO_POSTAL.ToString();
                Provincia.Text = seleccionado.DOMICILIO.PROVINCIA;
                Partido.Text = seleccionado.DOMICILIO.PARTIDO;
                Localidad.Text = seleccionado.DOMICILIO.LOCALIDAD;
                NroDepto.Text = seleccionado.DOMICILIO.NUMERO_DEPTO;
                Piso.Text = seleccionado.DOMICILIO.PISO;
                Obs.Text = seleccionado.DOMICILIO.OBSERVACIONES;



              


            }

        }

        protected void AddModif(object sender, EventArgs e)
        {
            try
            {
                Cliente NuevoCliente = new Cliente();  // lo instancio para poder llamar al metodo agregarConSP 

                ClienteNegocio negocio = new ClienteNegocio();//aca cargamos los datos del nuevo objeto 
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";


                /*
                   @NOMBRES nvarchar(max),
                   @APELLIDOS nvarchar(max),
                   @DNI int,
                   @TELEFONO_1 nvarchar(22),
                   @TELEFONO_2 nvarchar(22),
                   @FECHA_NACIMIENTO date,
                   @ESTADO BIT,//dummy precargado
                   @IDCLIENTE int,
                   @CALLE nvarchar(100), 
                   @NUMERO INT,
                   @ENTRE_CALLES nvarchar(250),
                   @CODIGO_POSTAL INT,
                   @PROVINCIA nvarchar(50),
                   @PARTIDO nvarchar(50),
                   @LOCALIDAD nvarchar(50),
                   @NUMERO_DEPTO nvarchar(3),
                   @PISO nvarchar(10),
                   @OBSERVACIONES nvarchar(1000)
                */

                if (negocio.ValidaDatosClienteCompletos(id) == 1)//Valida si tiene los datos clave completos
                { //cargo en obj nuevocliente todos los datos para modificar tablas

                    NuevoCliente.IDCLIENTE = int.Parse(id);
                    NuevoCliente.NOMBRES = Nombre.Text;
                    NuevoCliente.APELLIDOS = Apellido.Text;
                    NuevoCliente.DNI = int.Parse(DNI.Text);
                    NuevoCliente.TELEFONO_1 = Telefono1.Text;
                    NuevoCliente.TELEFONO_2 = Telefono2.Text;
                    NuevoCliente.FECHA_NACIMIENTO = DateTime.Parse(FechaNac.Text);

                    NuevoCliente.DOMICILIO = new Domicilio();
                    NuevoCliente.DOMICILIO.IDDOMICILIO = int.Parse(id);
                    NuevoCliente.DOMICILIO.CALLE = Calle.Text;
                    NuevoCliente.DOMICILIO.NUMERO = int.Parse(Numero.Text);
                    NuevoCliente.DOMICILIO.ENTRECALLES = EntreCalles.Text;
                    NuevoCliente.DOMICILIO.CODIGO_POSTAL = int.Parse(CodigoPostal.Text);
                    NuevoCliente.DOMICILIO.PROVINCIA = Provincia.Text;
                    NuevoCliente.DOMICILIO.PARTIDO = Partido.Text;
                    NuevoCliente.DOMICILIO.LOCALIDAD = Localidad.Text;
                    NuevoCliente.DOMICILIO.NUMERO_DEPTO = NroDepto.Text;
                    NuevoCliente.DOMICILIO.PISO = Piso.Text;
                    NuevoCliente.DOMICILIO.OBSERVACIONES = Obs.Text;


              
                    negocio.ModificarDatosClienteConSP(NuevoCliente);
                    Response.Redirect("DatosClienteCargados.aspx?id=" + id, false);


                }


                else //agrego nuevo cliente

                {

                    NuevoCliente.IDCLIENTE = int.Parse(id);
                    NuevoCliente.NOMBRES = Nombre.Text;
                    NuevoCliente.APELLIDOS = Apellido.Text;
                    NuevoCliente.DNI = int.Parse(DNI.Text);
                    NuevoCliente.TELEFONO_1 = Telefono1.Text;
                    NuevoCliente.TELEFONO_2 = Telefono2.Text;
                    NuevoCliente.FECHA_NACIMIENTO = DateTime.Parse(FechaNac.Text);

                    NuevoCliente.DOMICILIO = new Domicilio();
                    NuevoCliente.DOMICILIO.IDDOMICILIO = int.Parse(id);
                    NuevoCliente.DOMICILIO.CALLE = Calle.Text;
                    NuevoCliente.DOMICILIO.NUMERO = int.Parse(Numero.Text);
                    NuevoCliente.DOMICILIO.ENTRECALLES = EntreCalles.Text;
                    NuevoCliente.DOMICILIO.CODIGO_POSTAL = int.Parse(CodigoPostal.Text);
                    NuevoCliente.DOMICILIO.PROVINCIA = Provincia.Text;
                    NuevoCliente.DOMICILIO.PARTIDO = Partido.Text;
                    NuevoCliente.DOMICILIO.LOCALIDAD = Localidad.Text;
                    NuevoCliente.DOMICILIO.NUMERO_DEPTO = NroDepto.Text;
                    NuevoCliente.DOMICILIO.PISO = Piso.Text;
                    NuevoCliente.DOMICILIO.OBSERVACIONES = Obs.Text;

                    negocio.AgregarDatosClienteConSP(NuevoCliente); //aca agrego el nuevo pokemon en la DB
                    Response.Redirect("DatosClienteCargados.aspx?id=" + id, false);
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error0.aspx",false);
            }
        }

        protected void btneteHacerPedido_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormaDeEnvioPagoFactura.aspx", false);
        }
    }

}
