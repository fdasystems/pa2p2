using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCS;

using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


namespace CarritoDeCompras_2012.CS
{
    public partial class Compras : System.Web.UI.Page
    {
        Parseador ParsearCookie = new Parseador();
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnComprar_Click(object sender, EventArgs e)
        {
            // List<CarritoItem> LCarrito = new List<CarritoItem>();
            //List<CarritoItem> LCarrito = new List<CarritoItem>();
            CarritoDeCompras_2012.CS.ProxyVentasWS.CarritoItem[] LCarrito = new CarritoDeCompras_2012.CS.ProxyVentasWS.CarritoItem[100];
            

           // CarritoDeCompras_2012.CS.ProxyVentasWS.List<CarritoItem> LCarrito = new CarritoDeCompras_2012.CS.ProxyVentasWS.List<CarritoItem>();
            Carrito opercar = new Carrito();
            //invocar al webservice
            ProxyVentasWS.VentasWS ws = new ProxyVentasWS.VentasWS();

            //LCarrito = opercar.ObtenerCookie();


            string Cookie = "";
            if (Request.Cookies["CarritoDeCompras"] != null)
            {
                Cookie = HttpUtility.UrlDecode(Request.Cookies["CarritoDeCompras"].Values.ToString());
            }
            List<CarritoItem> ListCarrito = new List<CarritoItem>();

            ListCarrito = ParsearCookie.ParsearCookieYGenerar(Cookie);
            //LCarrito = ParsearCookie.ParsearCookieYGenerar(Cookie);
            //ver xq los tipos no me acepta...
           // LCarrito = (CarritoDeCompras_2012.CS.ProxyVentasWS.CarritoItem[])ListCarrito.ConvertAll();


            //Primero instanciamos el servicio
            //Cliente c = new Cliente();
            //Cliente c = new Cliente(this.nom.Text, this.ape.Text, this.mail.Text); 
          // EntidadesCS.Cliente c = new EntidadesCS.Cliente();
            //CarritoDeCompras_2012.CS.ProxyVentasWS.Cliente c = new CarritoDeCompras_2012.CS.ProxyVentasWS.Cliente(this.nom.Text, this.ape.Text, this.mail.Text);
            CarritoDeCompras_2012.CS.ProxyVentasWS.Cliente c = new CarritoDeCompras_2012.CS.ProxyVentasWS.Cliente();
            
            c.Nombre = nom.Text; 
            c.Apellido = ape.Text;
            c.Email = mail.Text;

            //Cliente(string nom, string ape, string email)
            //Declarando el WEbSErvice
            ws.AgregarVenta(c, LCarrito);
            
            
        }

    }
}
