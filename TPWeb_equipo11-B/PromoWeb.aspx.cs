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
            string validarCodigo = negocio.verificarVoucher(codigoPromo.Text);
            switch (validarCodigo)
            {
                case("Código válido"):
                    lblPromo.Text = "Felicidades, tu código es válido!";
                    btnPremio.Visible = true;
                    btnPromo.Visible = false;
                    break;
                case ("Código ya usado"):
                    lblPromo.Text = "Lo sentimos! Tu código ya ha sido usado";
                    btnPromo.Visible = false;
                    btnInicio.Visible = true;
                    break;
                case ("Código inválido"):
                    lblPromo.Text = "Lo sentimos! Tu código no es valido";
                    btnPromo.Visible = false;
                    btnInicio.Visible = true;
                    break;

            }
            codigoPromo.Text = validarCodigo;
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("/.");
        }

        protected void btnPremio_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Premios.aspx");
        }
    }
}