using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using System.Xml.Linq;

namespace Ecommerce
{
    public partial class Modificar_Productos : System.Web.UI.Page
    {

        public bool ConfirmaEliminacion { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            ConfirmaEliminacion = false;
            try
            {
                //configuración inicial de la pantalla.
               /* if (!IsPostBack) //Evita recarga 
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    List<Articulo> lista = negocio.listar();

                    ddlCategoria.DataSource = lista; //Desplegable de tipo
                    ddlCategoria.DataValueField = "Id"; // este valor oculto es el value que despues vamos a capturar de la seleccion de los elemantos. Uso selected Value
                    ddlCategoria.DataTextField = "Descripcion";//es el valor quq quiero que muestre
                    ddlCategoria.DataBind();



                }
               */

                //configuración si estamos modificando.
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    /*
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    //List<Pokemon> lista = negocio.listar(id);
                    //Pokemon seleccionado = lista[0];
                   Articulo seleccionado = negocio.listar(id);

                    //guardo pokemon seleccionado en session
                    Session.Add("ArtSeleccionado", seleccionado);

                    //pre cargar todos los campos...
                    txtId.Text = id;
                    txtDesc. = seleccionado.;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtImagenUrl.Text = seleccionado.UrlImagen;
                    txtNumero.Text = seleccionado.Numero.ToString();

                    ddlTipo.SelectedValue = seleccionado.Tipo.Id.ToString();
                    ddlDebilidad.SelectedValue = seleccionado.Debilidad.Id.ToString();
                    txtImagenUrl_TextChanged(sender, e);

                    //configurar acciones
                    if (!seleccionado.Activo)
                        btnInactivar.Text = "Reactivar";*/
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex); //guarda el error en sesion y te lo muestra en otra pantalle de error
                Response.Redirect("Error0.aspx"); // si no tengo la pantalla de error tengo que poner "throw;"
            }



        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo nuevo = new Articulo();  // lo instancio para poder llamar al metodo agregarConSP 
                ArticuloNegocio negocio = new ArticuloNegocio();//aca cargamos los datos del nuevo art 


                /*
                @code varchar(10),
                @desc varchar(50),
                @descAD varchar(1000),
                @precio float,
                @tipo varchar(3), dummy
                @Obs varchar(200),
                @estado bit,
                @IdCat int,    dummy
                @URLimagen varchar(400)
                */

                nuevo.CODIGO = TextCodigoArt.Text;
                nuevo.DESCRIPCION = TextDescAdicional.Text;
                nuevo.DESCRIPCION_AD = txtDescripcion.Text;
                nuevo.PRECIO = int.Parse(txtPrecio.Text);
                nuevo.OBS = txtObs.Text;
                //nuevo.ESTADO = bool.Parse(CheckboxEstado.Checked);
                nuevo.URLIMAGEN = txtImagenUrl.Text;
                
                //nuevo.ID_CATEGORIA = new Categoria();
                //nuevo.ID_CATEGORIA.ID = int.Parse(ddlCategoria.SelectedValue);

                negocio.AgregarProductoConSP(nuevo); //aca agrego el nuevo pokemon en la DB

                Response.Redirect("ProductosListaEdit.aspx", false);// me lleva a la pantalla del listado

            }
            catch (Exception ex)
            {
                Response.Redirect("Error0.aspx");
            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;

        }


    }
}