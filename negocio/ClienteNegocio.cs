using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace negocio
{
    public class ClienteNegocio
    {
        //metodo para agregar un cliente a nuestra DB
        public void agregarCliente(Cliente cliente) { 
         AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setConsulta("INSERT INTO Clientes (Documento,Nombre,Apellido,Email,Direccion,Ciudad,CP)\r\n  " +
                                        "VALUES\r\n  " +
                                        "(@dni,@nombre,@apellido,@email,@direccion,@ciudad,@cp)");
                accesoDatos.setParametro("@dni",cliente.Dni);
                accesoDatos.setParametro("@nombre",cliente.Nombre);
                accesoDatos.setParametro("@apellido",cliente.Apellido);
                accesoDatos.setParametro("@email",cliente.Email);
                accesoDatos.setParametro("@direccion",cliente.Direccion);
                accesoDatos.setParametro("@ciudad",cliente.Ciudad);
                accesoDatos.setParametro("@cp",cliente.CodPostal);

                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }
        public List<Cliente> getClientes()
        {
            AccesoDatos accesoDatos= new AccesoDatos();
            List<Cliente> clientes = new List<Cliente> ();
            try
            {
                accesoDatos.setConsulta("SELECT Id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP FROM Clientes");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Cliente cliente = new Cliente ();
                    cliente.Id =(int) accesoDatos.Lector["Id"];
                    cliente.Dni = (int)accesoDatos.Lector["Documento"];
                    cliente.Nombre =(string) accesoDatos.Lector["Nombre"];
                    cliente.Apellido = (string)accesoDatos.Lector["Apellido"];
                    cliente.Email = (string)accesoDatos.Lector["Email"];
                    cliente.Direccion = (string)accesoDatos.Lector["Direccion"];
                    cliente.Ciudad = (string)accesoDatos.Lector["Ciudad"];
                    cliente.CodPostal = (int)accesoDatos.Lector["CP"];

                    clientes.Add(cliente);
                }
                return clientes;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }
    }
}
