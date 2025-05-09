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
        string codigo;
        int idArticulo=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                
                codigo = Request.QueryString["codigo"];
                ViewState["codigo"] = codigo;

                VoucherNegocio voucher = new VoucherNegocio();

                if ((codigo == null) || (voucher.verificarVoucher(codigo) != "Código válido"))
                {
                    Response.Redirect("/.");
                }
                idArticulo = int.Parse(Request.QueryString["Id"]);
            }
            else
            {
                codigo = ViewState["codigo"]?.ToString();
                idArticulo = (int)ViewState["idArticulo"];
            }
            
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