using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
