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
        public List<Cliente> ListarCliente(string id)
        {
            List<Cliente> lista = new List<Cliente>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select Cl.IdCliente, Cl.Nombres, CL.Apellidos, Cl.DNI, Cl.Telefono_1, Cl.Telefono_2, CL.Fecha_Nacimiento, CL.Estado, Do.Calle, Do.ENTRE_CALLES, Do.CODIGO_POSTAL, Do.PROVINCIA, Do.PARTIDO, Do.LOCALIDAD, Do.NUMERO_DEPTO, Do.PISO, Do.OBSERVACIONES from Clientes as Cl, DOMICILIOS as Do, Usuarios1 as U where Cl.idcliente = U.IDUSUARIO and Do.IDDOMICILIO = U.IDUSUARIO";
                //comando.CommandText = "select Cl.IdCliente, Cl.Nombres, CL.Apellidos, Cl.DNI, Cl.Telefono_1, Cl.Telefono_2, CL.Fecha_Nacimiento, CL.Estado from Clientes as Cl, Usuarios1 as U where Cl.idcliente = U.IDUSUARIO";
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
                    aux.FECHA_NACIMIENTO = (DateTime)lector["Fecha_Nacimiento"];
                    aux.DOMICILIO = new Domicilio();
                    aux.DOMICILIO.CALLE = (string)lector["Calle"];
                    aux.DOMICILIO.ENTRECALLES = (string)lector["Entre_Calles"];
                    aux.DOMICILIO.CODIGO_POSTAL = (int)lector["Codigo_Postal"];
                    aux.DOMICILIO.PROVINCIA = (string)lector["Provincia"];
                    aux.DOMICILIO.PARTIDO = (string)lector["PArtido"];
                    aux.DOMICILIO.LOCALIDAD = (string)lector["Localidad"];
                    aux.DOMICILIO.NUMERO_DEPTO = (string)lector["numero_depto"];
                    aux.DOMICILIO.PISO = (string)lector["PISO"];
                    aux.DOMICILIO.OBSERVACIONES = (string)lector["Observaciones"];
                    aux.ESTADO = (bool)lector["ESTADO"];
                    //aux.FECHA_NACIMIENTO = (string)lector["Fecha_Nacimiento"];// si paso a tipo de dato fecha, primero hacerlo en la propiedad de la  clase cliente.
                    //aux.FECHA_NACIMIENTO = DateTime.Parselector["Fecha_Nacimiento"];// si paso a tipo de dato fecha, primero hacerlo en la propiedad de la  clase cliente.


                    lista.Add(aux);

                }

                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        } // 1



        public int ValidaDatosClienteCompletos(string id)
        {

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select count(IDDOMICILIO) as 'Acum' from Clientes as Cl, DOMICILIOS as Do, Usuarios1 as U where Cl.idcliente = U.IDUSUARIO and Do.IDDOMICILIO = U.IDUSUARIO and Cl.Nombres is not null and Cl.Apellidos is not null and Cl.DNI is not null and Cl.Telefono_1 is not null and cl.Fecha_Nacimiento is not null and Do.CALLE is not null and Do.ENTRE_CALLES is not null and Do.CODIGO_POSTAL is not null and Do.PROVINCIA is not null and Do.PARTIDO is not null and Do.LOCALIDAD is not null ";
                comando.CommandText += " and U.IDUSUARIO = " + id;
                comando.CommandText += "group by IDDOMICILIO";
                comando.Connection = conexion;

                int validador = 0;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    validador = (int)lector["Acum"];

                }

                conexion.Close();
                return validador;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

    }
}


