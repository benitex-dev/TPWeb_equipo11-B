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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string codigo = Request.QueryString["codigo"];
                CargarPremios();
            }
        }

        private void CargarPremios()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            List<Articulo> listaArticulos = negocio.listar();
            repRepetidor.DataSource = listaArticulos;
            repRepetidor.DataBind();

        }


        protected void repRepetidor_ItemCommand1(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "eleccion")
            {
                int idArticulo = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("FormularioCliente.aspx?Id=" + idArticulo);
            }

        }


    }
}