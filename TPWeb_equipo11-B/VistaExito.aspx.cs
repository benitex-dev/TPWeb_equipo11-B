using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPWeb_equipo11_B
{
    public partial class VistaExito : System.Web.UI.Page
    {
        int idCliente;
        int idArticulo;
        string codigo;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                if(Session["idCliente"] == null )
                {
                    idCliente = 0;
                }
                else
                {
                    idCliente = int.Parse(Session["idCliente"].ToString());
                }


                if (Session["idArticulo"] == null )
                {
                    idArticulo = 0;
                }
                else
                {
                    idArticulo = int.Parse(Session["idArticulo"].ToString());
                }
                
                if(Session["codigo"] == null)
                {
                    codigo = "";
                }
                else
                {
                    codigo = Session["codigo"].ToString();
                }

               
                if(idCliente == 0 || idArticulo==0||string.IsNullOrEmpty(codigo)) 
                { Response.Redirect("/.", false); }
            }
        }
    }
}