using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCS;



//using  System.Windows.Forms.DataGridViewElement;


namespace CarritoDeCompras_2012.CS
{
    public partial class TratarCookie : System.Web.UI.Page
    {
        Parseador ParsearCookie = new Parseador();




        public void Logout()
        {
            //Session.RemoveAll();  //2da prueba
            Session.Abandon();
            System.Web.HttpContext.Current.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
        }



        public void BorrarCookie() {
            //borro
            if (System.Web.HttpContext.Current.Request.Cookies["CarritoDeCompras"] != null)
            {
                //creo de nuevo
                HttpCookie addCookie = new HttpCookie("CarritoDeCompras", "");
                //Request.Cookies["CarritoDeCompras"].Expires = DateTime.Now.AddDays(-1d);
                addCookie.Expires = DateTime.Now.AddDays(-1d);
                //veo si con escritura se va
                System.Web.HttpContext.Current.Response.Cookies.Add(addCookie);

            }

            //System.Web.HttpContext.Current.Response.Cookies.Add(new HttpCookie("CarritoDeCompras", ""));
        
        
        }





        public string ArmarStringDesdeLista(List<CarritoItem> Lc)
        {

            //vars temp
            string idp = "";
            string can = "";
            string nom = "";
            string pun = "";
             string ret = "";




            // Si queremos le asignamos un fecha de expiración: mañana
            //addCookie.Expires = DateTime.Today.AddDays(1).AddSeconds(-1);
            int cont = Lc.Count();
            int i = 1;
            foreach (CarritoItem Item in Lc)
            {

                //guardo datos recolectados
                idp = idp + "|" + Item.idProducto;
                can = can + "|" + Item.Cantidad;
                nom = nom + "|" + Item.NombreProducto;
                pun = pun + "|" + Item.PrecioUnitario;

                //adiciono pipe final
                if (i == cont)
                {
                    idp = idp + "|";
                    can = can + "|";
                    nom = nom + "|";
                    pun = pun + "|";


                }



                //addCookie.Values["I"] = idp;
                //addCookie.Values["C"] = can;
                //addCookie.Values["N"] = nom;
                //addCookie.Values["P"] = pun;

                i = i + 1;
            }

            string  ic, cc, nc, pp = "";
            ic = "I=";
            cc = "&C=";
            nc = "&N=";
            pp = "&P=";

            //I=|1|1|&C=|2|1|&N=|Chai|Chai|&P=|18|18|
            ret = ic + idp + cc + can + nc + nom + pp + pun;

            return ret; 


        }











        public void GenerarNuevaCookie(List<CarritoItem> Lc)
        {
            //vars temp
            string idp = "";
            string can = "";
            string nom = "";
            string pun = "";
            // string ptt = "";


            //borro
            BorrarCookie();
            //logout para ver si reiniciando session leo bien la cookie...
            Logout();


            //creo de nuevo
            HttpCookie addCookie = new HttpCookie("CarritoDeCompras");
            //pruebo dejarle un dia de validez al nuevo creado
            addCookie.Expires = DateTime.Now.AddDays(1d);

            // Si queremos le asignamos un fecha de expiración: mañana
            //addCookie.Expires = DateTime.Today.AddDays(1).AddSeconds(-1);
            int cont = Lc.Count();
            int i = 1;
            foreach (CarritoItem Item in Lc)
            {

                //guardo datos recolectados
                idp = idp + "|" + Item.idProducto;
                can = can + "|" + Item.Cantidad;
                nom = nom + "|" + Item.NombreProducto;
                pun = pun + "|" + Item.PrecioUnitario;

                //adiciono pipe final
                if (i == cont)
                {
                    idp = idp + "|";
                    can = can + "|";
                    nom = nom + "|";
                    pun = pun + "|";


                }



                addCookie.Values["I"] = idp;
                addCookie.Values["C"] = can;
                addCookie.Values["N"] = nom;
                addCookie.Values["P"] = pun;

                i = i + 1;
            }



            // Y finalmente Añadimos la cookie a nuestro usuario
             System.Web.HttpContext.Current.Response.Cookies.Add(addCookie);

        }








        //List
        public List<CarritoItem> ObtenerCookie()
        {
            string Cookie = "";
            
            //if (Request.Cookies["CarritoDeCompras"] != null)
            if (System.Web.HttpContext.Current.Request.Cookies["CarritoDeCompras"] != null)
            {
                Cookie = HttpUtility.UrlDecode(System.Web.HttpContext.Current.Request.Cookies["CarritoDeCompras"].Values.ToString());
                //Cookie = HttpUtility. (Request.Cookies["CarritoDeCompras"].Values.ToString());
                // Cookie = Request.Cookies["CarritoDeCompras"].Values.ToString();
            }
            List<CarritoItem> ListCarrito = new List<CarritoItem>();

            ListCarrito = ParsearCookie.ParsearCookieYGenerar(Cookie, true); //probamos usarla siempre con lista...

            return ListCarrito;
        }
    }
}