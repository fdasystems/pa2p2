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
        static string producto_;
        static string id_;
        static string precio_;
        static string cantidad_;
        static int cantidad;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listado__o = new int[100];
                lista = new List<int>();


            }
            /* inicializamos el carrito al cargar la pagina */
            Carrito = new HttpCookie("CarritoDeCompras");
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
            id_ = "|" + fila.Cells[1].Text.ToString() + "|" + id_;
            //elimino doble pipe (ver si se puede eliminar)
            id_ = id_.Replace("||", "|");
            
            //obtener producto
            producto_ = "|" + fila.Cells[2].Text.ToString() + "|" + producto_;
            //elimino doble pipe (ver si se puede eliminar)
            producto_ = producto_.Replace("||", "|");

            //obtener precio
            precio_ = "|" + fila.Cells[3].Text.ToString() + "|" + precio_;
            //elimino doble pipe (ver si se puede eliminar)
            precio_ = precio_.Replace("||", "|");

            //obtener cantidad
            cantidad_ = "|" + cantidad.ToString() + "|" + cantidad.ToString();
            //elimino doble pipe (ver si se puede eliminar)
            cantidad_ = cantidad_.Replace("||", "|");

            //guardo datos recolectados
            Carrito.Values["I"] = id_;
            Carrito.Values["C"] = cantidad_;
            Carrito.Values["N"] = producto_;
            Carrito.Values["P"] = precio_ ;
            //Carrito.Values["P"] = precio_ + "$";   este marca un fin de item pero me deja un espacio en blanco, lo quito porque creo que no me hace falta...

            //Agrego al carrito
            Response.Cookies.Add(Carrito);
                


        }


        //Carrito.Values["Precio"] = double.Parse(fila.Cells[3].Text).ToString();


        //for (int i = 0; i < 100; i++)
        //{
        //    if (i == GridView1.SelectedRow.RowIndex)
        //    {
        //        listado__o[i] += 1;
        //        cantidad = listado__o[i];
        //    }
        //}

        //Carrito.Values["Cantidad"] = cantidad.ToString();





        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Carrito.aspx");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

    }

}
