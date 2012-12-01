using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Xml;
using System.IO;
using System.Configuration;
using System.Web;


namespace EntidadesCS
{
    
    public class Productos
    {
      
        
        

        public static DataSet TraerProductos(string path)
        {
            DataSet dataSet = new DataSet();

            /*NOTA: Estos directorios son locales... no los toma en otra pc, por eso hay que pasar el path por parametro para que sea automatico*/
            //C:\Users\Pavilion 6409\Desktop\FDA\facu\tssi\2012\Practica Profesional Supervisada\Practica Profesional Supervisada\PAII\EntidadesCS\EntidadesCS\EntidadesCS\ProcuctosCookieDatos.xml
            //dataSet.ReadXmlSchema("EntidadesCS/Archivos_XML/ProductosCookieSchema.xml");
            //dataSet.ReadXml("EntidadesCS/Archivos_XML/ProductosCookieDatos.xml");

            //Tomo el directorio de las entidades
            path = path.Replace("ServicioWeb", "Entidades");

            dataSet.ReadXmlSchema(path + "Archivos_XML/ProductosCookieSchema.xml");
            dataSet.ReadXml(path + "Archivos_XML/ProductosCookieDatos.xml");


            
            return dataSet;

        }

        public void traerXml()
        { 
                 
        }
    }
}
