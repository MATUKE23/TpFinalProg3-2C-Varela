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
                comando.CommandText = "select Cl.IdCliente, Cl.Nombres, CL.Apellidos, Cl.DNI, Cl.Telefono_1, Cl.Telefono_2, CL.Fecha_Nacimiento, CL.Estado, Do.Calle, Do.Numero, Do.ENTRE_CALLES, Do.CODIGO_POSTAL, Do.PROVINCIA, Do.PARTIDO, Do.LOCALIDAD, Do.NUMERO_DEPTO, Do.PISO, Do.OBSERVACIONES from Clientes as Cl, DOMICILIOS as Do, Usuarios1 as U where Cl.idcliente = U.IDUSUARIO and Do.IDDOMICILIO = U.IDUSUARIO";
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
                    aux.DOMICILIO.NUMERO = (int)lector["Numero"];
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

        public void AgregarDatosClienteConSP(Cliente NuevoCliente)// insert
        {
            AccesoaDatos datos = new AccesoaDatos();

            try
            {
                /*
                   @NOMBRES nvarchar(max),
                   @APELLIDOS nvarchar(max),
                   @DNI int,
                   @TELEFONO_1 nvarchar(22),
                   @TELEFONO_2 nvarchar(22),
                   @FECHA_NACIMIENTO date,
                   @ESTADO BIT,
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


                datos.setearSP("AgregarDatosClienteConSP");
                datos.setearParametro("@NOMBRES", NuevoCliente.NOMBRES);
                datos.setearParametro("@APELLIDOS", NuevoCliente.APELLIDOS);
                datos.setearParametro("@DNI", NuevoCliente.DNI);
                datos.setearParametro("@TELEFONO_1", NuevoCliente.TELEFONO_1);
                datos.setearParametro("@TELEFONO_2", NuevoCliente.TELEFONO_2);
                datos.setearParametro("@FECHA_NACIMIENTO", NuevoCliente.FECHA_NACIMIENTO);
                datos.setearParametro("@IDCLIENTE", NuevoCliente.DOMICILIO.IDDOMICILIO); //es el mismo ID
                //datos.setearParametro("@ESTADO", NuevoCliente.ESTADO);
                datos.setearParametro("@CALLE", NuevoCliente.DOMICILIO.CALLE);
                datos.setearParametro("@NUMERO", NuevoCliente.DOMICILIO.NUMERO);
                datos.setearParametro("@ENTRE_CALLES", NuevoCliente.DOMICILIO.ENTRECALLES);
                datos.setearParametro("@CODIGO_POSTAL", NuevoCliente.DOMICILIO.CODIGO_POSTAL);
                datos.setearParametro("@PROVINCIA", NuevoCliente.DOMICILIO.PROVINCIA);
                datos.setearParametro("@PARTIDO", NuevoCliente.DOMICILIO.PARTIDO);
                datos.setearParametro("@LOCALIDAD", NuevoCliente.DOMICILIO.LOCALIDAD);
                datos.setearParametro("@NUMERO_DEPTO", NuevoCliente.DOMICILIO.NUMERO_DEPTO);
                datos.setearParametro("@PISO", NuevoCliente.DOMICILIO.PISO);
                datos.setearParametro("@OBSERVACIONES", NuevoCliente.DOMICILIO.OBSERVACIONES);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public void ModificarDatosClienteConSP(Cliente NuevoCliente)// insert
        {
            AccesoaDatos datos = new AccesoaDatos();

            try
            {
                /*
                   @NOMBRES nvarchar(max),
                   @APELLIDOS nvarchar(max),
                   @DNI int,
                   @TELEFONO_1 nvarchar(22),
                   @TELEFONO_2 nvarchar(22),
                   @FECHA_NACIMIENTO date,
                   @ESTADO BIT,
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


                datos.setearSP("ModificarDatosClienteConSP");
                datos.setearParametro("@IDCLIENTE", NuevoCliente.IDCLIENTE);
                datos.setearParametro("@NOMBRES", NuevoCliente.NOMBRES);
                datos.setearParametro("@DNI", NuevoCliente.DNI);
                datos.setearParametro("@APELLIDOS", NuevoCliente.APELLIDOS);
                datos.setearParametro("@TELEFONO_1", NuevoCliente.TELEFONO_1);
                datos.setearParametro("@TELEFONO_2", NuevoCliente.TELEFONO_2);
                datos.setearParametro("@FECHA_NACIMIENTO", NuevoCliente.FECHA_NACIMIENTO);
                
                datos.setearParametro("@IDDOMICILIO", NuevoCliente.DOMICILIO.IDDOMICILIO); //es el mismo ID
                datos.setearParametro("@CALLE", NuevoCliente.DOMICILIO.CALLE);
                datos.setearParametro("@NUMERO", NuevoCliente.DOMICILIO.NUMERO);
                datos.setearParametro("@ENTRE_CALLES", NuevoCliente.DOMICILIO.ENTRECALLES);
                datos.setearParametro("@CODIGO_POSTAL", NuevoCliente.DOMICILIO.CODIGO_POSTAL);
                datos.setearParametro("@PROVINCIA", NuevoCliente.DOMICILIO.PROVINCIA);
                datos.setearParametro("@PARTIDO", NuevoCliente.DOMICILIO.PARTIDO);
                datos.setearParametro("@LOCALIDAD", NuevoCliente.DOMICILIO.LOCALIDAD);
                datos.setearParametro("@NUMERO_DEPTO", NuevoCliente.DOMICILIO.NUMERO_DEPTO);
                datos.setearParametro("@PISO", NuevoCliente.DOMICILIO.PISO);
                datos.setearParametro("@OBSERVACIONES", NuevoCliente.DOMICILIO.OBSERVACIONES);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }


    }
}


