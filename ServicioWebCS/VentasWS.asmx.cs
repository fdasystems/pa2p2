using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using CarritoDeCompras_2012.CS; //esta es la que molesta creo...
using EntidadesCS;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.Caching;
using System.Web.Hosting;


namespace ServicioWebCS
{
    /// <summary>
    /// Summary description for VentasWS
    /// </summary>
    [WebService(Namespace = "localhost/VentasWS.asmx",Name="VentasWS")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class VentasWS : System.Web.Services.WebService 
    {


        //static SqlConnection conexion = crearconexion();
        
        private  SqlConnection crearconexion()
        {
            string path = HostingEnvironment.ApplicationPhysicalPath.ToString();
            string bd = "App_Data\\CompraCarrito.mdf";
            string fullpath = path + bd ;
            string ini = "Data Source=.\\SQLEXPRESS;AttachDbFilename=";
            string fin = ";Integrated Security=True;Connect Timeout=30;User Instance=True";
            string conn = ini + fullpath + fin; 

            //SqlConnection conexion = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=d:\Users\LORE\Desktop\FDA\FACU\tssi\2012\programacion avanzada II\pa2p2\ServicioWebCS\App_Data\CompraCarrito.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            SqlConnection conexion = new SqlConnection(@conn);
            return conexion;
        }


        private int obtener_id(string tabla)
        {
            
            int id = 0;
            string maxid = "-1";
            string consulta = "";


            consulta = "select max(id)  from " + tabla;

            SqlConnection conexion = crearconexion();
            SqlCommand Comando = new SqlCommand(consulta, conexion);



            try
            {
                conexion.Open();
                Comando.CommandText = consulta;
                Comando.CommandType = CommandType.Text;
                SqlDataReader reader = Comando.ExecuteReader();

                if (reader.Read())
                {
                    maxid = reader[0].ToString();
                }
                reader.Close();


                id = Int32.Parse(maxid);

            }

            catch (SqlException ex)
            {

                // mostrar error
                string error = ex.ToString();
                id = -1;

            }

            finally
            {
                // Close Connection
                conexion.Close();
            }



            return id;

        }




        private bool insertar(string tabla, string campos, string valores) {

            bool flaginsercion = true;
            string insercion = "";
            SqlConnection conexion = crearconexion();
            SqlCommand Comando = conexion.CreateCommand();
            
            //insercion = "INSERT  INTO " + tabla + " (" + PrintValues(campos) + ") VALUES (" + PrintValues(valores) + ")";
            insercion = "INSERT  INTO " + tabla + " (" + campos + ")  " + valores + "";

            try
            {
                conexion.Open();
                Comando.CommandText = insercion;
                Comando.ExecuteNonQuery();
            }



            catch (SqlException ex)
            {

                // mostrar error
                string error = "1 " + insercion;  //genero el valor 1 al inicio de la cadena, para reconocer el error afuera si hace falta
                error = error + ex.ToString();
                flaginsercion = false;


            }

            finally
            {
                // Close Connection
                conexion.Close();
            }


            return flaginsercion;

        }


        private string ArmarValores(IEnumerable<CarritoItem> myList, string id)
        {
            string res, pun, ptt, resfull = "";
           
            

            foreach (CarritoItem Item in myList)
            {
                
                //controlo valores nulos
                if (Item != null)
                {

                    res = "select " + id + ",";
                    res = res + Item.idProducto + ",";
                    string nombreProducto = Item.NombreProducto.Replace("'", "''");
                    res = res + "'" + nombreProducto + "',"; //para agregar el apostofre al nombre inserto 2 comillas
                    res = res + Item.Cantidad + ",";
                    pun = Item.PrecioUnitario.ToString().Replace(",", ".");
                    res = res +  pun + ","; //les agrego comillas para evitar la coma (o tambien el punto)
                    ptt = Item.PrecioTotal.ToString().Replace(",", ".");
                    res = res +  ptt ;
                    //   if (i<cuantos)
                    res = res + " union ";
                    //  else
                    //    res = res + ")";

                    resfull = resfull + res;
                    //i = i + 1;
                }
            }
            //quitar el ultimo caracter coma
            int l = resfull.Length;
            resfull = resfull.Substring(0,l-7);

            return resfull;
        }






        //hello
        [WebMethod]
        public List<CarritoItem> HolaDesdeVentas()
        {
            List<CarritoItem> listado = new List<CarritoItem>();
            return listado;
            //return "Hello Ventas";
        }


       // List<CarritoItem>

        [WebMethod]
        public List<CarritoItem> crearListado(string test)
        {
            List<CarritoItem> listado = new List<CarritoItem>();
            return listado;

        }


        //IEnumerable<CarritoItem>
        [WebMethod]
      //  public bool AgregarVenta(Cliente cli, IEnumerable<CarritoItem> listado)
        //public bool AgregarVenta(Cliente cli, IEnumerable<CarritoItem> listado) //no funca...
        public bool AgregarVenta(Cliente cli, List<CarritoItem> listado) //se ejecuta ok
        {
            bool exito1, exito2=false;
            int id;
            
           //pimero la cabecera
            exito1 = insertar("cabeceraCompras", "nombre, apellido, email", " VALUES ('" + cli.Nombre + "','" + cli.Apellido + "','" + cli.Email + "')");

            //evito los errores de parseo...
            if (exito1)
            {
                //obtengo el id insertado
                id = obtener_id("cabeceraCompras");



                //finalmente el detalle
                string valores = ArmarValores(listado, id.ToString());
                exito2 = insertar("detalleCompra", "id_compra, id_producto, nombre_producto, cantidad, precio_unitario, precio_final", valores);

            }

            if (exito1 && exito2)
                return true;
            else
                return false;
        }
    }
}
