using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TPWeb_equipo11_B
{
    public partial class Premios : System.Web.UI.Page
    {
        string codigo;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                codigo = Request.QueryString["codigo"];
                ViewState["codigo"] = codigo;

                VoucherNegocio voucher = new VoucherNegocio();

                if ((codigo == null) && (voucher.verificarVoucher(codigo) != "Código válido"))
                {
                    Response.Redirect("/.");
                }

                CargarPremios();
            }
            else
            {
                codigo = ViewState["codigo"]?.ToString();
            }
        }
        private void CargarPremios()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            List<Articulo> listaArticulos = negocio.listar();
            repRepetidor.DataSource = listaArticulos;
            repRepetidor.DataBind();

        }

        string idArticulo;
        protected void repRepetidor_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "eleccion")
            {
                Session["Id"] = e.CommandArgument.ToString();                

                Response.Redirect("FormularioCliente.aspx?codigo=" + codigo, false);
            }

        }


    }
}