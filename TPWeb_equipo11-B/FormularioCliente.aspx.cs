using dominio;
using Microsoft.Ajax.Utilities;
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
        int idArticulo = 0;
        public bool verFormulario;
        public bool estaRegistrado {  get; set; }
        public Cliente cliente;
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
                ViewState["Id"] = idArticulo;
            }
            else
            {
                codigo = ViewState["codigo"]?.ToString();
                idArticulo = Convert.ToInt32(ViewState["Id"]);
            }


            if (!IsPostBack)
                verFormulario = false;
            else
                verFormulario = true;

           

           
        }
         
            

        

        public void AgregarCliente(Cliente cliente)
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            clienteNegocio.agregarCliente(cliente);
        }
        protected void OnClick(object sender, EventArgs e)
        {
            try
            {
                if (!estaRegistrado)
                {

                    cliente.Dni = dni.Text;
                    cliente.Nombre = nombre.Text;
                    cliente.Apellido = apellido.Text;
                    cliente.Email = email.Text;
                    cliente.Direccion = direccion.Text;
                    cliente.Ciudad = ciudad.Text;
                    cliente.CodPostal = int.Parse(cp.Text);
                    AgregarCliente(cliente);
                }
            }
            catch (Exception)
            {

                throw;
            }
            
            
          

            
            Response.Redirect("VistaExito.aspx");
        }

        public Cliente GetClienteByDni(string dni)
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            try
            {
                cliente = clienteNegocio.GetClienteByDni(dni);
                if (cliente.Id == 0)
                {
                    cliente = null;
                }
                return cliente;
            }
            catch (Exception)
            {

                throw;
            }
           
           
        }

        protected void dni_TextChanged(object sender, EventArgs e)
        {
            
            string numDNI = dni.Text.Trim();
            cliente = GetClienteByDni(numDNI);
            
            try
            {
                
                if (Validacion.validaTextoVacio(dni))
                {
                    DesabilitarFormulario();
                    btnAgregar.Enabled = false;
                    checkTerminos.Enabled = false;
                    return;
                }
                
                
                if (cliente!=null)
                {
                    estaRegistrado = true;
                    lblCliente.Text = "Ya te encuentras registrado en la WEB, puedes participar del sorteo.";
                    AutocompletarFormulario(cliente);
                    DesabilitarFormulario();
                }
                else
                {
                    estaRegistrado = false;
                    lblCliente.Text = "El número de DNI no se encuentra registrado, por favor complete el formulario para registrarte.";
                }

               
                
            }
            catch (Exception ex)
            {

                throw ex;
            }  

            

            
        }

        

        public void AutocompletarFormulario(Cliente cliente)
        {
            dni.Text = cliente.Dni.ToString();
            email.Text = cliente.Email.ToString();
            nombre.Text = cliente.Nombre.ToString();
            apellido.Text = cliente.Apellido.ToString();
            direccion.Text = cliente.Direccion.ToString();
            ciudad.Text = cliente.Ciudad.ToString();
            cp.Text = cliente.CodPostal.ToString();  
        }
        public void LimpiarInputs()
        {
            dni.Text = "";
            email.Text = "";
            nombre.Text = "";
            apellido.Text = "";
            direccion.Text = "";
            ciudad.Text = "";
            cp.Text = "".ToString();
        }
        public void DesabilitarFormulario()
        {
            
            email.Enabled = false;
            nombre.Enabled = false;
            apellido.Enabled = false;
            direccion.Enabled = false;
            ciudad.Enabled = false;
            cp.Enabled = false;
           
        }
        public void HabilitarFormulario()
        {

            email.Enabled = true;
            nombre.Enabled = true;
            apellido.Enabled = true;
            direccion.Enabled = true;
            ciudad.Enabled = true;
            cp.Enabled = true;
            checkTerminos.Enabled = true;
        }

        protected void checkTerminos_CheckedChanged(object sender, EventArgs e)
        {
            if(checkTerminos.Checked == true)
            {
                btnAgregar.Enabled = true;
            }
            else
            {
                btnAgregar.Enabled = false;
            }
        }
    }
}