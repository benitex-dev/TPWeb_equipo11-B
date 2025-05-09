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
        public bool estaRegistrado { get; set; }
        public Cliente cliente;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(dni.Text.ToString()=="")
                DesabilitarInputs();
            

            if (cliente != null || dni.Text.IsNullOrWhiteSpace())
            {
                DesabilitarInputs();
                checkTerminos.Enabled = true;
                checkTerminos.Checked = false;
            }
               
            
            

        }

        public void AgregarCliente(Cliente cliente)
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            clienteNegocio.agregarCliente(cliente);
        }
        protected void OnClick(object sender, EventArgs e)
        {
            
            if (!estaRegistrado)
            {
                
                cliente.Dni = int.Parse(dni.Text);
                cliente.Nombre = nombre.Text;
                cliente.Apellido = apellido.Text;
                cliente.Email = email.Text;
                cliente.Direccion = direccion.Text;
                cliente.Ciudad = ciudad.Text;
                cliente.CodPostal = int.Parse(cp.Text);
                AgregarCliente(cliente);
            }
          

            
            Response.Redirect("VistaExito.aspx");
        }

        protected void BuscarCliente(object sender, EventArgs e)
        {
            //ClienteNegocio clienteNegocio = new ClienteNegocio();
            //Cliente cliente = new Cliente();
            
            //cliente=clienteNegocio.GetClienteByDni(int.Parse( dni.Text));
            //if (cliente.Id == 0)
            //    lblCliente.Text = "El número de DNI no se encuentra registrado, por favor complete el formulario para participar.";
            //else
            //lblCliente.Text = cliente.Email.ToString();
        }

        public Cliente GetCliente(int dni)
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            cliente = clienteNegocio.GetClienteByDni(dni);
            if (cliente.Id == 0)
            {
                cliente = null;
            }
            return cliente;
        }

        protected void dni_TextChanged(object sender, EventArgs e)
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();

            try
            {
                if (Validacion.validaTextoVacio(dni))
                {
                    lblCliente.Text = "por favor ingrese un dni";
                    Session.Add("error", "Debes ingresar tu dni");
                }
                cliente = GetCliente(int.Parse(dni.Text));
                if (cliente== null)
                {
                    lblCliente.Text = "El número de DNI no se encuentra registrado, por favor complete el formulario para participar.";
                    dni.Text = dni.Text.ToString();
                    email.Text = "";
                    nombre.Text = "";
                    apellido.Text = "";
                    direccion.Text = "";
                    ciudad.Text = "";
                    cp.Text = "".ToString();
                    HabilitarControles();
                    estaRegistrado = false;
                }
                else
                {

                    dni.Text = cliente.Dni.ToString();
                    email.Text = cliente.Email.ToString();
                    nombre.Text = cliente.Nombre.ToString();
                    apellido.Text = cliente.Apellido.ToString();
                    direccion.Text = cliente.Direccion.ToString();
                    ciudad.Text = cliente.Ciudad.ToString();
                    cp.Text = cliente.CodPostal.ToString();
                    estaRegistrado = true;
                    DesabilitarInputs();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }  

            

            
        }
        public void DesabilitarInputs()
        {
            
            email.Enabled = false;
            nombre.Enabled = false;
            apellido.Enabled = false;
            direccion.Enabled = false;
            ciudad.Enabled = false;
            cp.Enabled = false;
        }
        public void HabilitarControles()
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