using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Configuration;


namespace CarritoDeCompras_2012.CS
{
    public partial class CatalogoProductos : System.Web.UI.Page
    {

        
        /* declaramos objetos globales */
        static int[] listado__o;
        HttpCookie Carrito;
        static List<int> lista;
        static string producto_ = "";
        static string id_ = "";
        static string precio_ = "";
        static string cantidad_ = "";
        static int cantidad=1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listado__o = new int[100];
                lista = new List<int>();


            }
            /* inicializamos el carrito al cargar la pagina */
            Carrito = new HttpCookie("CarritoDeCompras");

            //si vengo de comprar borrar todas las statics...
            if (Session["vengodecompras"] == "1")
            {
                producto_ = "";
                id_ = "";
                precio_ = "";
                cantidad_ = "";
            }

        }


        protected void GenerarCookie(object sender, EventArgs e)
        {
            /*****************************
             ****** EN ESTA SECCION ******
             *****************************
             * Vamos a guardar por cada clic un elemento mas a la cookie
             * para eso vamos a tomar la fila seleccionada y guardaremos los datos 
             * en las variables estaticas correspondientes. Cada vez que haya uno 
             * Nuevo se recuperara el dato actual e ingresara el siguiente.
             * 
             */          

            GridViewRow fila = GridView1.SelectedRow;

            // obtener id
            //SIN DOBLE PIPE
            if (id_.Length > 0)
                id_ = "|" + fila.Cells[1].Text.ToString() + id_;
            else
                id_ = "|" + fila.Cells[1].Text.ToString() + "|" + id_;


            
            //obtener producto
            //SIN DOBLE PIPE
            if (producto_.Length > 0)
                producto_ = "|" + fila.Cells[2].Text.ToString() + producto_;
            else
                producto_ = "|" + fila.Cells[2].Text.ToString() + "|" + producto_;


            //obtener precio
            //SIN DOBLE PIPE
            if (precio_.Length > 0)
                precio_ = "|" + fila.Cells[3].Text.ToString() + precio_; 
            else
                precio_ = "|" + fila.Cells[3].Text.ToString() + "|" + precio_;   
             


            //obtener cantidad (siempre sera 1)
            //SIN DOBLE PIPE
            if (cantidad_.Length > 0)
                cantidad_ = "|" + cantidad.ToString() + cantidad_;
            else
                cantidad_ = "|" + cantidad.ToString() + "|" + cantidad_;




            //guardo datos recolectados
            Carrito.Values["I"] = id_;
            Carrito.Values["C"] = cantidad_;
            Carrito.Values["N"] = producto_;
            Carrito.Values["P"] = precio_ ;
            //Carrito.Values["P"] = precio_ + "$";   este marca un fin de item pero me deja un espacio en blanco, lo quito porque creo que no me hace falta...

            //Agrego al carrito
            Response.Cookies.Add(Carrito);
                


        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Carrito.aspx");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

    }

}
