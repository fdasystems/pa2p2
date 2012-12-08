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
            /****************************************************************
            /****************************************************************
            /****************************************************************
            /****************************************************************
          LA IDEA ES OBTENER EL CARRITO QUE ES TIPO LIST<CARRITOITEM> A PARTIR
          DE LA COOKIE, ESTE PASO YA LO HICE EN LA PAGINA CARRITO.ASPX.CS POR 
          ESO INSTANCIO UN OBJETO Carrito opercar = new Carrito(); PARA LLAMAR
          AL METODO QUE LO HIZO, EL CUAL SE LLAMA opercar.ObtenerCookie() QUE 
          DEVUELVE UN OBJETO LIST<CARRITOITEM>, PERO LUEGO AL LLAMAR AL WEBSERVICE
          CON EL METODO CREADO ws.AgregarVenta(c, LCarrito); Y AHI ES DONDE NO LE
          GUSTA LOS TIPOS PORQUE COMO QUE CONFUNDE LO IMPORTADO EN EL WEBSERVICEVENTAS
          CON LO QUE IMPORTO DIRECTAMENTE EN REFERENCES... DE TODOS MODOS EN AMBOS 
          CASOS, IMPORTO LA MISMA ENTIDAD, ASI QUE NO SE PORQUE SE CONFUNDE....
             * 
             * ESTE ES EL ERROR QUE TIRA..
             * Error	2	Argumento '2': no se puede convertir de 'System.Collections.Generic.List<EntidadesCS.CarritoItem>' a 'CarritoDeCompras_2012.CS.ProxyVentasWS.CarritoItem[]'	D:\Users\LORE\Desktop\FDA\FACU\tssi\2012\programacion avanzada II\pa2p2\CarritoDeCompras_2012.CS\Compras.aspx.cs	90	32	CarritoDeCompras_2012.CS

            
             /**************************************************************** 
             /****************************************************************
             /****************************************************************
             /****************************************************************
             * ****************************************************************/

            List<CarritoItem> LCarrito = new List<CarritoItem>(); //con esto me tira... Error	1	La mejor coincidencia de método sobrecargado para 'CarritoDeCompras_2012.CS.ProxyVentasWS.VentasWS.AgregarVenta(CarritoDeCompras_2012.CS.ProxyVentasWS.Cliente, CarritoDeCompras_2012.CS.ProxyVentasWS.CarritoItem[])' tiene algunos argumentos no válidos	D:\Users\LORE\Desktop\FDA\FACU\tssi\2012\programacion avanzada II\pa2p2\CarritoDeCompras_2012.CS\Compras.aspx.cs	72	13	CarritoDeCompras_2012.CS


            //CarritoDeCompras_2012.CS.ProxyVentasWS.CarritoItem[] LCarrito = new CarritoDeCompras_2012.CS.ProxyVentasWS.CarritoItem[100]; //y con esto tira Error	1	No se puede convertir implícitamente el tipo 'System.Collections.Generic.List<EntidadesCS.CarritoItem>' en 'CarritoDeCompras_2012.CS.ProxyVentasWS.CarritoItem[]'	D:\Users\LORE\Desktop\FDA\FACU\tssi\2012\programacion avanzada II\pa2p2\CarritoDeCompras_2012.CS\Compras.aspx.cs	55	24	CarritoDeCompras_2012.CS


            

           // CarritoDeCompras_2012.CS.ProxyVentasWS.List<CarritoItem> LCarrito = new CarritoDeCompras_2012.CS.ProxyVentasWS.List<CarritoItem>();
            Carrito opercar = new Carrito();
            //invocar al webservice
            ProxyVentasWS.VentasWS ws = new ProxyVentasWS.VentasWS();
			//forma automatica (llamando a la clase)
            LCarrito = opercar.ObtenerCookie();

			//esta es la forma manual... (que es lo que hace el metodo obtenercookie) pero tampoco funca
            string Cookie = "";
            if (Request.Cookies["CarritoDeCompras"] != null)
            {
                Cookie = HttpUtility.UrlDecode(Request.Cookies["CarritoDeCompras"].Values.ToString());
            }
            List<CarritoItem> ListCarrito = new List<CarritoItem>();

            ListCarrito = ParsearCookie.ParsearCookieYGenerar(Cookie);
            LCarrito = ParsearCookie.ParsearCookieYGenerar(Cookie); //Error	1	No se puede convertir implícitamente el tipo 'System.Collections.Generic.List<EntidadesCS.CarritoItem>' en 'CarritoDeCompras_2012.CS.ProxyVentasWS.CarritoItem[]'	D:\Users\LORE\Desktop\FDA\FACU\tssi\2012\programacion avanzada II\pa2p2\CarritoDeCompras_2012.CS\Compras.aspx.cs	63	24	CarritoDeCompras_2012.CS

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
