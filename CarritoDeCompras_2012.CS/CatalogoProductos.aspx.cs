using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Configuration;
using EntidadesCS;


namespace CarritoDeCompras_2012.CS
{
    public partial class CatalogoProductos : System.Web.UI.Page
    {

        
        /* declaramos objetos globales */
        TratarCookie tc = new TratarCookie();
        Parseador    pc = new Parseador();

        string[] producto_ = {""};
        string id_ = "";
        string[] precio_ = {""};
        string cantidad_ = "";
        static int cantidad = 1;
        

        HttpCookie Carrito;
        
        

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{

            //}
            /* inicializamos el carrito al cargar la pagina */
            Carrito = new HttpCookie("CarritoDeCompras");

            //si vengo de comprar borrar todas las statics...
            //if (Session["vengodecompras"] == "1")
            //{
            //    producto_ = "";
            //    id_ = "";
            //    precio_ = "";
            //    cantidad_ = "";
            //}

        }


        protected void GenerarCookie(object sender, EventArgs e)
        {
            /*****************************
             ****** EN ESTA SECCION ******
             *****************************
             * Vamos a guardar por cada clic un elemento mas a la cookie
             * para eso vamos a tomar la fila seleccionada y guardaremos los datos 
             * en las variables correspondientes. Cada vez que haya uno 
             * Nuevo se recuperara el dato actual e ingresara el siguiente.
             * 
             */          

            GridViewRow fila = GridView1.SelectedRow;
            List<CarritoItem> LCarrito = new List<CarritoItem>();
            CarritoItem cI = new CarritoItem();
            
            //primero obtengo cookie actual
            LCarrito = tc.ObtenerCookie();

            //verifico si es nula, la creo...
            if (LCarrito == null)
                 LCarrito = new List<CarritoItem>();



            // obtener id
            id_ = fila.Cells[1].Text.ToString();


            //SIN DOBLE PIPE
            //if (id_.Length > 0)
            //    id_ = "|" + fila.Cells[1].Text.ToString() + id_;
            //else
            //    id_ = "|" + fila.Cells[1].Text.ToString() + "|" + id_;


            
            ////obtener producto
            producto_[0] = fila.Cells[2].Text.ToString();

            ////SIN DOBLE PIPE
            //if (producto_.Length > 0)
            //    producto_ = "|" + fila.Cells[2].Text.ToString() + producto_;
            //else
            //    producto_ = "|" + fila.Cells[2].Text.ToString() + "|" + producto_;


            ////obtener precio
            precio_[0] = fila.Cells[3].Text.ToString();

            ////SIN DOBLE PIPE
            //if (precio_.Length > 0)
            //    precio_ = "|" + fila.Cells[3].Text.ToString() + precio_; 
            //else
            //    precio_ = "|" + fila.Cells[3].Text.ToString() + "|" + precio_;   
             


            ////obtener cantidad (siempre sera 1)
            cantidad_ = cantidad.ToString();


            ////SIN DOBLE PIPE
            //if (cantidad_.Length > 0)
            //    cantidad_ = "|" + cantidad.ToString() + cantidad_;
            //else
            //    cantidad_ = "|" + cantidad.ToString() + "|" + cantidad_;




            //guardo datos recolectados
            cI = pc.GuardarPosicion(0, id_, cantidad_, producto_, precio_);
            //Carrito.Values["I"] = id_;
            //Carrito.Values["C"] = cantidad_;
            //Carrito.Values["N"] = producto_;
            //Carrito.Values["P"] = precio_ ;
            
            

            ///luego agrego valores de un item
            LCarrito.Add(cI);

            //cI.idProducto = id_;
            //cI.NombreProducto = producto_;
            //cI.Cantidad = cantidad_;
            //cI.PrecioUnitario = precio_;
            //cI.PrecioTotal = pf.PrecioTotal;

            //string s2 = LCarrito.ToString();
            string s2 = tc.ArmarStringDesdeLista(LCarrito);


            ///finalmente genero la nueva cookie            
            //tc.GenerarNuevaCookie(LCarrito); //vieja forma
            //ESTO ESTA OK PERO FALTARIA VER XQ CORNO NO SUMA LA CANTIDAD....
            tc.GenerarNuevaCookie(pc.ParsearCookieYGenerar(s2,true));    /* nueva forma*/


            /*Agrego al carrito
            //Response.Cookies.Add(Carrito);*/
                


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
