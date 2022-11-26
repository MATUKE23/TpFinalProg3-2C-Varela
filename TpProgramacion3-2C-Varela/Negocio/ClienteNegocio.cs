using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> ListarCliente(int id)
        {
            List<Cliente> lista = new List<Cliente>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                
                comando.CommandText = "select Cl.IdCliente, Cl.Nombres, CL.Apellidos, Cl.DNI, Cl.Telefono_1, Cl.Telefono_2, CL.Fecha_Nacimiento, CL.Estado from Clientes as Cl, Usuarios1 as U where Cl.idcliente = U.IDUSUARIO";
                //if (id != null)
                    comando.CommandText += " and U.IDUSUARIO = " + id;
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.IDCLIENTE = (int)lector["IdCliente"];
                    aux.NOMBRES = (string)lector["Nombres"];
                    aux.APELLIDOS = (string)lector["Apellidos"];
                    aux.DNI = (int)lector["DNI"];
                    aux.TELEFONO_1 = (string)lector["Telefono_1"];
                    aux.TELEFONO_2 = (string)lector["Telefono_2"];
                    aux.FECHA_NACIMIENTO = (string)lector["Fecha_Nacimiento"];// si paso a tipo de dato fecha, primero hacerlo en la propiedad de la  clase cliente.
                    


                    /*Articulo aux = new Articulo();
                    aux.ID = (int)lector["ID"];
                    aux.CODIGO = (string)lector["CODIGO"]; //entre comillas es el el nombre que tiene en la base
                    aux.DESCRIPCION = (string)lector["DART"];
                    aux.DESCRIPCION_AD = (string)lector["DART_AD"];
                    aux.PRECIO = decimal.Parse(lector["PRECIO"].ToString());
                    aux.TIPO = (string)lector["TIPO"];
                    aux.OBS = (string)lector["OBS"];
                    aux.ESTADO = (bool)lector["ESTADO"];

                    aux.CATEG = new Categoria();
                    aux.CATEG.ID = (int)lector["IDCATEGORIA"];
                    aux.CATEG.DESCRIPCION = (string)lector["DESC_CAT"];
                    aux.URLIMAGEN = (string)lector["URLIMAGEN"];
                    */

                    lista.Add(aux);

                }

                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

    }
}


