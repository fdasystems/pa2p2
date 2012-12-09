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
        TratarCookie tc = new TratarCookie();



        protected void Page_Load(object sender, EventArgs e)
        {
            CargarGrillaDeCookies();
        }


        
        
        public void CargarGrillaDeCookies()
        {
            
            GridView1.DataSource = tc.ObtenerCookie(); 
            GridView1.DataBind();
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<CarritoItem> LCarrito = new List<CarritoItem>();
            CarritoItem cI = new CarritoItem();


            int id = this.GridView1.SelectedIndex;
            
            LCarrito = tc.ObtenerCookie();
            LCarrito.RemoveAt(id);
            tc.GenerarNuevaCookie(LCarrito);

            //Vuelvo a llamar a la pagina para que relea la cookie
            Response.Redirect("Carrito.aspx");
        }



        protected void btnComprar_Click(object sender, EventArgs e)
        {
            int r = GridView1.Rows.Count;
            if (r > 0)
                Response.Redirect("Compras.aspx");
            else
            {
                string mensaje = "Debe Seleccionar Al Menos Un Item Para Comprar";

                //Aseguramos que ingrese valores
                string i = "<script>window.alert('";
                string f = "');</script>";
                mensaje = i + mensaje + f;

                Response.Write(mensaje);

            }
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
