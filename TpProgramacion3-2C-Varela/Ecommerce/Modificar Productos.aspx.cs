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
               if (!IsPostBack) //Evita recarga 
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    List<Articulo> lista = negocio.listar();

                    ddlDescCategoria.DataSource = lista; //Desplegable de tipo
                    ddlDescCategoria.DataValueField = "ID"; // este valor oculto es el value que despues vamos a capturar de la seleccion de los elemantos. Uso selected Value
                    ddlDescCategoria.DataTextField = "DESCRIPCION";//es el valor quq quiero que muestre
                    ddlDescCategoria.DataBind();

                }
               

                //configuración si estamos modificando.
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    
                    ArticuloNegocio negocio = new ArticuloNegocio();
                   Articulo seleccionado = (negocio.listar(id))[0];

                    //guardo pokemon seleccionado en session
                    Session.Add("ArtSeleccionado", seleccionado);

                    //pre cargar todos los campos...
                    txtId.Text = id;
                    txtCodigo.Text = seleccionado.CODIGO;
                    txtDesc.Text = seleccionado.DESCRIPCION;
                    txtDescAD.Text = seleccionado.DESCRIPCION_AD;
                    txtImagenUrl.Text = seleccionado.URLIMAGEN;
                    txtObs.Text = seleccionado.OBS;
                    CheckboxEstado.Text = seleccionado.ESTADO.ToString();
                    txtPrecio.Text = seleccionado.PRECIO.ToString();
                    
                    ddlDescCategoria.SelectedValue = seleccionado.CATEGORIA.ToString();
                    txtImagenUrl_TextChanged(sender, e);

                    //configurar acciones
                    //if (!seleccionado.Activo)
                     //   btnInactivar.Text = "Reactivar";
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


                nuevo.CODIGO = txtCodigo.Text;
                nuevo.DESCRIPCION = txtDesc.Text;
                nuevo.DESCRIPCION_AD = txtDescAD.Text;
                nuevo.OBS = txtObs.Text;
                nuevo.ESTADO = CheckboxEstado.Checked;
                nuevo.PRECIO = int.Parse(txtPrecio.Text);
                nuevo.URLIMAGEN = txtImagenUrl.Text;

                if (Request.QueryString["ID"] != null)
                {
                    nuevo.ID = int.Parse(txtId.Text);
                    negocio.ModificarArticuloconSP(nuevo);
                }

                else 
                negocio.AgregarProductoConSP(nuevo); //aca agrego el nuevo pokemon en la DB
                
                //nuevo.ESTADO = bool.Parse(CheckboxEstado.Checked);
                //nuevo.ID_CATEGORIA = new Categoria();
                //nuevo.ID_CATEGORIA.ID = int.Parse(ddlCategoria.SelectedValue);


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