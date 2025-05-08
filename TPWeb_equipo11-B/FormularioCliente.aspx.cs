using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPWeb_equipo11_B
{
    public partial class FormularioCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int idArticulo = int.Parse(Request.QueryString["Id"]);
        }

        protected void AgregarCliente(object sender, EventArgs e)
        {   
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            Cliente cliente = new Cliente();
            cliente.Dni = int.Parse(dni.Text);
            cliente.Nombre = nombre.Text;   
            cliente.Apellido = apellido.Text;   
            cliente.Email = email.Text;
            cliente.Direccion = direccion.Text; 
            cliente.Ciudad = ciudad.Text;
            cliente.CodPostal = int.Parse(cp.Text);

            clienteNegocio.agregarCliente(cliente);
            Response.Redirect("VistaExito.aspx");
        }
    }
}