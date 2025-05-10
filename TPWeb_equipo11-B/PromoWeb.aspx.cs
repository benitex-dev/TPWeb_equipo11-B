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
    public partial class PromoWeb1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
        protected void btnPromo_Click(object sender, EventArgs e)
        {
            VoucherNegocio negocio = new VoucherNegocio();
            string codigo = codigoPromo.Text;
            string validarCodigo = negocio.verificarVoucher(codigo);

            switch (validarCodigo)
            {
                case("Código válido"):
                    lblPromo.Text = "Felicidades, tu código es válido!";
                    lblPromo.CssClass = " alert alert-success" ;
                    btnPremio.Visible = true;
                    btnPromo.Visible = false;
                    codigoPromo.Visible = false;
                    break;
                case ("Código ya usado"):
                    lblPromo.Text = "Lo sentimos! Tu código ya ha sido usado";
                    lblPromo.CssClass = " alert alert-danger";
                    btnPromo.Visible = false;
                    btnInicio.Visible = true;
                    codigoPromo.Visible = false;
                    break;
                case ("Código inválido"):
                    lblPromo.Text = "Lo sentimos! Tu código no es valido";
                    lblPromo.CssClass = " alert alert-danger";
                    btnPromo.Visible = false;
                    btnInicio.Visible = true;
                    codigoPromo.Visible = false;
                    break;

            }
            
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("/.", false);
        }

        protected void btnPremio_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Premios.aspx?codigo="+ codigoPromo.Text, false);
        }
    }
}