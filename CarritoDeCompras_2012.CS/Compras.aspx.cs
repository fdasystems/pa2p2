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


        public static CarritoDeCompras_2012.CS.ProxyVentasWS.CarritoItem lccTolc(CarritoItem pf)
        {
            //return new Point(((int)pf.X), ((int)pf.Y));
            //CarritoItem cI = new CarritoItem();
            CarritoDeCompras_2012.CS.ProxyVentasWS.CarritoItem cI = new CarritoDeCompras_2012.CS.ProxyVentasWS.CarritoItem();

            cI.idProducto = pf.idProducto;
            cI.NombreProducto = pf.NombreProducto;
            cI.Cantidad = pf.Cantidad;
            cI.PrecioUnitario = pf.PrecioUnitario;
            cI.PrecioTotal = pf.PrecioTotal;

            return cI;




        }


        public List<CarritoItem> ObtenerCookie()
        {
            string Cookie = "";

            if (Request.Cookies["CarritoDeCompras"] != null)
            {
                Cookie = HttpUtility.UrlDecode(Request.Cookies["CarritoDeCompras"].Values.ToString());
            }
            List<CarritoItem> ListCarrito = new List<CarritoItem>();

            ListCarrito = ParsearCookie.ParsearCookieYGenerar(Cookie);

            return ListCarrito;
        }




        protected void btnComprar_Click(object sender, EventArgs e)
        {

            List<CarritoItem> LCCarrito = new List<CarritoItem>();
            CarritoDeCompras_2012.CS.ProxyVentasWS.CarritoItem[] LCarrito = new CarritoDeCompras_2012.CS.ProxyVentasWS.CarritoItem[100];
            CarritoDeCompras_2012.CS.ProxyVentasWS.CarritoItem cI = new CarritoDeCompras_2012.CS.ProxyVentasWS.CarritoItem();


            LCCarrito = ObtenerCookie();


            int pos = 0;

            foreach (CarritoItem Item in LCCarrito)
            {
                cI = lccTolc(Item);
                LCarrito[pos] = cI;
                //LCarrito.Add(cI);
                pos++;
            }


            //invocar al webservice
            ProxyVentasWS.VentasWS ws = new ProxyVentasWS.VentasWS();

            CarritoDeCompras_2012.CS.ProxyVentasWS.Cliente c = new CarritoDeCompras_2012.CS.ProxyVentasWS.Cliente();

            c.Nombre = nom.Text;
            c.Apellido = ape.Text;
            c.Email = mail.Text;


            //vemos que devuelve
            string mensaje = ws.AgregarVenta(c, LCarrito) ? "Datos Guardados Correctamente" : "Error critico: No se guardaron los datos.";



            //y lo informamos
            string i = "<script>window.alert('";
            string f = "');</script>";
            mensaje = i + mensaje + f;

            Response.Write(mensaje);

            //limpiamos valores
            //borro
            if (Request.Cookies["CarritoDeCompras"] != null)
            {
                //creo de nuevo
                HttpCookie addCookie = new HttpCookie("CarritoDeCompras");
                //Request.Cookies["CarritoDeCompras"].Expires = DateTime.Now.AddDays(-1d);
                addCookie.Expires = DateTime.Now.AddDays(-1d);
                //veo si con escritura se va
                Response.Cookies.Add(addCookie);

            }
            




            //habilito y deshabilito
            btnComprar.Enabled = false;
            btnFinalizar.Enabled = true;


        }



        protected void btnFinalizar_Click(object sender, EventArgs e)
        {

            Session["vengodecompras"] = "1";

            //habilito y deshabilito
            btnComprar.Enabled = false;
            btnFinalizar.Enabled = true;

            
        }

    }
}
