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
    public partial class Carrito : System.Web.UI.Page
    {
        Parseador ParsearCookie = new Parseador();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarGrillaDeCookies();
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
            if (Request.Cookies["CarritoDeCompras"] != null)
            {
                Request.Cookies["CarritoDeCompras"].Expires = DateTime.Now.AddDays(-1d);
            }

            //creo de nuevo
            HttpCookie addCookie = new HttpCookie("CarritoDeCompras");
          

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
                  idp = idp + "|" ;
                  can = can + "|" ;
                  nom = nom + "|" ;
                  pun = pun + "|" ;


              }



              addCookie.Values["I"] = idp;
              addCookie.Values["C"] = can;
              addCookie.Values["N"] = nom;
              addCookie.Values["P"] = pun;

              i = i+1;
          }



          // Y finalmente Añadimos la cookie a nuestro usuario
          Response.Cookies.Add(addCookie);
            
        }






        public List<CarritoItem> ObtenerCookie()
        {
            string Cookie="";

            if (Request.Cookies["CarritoDeCompras"] != null)
            {
                Cookie = HttpUtility.UrlDecode(Request.Cookies["CarritoDeCompras"].Values.ToString());
            }
            List<CarritoItem> ListCarrito = new List<CarritoItem>();

            ListCarrito = ParsearCookie.ParsearCookieYGenerar(Cookie);

            return ListCarrito; 
        }
        
        
        
        public void CargarGrillaDeCookies()
        {
            GridView1.DataSource = ObtenerCookie() ; 
            GridView1.DataBind();
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<CarritoItem> LCarrito = new List<CarritoItem>();
            CarritoItem cI = new CarritoItem();


            int id = this.GridView1.SelectedIndex;
            
            LCarrito = ObtenerCookie();
            LCarrito.RemoveAt(id);
            GenerarNuevaCookie(LCarrito);

            //Vuelvo a llamar a la pagina para que relea la cookie
            Response.Redirect("Carrito.aspx");
        }



        protected void btnComprar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Compras.aspx");
        }

        protected void btnRecalcular_Click(object sender, EventArgs e)
        {
            string celda;
            float totalcompra=0;
            //DataGridItem

            
            //Recorremos el DataGridView con un bucle for
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {

                celda = GridView1.Rows[i].Cells[5].Text.ToString();

                //para que el float lo tome bien le pongo coma
                totalcompra += float.Parse(celda.Replace(".", ","));
            }


            total.Text = totalcompra.ToString();
        }

    }
}
