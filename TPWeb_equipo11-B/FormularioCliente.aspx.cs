using dominio;
using Microsoft.Ajax.Utilities;
using negocio;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
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
        Cliente cliente;    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                codigo = Request.QueryString["codigo"];
                ViewState["codigo"] = codigo;

                VoucherNegocio voucher = new VoucherNegocio();

                if ((codigo == null) || (voucher.verificarVoucher(codigo) != "Código válido") || (Session["Id"] == null))
                {
                    Response.Redirect("/.");
                }
                
                idArticulo =int.Parse( Session["Id"].ToString());                   
                

            }
            else
            {
                codigo = ViewState["codigo"]?.ToString();
               
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
        {   VoucherNegocio voucherNegocio = new VoucherNegocio();
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            Voucher voucher = new Voucher();
            EmailService emailService = new EmailService();
           
           
            bool nuevoCliente = false;
            int idCliente = int.Parse(Session["idCliente"].ToString());

            idArticulo = int.Parse(Session["Id"].ToString());
            try
            {
               
                if (idCliente!=0)
                {
                    if(checkTerminos.Checked)
                    {   
                        voucher.CodigoVoucher = codigo;
                        voucherNegocio.asignarVoucher(voucher,idCliente,idArticulo);
                        Session.Add("codigo", voucher.CodigoVoucher);
                        Response.Redirect("VistaExito.aspx",false);
                    }
                    else
                    {
                        lblAceptaTermYCond.Visible = true;
                        return;
                    }
                   
                }
                else
                {

                    if(Validacion.validaTextoVacio(nombre) ||
                        Validacion.validaTextoVacio(apellido) ||
                        Validacion.validaTextoVacio(email) ||
                        Validacion.validaTextoVacio(direccion) ||
                        Validacion.validaTextoVacio(ciudad) ||
                        Validacion.validaTextoVacio(cp) ||
                        checkTerminos.Checked == false)

                    {
                        LblError.Visible = true;
                        LblError.Text = "Se deben completar todos los campos";
                        LblError.CssClass = "text-danger";
                        return;
                    }


                    cliente = new Cliente();
                    cliente.Dni = dni.Text;
                    cliente.Nombre = nombre.Text;
                    cliente.Apellido = apellido.Text;
                    cliente.Email = email.Text;
                    cliente.Direccion = direccion.Text;
                    cliente.Ciudad = ciudad.Text;
                    cliente.CodPostal = int.Parse(cp.Text);
                    AgregarCliente(cliente);
                    nuevoCliente = true;
                    emailService.armarCorreo(cliente.Email, "Registro", "<h1>Confirmacion de registro de nuevo cliente.</h1>" + "  <br> Hola! " + cliente.Nombre+ " " + cliente.Apellido+ " ha sido registrado exitosamente.</br>");
                    emailService.enviarEmail();
                }

                if (nuevoCliente)
                {
                    cliente =  clienteNegocio.GetClienteByDni(cliente.Dni);

                    
                    voucher.CodigoVoucher = codigo;
                    voucherNegocio.asignarVoucher(voucher, cliente.Id, idArticulo);
                    emailService.armarCorreo(cliente.Email, "Sorteo", "<h1>Confirmacion.</h1>" + "  <br> Hola! " + cliente.Nombre + " " + cliente.Apellido + " ha sido inscripto en el sorteo exitosamente.</br>");
                    emailService.enviarEmail();
                    Session.Add("codigo", voucher.CodigoVoucher);
                    Response.Redirect("VistaExito.aspx", false);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            
          

            
            
        }

        

        protected void dni_TextChanged(object sender, EventArgs e)
        {
            
            string numDNI = dni.Text.Trim();
            ClienteNegocio clienteNegocio = new ClienteNegocio();

            if (!Validacion.validaNumeros(dni))
            {
                lblCliente.Text = "El número de DNI es incorrecto, intentalo nuevamente.\nDebe tener 8 caracteres y solamente números. Ejemplo: 33789555 ó 01233565";
                lblCliente.CssClass = "text-danger";
                DesabilitarFormulario();
                verFormulario = false;
                return;
            }
            else
            {
                lblCliente.Text = "";
                dni.Text = numDNI;
            }


                try
                {
                    cliente = clienteNegocio.GetClienteByDni(numDNI);

                    if (Validacion.validaTextoVacio(dni))
                    {
                        DesabilitarFormulario();
                        btnAgregar.Enabled = false;
                        checkTerminos.Enabled = false;
                        return;
                    }


                    if (cliente.Dni != null)
                    {
                        estaRegistrado = true;
                        lblCliente.Text = "Ya te encuentras registrado en la WEB, puedes participar del sorteo.";
                        AutocompletarFormulario(cliente);
                        DesabilitarFormulario();
                        Session.Add("idCliente", cliente.Id);
                    }
                    else
                    {
                        int idCliente = 0;
                        Session.Add("idCliente", idCliente);
                        estaRegistrado = false;
                        lblCliente.Text = "El número de DNI no se encuentra registrado, por favor complete el formulario para registrarte.";
                        HabilitarFormulario();
                        LimpiarInputs();
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
            //dni.Text = "";
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