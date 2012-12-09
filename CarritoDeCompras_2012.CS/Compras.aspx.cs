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
        TratarCookie tc = new TratarCookie();
        Parseador ParsearCookie = new Parseador();
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public static CarritoDeCompras_2012.CS.ProxyVentasWS.CarritoItem lccTolc(CarritoItem pf)
        {
            
            //CarritoItem cI = new CarritoItem();
            CarritoDeCompras_2012.CS.ProxyVentasWS.CarritoItem cI = new CarritoDeCompras_2012.CS.ProxyVentasWS.CarritoItem();

            cI.idProducto = pf.idProducto;
            cI.NombreProducto = pf.NombreProducto;
            cI.Cantidad = pf.Cantidad;
            cI.PrecioUnitario = pf.PrecioUnitario;
            cI.PrecioTotal = pf.PrecioTotal;

            return cI;




        }





        protected void btnComprar_Click(object sender, EventArgs e)
        {
            string mensaje ;
            List<CarritoItem> LCCarrito = new List<CarritoItem>();
            CarritoDeCompras_2012.CS.ProxyVentasWS.CarritoItem[] LCarrito = new CarritoDeCompras_2012.CS.ProxyVentasWS.CarritoItem[100];
            CarritoDeCompras_2012.CS.ProxyVentasWS.CarritoItem cI = new CarritoDeCompras_2012.CS.ProxyVentasWS.CarritoItem();


            LCCarrito = tc.ObtenerCookie();

            if (LCCarrito != null)
            {
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
                mensaje = ws.AgregarVenta(c, LCarrito) ? "Datos Guardados Correctamente" : "Error critico: No se guardaron los datos.";

            }
            else
                mensaje = "Debe Seleccionar Al Menos Un Item Para Comprar";

            //y lo informamos
            string i = "<script>window.alert('";
            string f = "');</script>";
            mensaje = i + mensaje + f;

            Response.Write(mensaje);

            //limpiamos valores
            tc.BorrarCookie();



            //habilito y deshabilito
            btnComprar.Enabled = false;
            btnFinalizar.Enabled = true;


        }



        protected void btnFinalizar_Click(object sender, EventArgs e)
        {

            //Nos vamos a la home...
            Response.Redirect("Default.aspx");
            
        }

    }
}
