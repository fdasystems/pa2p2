using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Collections.Specialized;
using EntidadesCS;


//parseo de cadenas
using System.Text;
using System.Globalization;

namespace CarritoDeCompras_2012.CS
{
    public partial class Parseador : System.Web.UI.Page
    {
        public static int Contiene(string palabra, string cadena, int aparicion)
        {
            int veces = 0, posicion = -1;
            for (int i = 0; i < palabra.Length; i++)
                //Si encontramos dos letras iguales
                if (palabra[i] == cadena[0])
                {

                    veces = veces + 1;
                    if (veces.Equals(aparicion))
                        posicion = i;


                }
            //Si está contenida sera el valor sino sera -1
            return posicion;
        }


        public static bool Existencia(string cadena, int[,] resultado)
        {

            bool existe = false;

            try
            {
                for (int i = 0; i < resultado.GetLength(0); i++)
                {
                    //buscamos una por una cuantas veces se repite
                    //compruebo existencia, si no existe lo agrego
                    if (resultado[i, 0] == int.Parse(cadena))
                    {
                        existe = true;
                    }
                }
            }
            catch (Exception e)
            {
                string error = e.ToString();
            }


            return existe;
        }






        /// <summary>
        /// Si es una cadena, solo busca el id
        /// 5,2,8,2,2,5,5,5,8   
        /// => 2 -> 3 
        ///     5 -> 4
        ///     8 -> 2
        /// pero si es una lista, deberia:
        /// ver en el array_cantidad y...
        /// A) el valor... si es > 1 tomar en cuenta ese, sino contar
        /// o
        /// B) solo retornar el valor de posicion en array_cantidad...
        /// o
        /// C) tomar el valor (cantidad), y recorrer el resto de la lista 
        /// a partir de [posicion_actual_del_indice] y sumar (cantidad_encontrada) al 
        /// valor de (cantidad) pasado .......>>>>>> cantidad=cantidad+cantidad_encontrada
        /// eX {2,5,8,5}{3,3,2,1}
        /// /// eX {5,5,8,5}{3,3,2,1}
        /// /// eX {2,2,2,2}{3,3,2,1}
        /// </summary>
        /// <param name="cadena"></param>
        /// <param name="cantidadDeColumnas"></param>
        /// <returns></returns>

        public static int[,] DevolverCuantasVecesEnLista(string[] cadena, int cantidadDeColumnas, string[] cantidades)
        {
           
            int veces = 0;
            int len = cadena.Length;
            int largo = 0;
            int cantidadReal = 0;
            string id="";
            cantidadReal = CantidadConDatos(cadena);
            
                                      //cantidad de filas   //cantidad de columnas
            int[,] resultado = new int[cantidadReal, cantidadDeColumnas]; //uso este que se adapta mejor...


            bool existe = false;


            for (int i = 0; i < cantidadReal; i++)
            {
                
                //obtenemos la cantidad asociada al indice analizado
                id = cadena[i];
                veces = int.Parse(cantidades[i]);
                
                //recorremos el vector a partir del siguiente al indice analizado...
                for (int j = i+1; j < cantidadReal; j++)
                    //si el id coincide...
                    if (id.Equals(cadena[j]))
                        //y sumamos el valor del vector cantidad asociado al id
                        veces = veces + int.Parse(cantidades[j]);
                
                
                //En este punto existen el id con la cantidad exacta, debemos guardarlos antes de pasar al siguiente...
                //PERO TENEMOS QUE CUIDAR LOS QUE YA GUARDAMOS NO REPETIRLOS EN EL RESULTADO
                //compruebo existencia, si no existe lo agrego
                existe = Existencia(cadena[i], resultado);
                largo = cadena[i].Length;
                if (!existe & largo > 0)
                {
                    resultado[i, 0] = int.Parse(cadena[i]);
                    resultado[i, 1] = veces;
                }

                //SI YA EXISTE LO OMITO...


            }
            return resultado;
        }


        public static int[,] DevolverCuantasVeces(string[] cadena, int cantidadDeColumnas)
        {
            int veces = 0;
            int len = cadena.Length;
            int largo = 0;
            int cantidadReal = 0;
            cantidadReal = CantidadConDatos(cadena);
            //int [,] resultado =new int[len,2]; //con esto me agrega uno demas...
            //cantidad de filas   //cantidad de columnas
            int[,] resultado = new int[cantidadReal, cantidadDeColumnas]; //uso este que se adapta mejor...


            bool existe = false;





            //for (int i = 0; i < len; i++) cantidadReal
            for (int i = 0; i < cantidadReal; i++)
            {
                //buscamos una por una cuantas veces se repite
                veces = CuantasVeces(cadena[i], cadena, false);

                //compruebo existencia, si no existe lo agrego
                existe = Existencia(cadena[i], resultado);
                largo = cadena[i].Length;
                if (!existe & largo > 0)
                {
                    resultado[i, 0] = int.Parse(cadena[i]);
                    resultado[i, 1] = veces;
                }

                //con la actualizacion 2, si existe deberia agregarle la cantidad...


            }
            return resultado;
        }





        public static int CuantasVeces(string palabra, string[] cadena, bool VerPosicion)
        {
            int veces = 0;

            for (int i = 0; i < cadena.Length; i++)
                //Si encontramos dos items iguales, sumo cantidad
                if (palabra == cadena[i])
                {

                    veces = veces + 1;
                    if (VerPosicion)
                        return i;

                }
            //Si está contenida sera el valor, al menos una vez va a aparecer (porque previamente obtuvimos el valor del array)
            return veces;
        }

        public static int CantidadConDatos(string[] cadena)
        {
            int dato = 0;

            for (int i = 0; i < cadena.Length; i++)
                //con esto evito los nulos
                if (cadena[i].Length > 0)
                {

                    dato = dato + 1;


                }
            //devolvera la cantidad real de datos en el array
            return dato;
        }









        public CarritoItem GuardarPosicion(int posicion, string valor, string cantidad, string[] array_NombreProducto,string[]  array_Precio){
            CarritoItem cI = new CarritoItem();

            int id = int.Parse(valor);
            if (id > 0)
            {
                cI.idProducto = id;
                int cant = int.Parse(cantidad);
                cI.Cantidad = cant;
                cI.NombreProducto = array_NombreProducto[posicion];
                float conv = float.Parse(array_Precio[posicion].ToString());
                //precio unitario
                cI.PrecioUnitario = Math.Round(conv, 2);
                //Obtengo el monto total
                conv = conv * cant;
                cI.PrecioTotal = Math.Round(conv, 2);
                
            }

            return cI;

        }



        public static string RemoveDiacritics(string str)
        {
            if (str == null) return null;
            var chars =
                from c in str.Normalize(NormalizationForm.FormD).ToCharArray()
                let uc = CharUnicodeInfo.GetUnicodeCategory(c)
                where uc != UnicodeCategory.NonSpacingMark
                select c;

            var cleanStr = new string(chars.ToArray()).Normalize(NormalizationForm.FormC);

            return cleanStr;
        }


        public List<CarritoItem> ParsearCookieYGenerar(string s2, bool lista)
        {

            CarritoItem cI = new CarritoItem();
            List<CarritoItem> ListCarrito = new List<CarritoItem>();

            //Pruebo reemplazo caracteres primero...
            s2 = RemoveDiacritics(s2);


            int size = s2.Length; // DEBO AGREGAR IF SIZE >0... HACER TODO (ES CUANDO NO HAY MAS ITEMS -SE ELIMINA EL ULTIMO-)


            if (size > 0)
            {

                int finaldatos = size - 1; //asi quito el pipe (sin usar caracter de escape)
                //manejo el incremento para por los caracteres de identificacion (es decir C=&)
                int inc = 3;
                //& me separa las variables dentro de la cookie, hay 3 separaciones
                int indexofa = Contiene(s2, "&", 1);
                int indexofb = Contiene(s2, "&", 2);
                int indexofc = Contiene(s2, "&", 3);

                //aca agregamos solo los datos a cada valor de item
                string id = s2.Substring(inc, indexofa - inc); //OJO, Cuando elimino el ultimo aca no vale nada...
                string cantidad = s2.Substring(s2.IndexOf("C=", 1) + inc, indexofb - indexofa - inc - 1);
                string NombreProducto = s2.Substring(s2.IndexOf("N=", 1) + inc, indexofc - indexofb - inc - 1);
                string Precio = s2.Substring(s2.IndexOf("P=", 1) + inc, finaldatos - indexofc - inc - 1);

                //una vez obtenidas todas las variables separamos las comlumnas en arrays
                string[] array_id = id.Split('|');
                string[] array_cantidad = cantidad.Split('|');
                string[] array_NombreProducto = NombreProducto.Split('|');
                string[] array_Precio = Precio.Split('|');

                //ahora creo un vector con el par id=cantidadcolumnas
                int cantidadDeColumnas = 2;
                int[,] resultado_final ;

                if (lista)
                    resultado_final = DevolverCuantasVecesEnLista(array_id, cantidadDeColumnas, array_cantidad);
                else
                    resultado_final = DevolverCuantasVeces(array_id, cantidadDeColumnas);

                //valores dentro del array
                int da = 0;
                int db = 0;


                //recorro el array para obtener cada valor de item y luego guardo en el cookie
                for (int i = 0; i < resultado_final.GetLength(0); i++)
                    for (int j = 0; j < cantidadDeColumnas; j++)
                    {
                        if (j == 0)
                            da = resultado_final[i, j];
                        else
                        {
                            db = resultado_final[i, j];


                            string vi = da.ToString(); //me da el valor del item
                            string cvqa = db.ToString(); //me da la cantidad de veces que aparece 

                            //opcion1, puedo obtener la posicion del valor en el array principal, 
                            //y moverme con esos valores en los otros arrays para recuperar los valores a guardar
                            int posicion = CuantasVeces(vi, array_id, true);
                            if (int.Parse(db.ToString()) > 0)
                            {
                                //le paso la id y la posicion de esa id dentro de cada array con valores
                                cI = GuardarPosicion(posicion, vi, cvqa, array_NombreProducto, array_Precio);
                                ListCarrito.Add(cI);
                            }
                        }//de if j
                    } //de for

            } //de if size
            else //si no existen datos para parsear entonces es el ultimo eliminado
                ListCarrito = null;


            //devuelvo el carrito generado
            return ListCarrito; 
        }

    }
}