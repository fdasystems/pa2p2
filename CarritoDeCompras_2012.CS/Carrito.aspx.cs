using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCS;

namespace CarritoDeCompras_2012.CS
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarGrillaDeCookies();
        }

        public void CargarGrillaDeCookies()
        {


            Parseador ParsearCookie = new Parseador();

            //NameValueCollection valores =  Request.Cookies["CarritoDeCompras"].Values;
            string Cookie = HttpUtility.UrlDecode(Request.Cookies["CarritoDeCompras"].Values.ToString());
            List<CarritoItem> ListCarrito = new List<CarritoItem>();

            ListCarrito = ParsearCookie.ParsearCookieYGenerar(Cookie);



            GridView1.DataSource = ListCarrito;
            GridView1.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CargarGrillaDeCookies();
        }
    }
}
