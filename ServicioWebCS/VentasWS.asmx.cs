using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using CarritoDeCompras_2012.CS;
using EntidadesCS;


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

        [WebMethod]
        public string HolaDesdeVentas(List<CarritoItem> listado)
        {
            return "Hello Ventas";
        }



        [WebMethod]
        public bool AgregarVenta(Cliente cli, List<CarritoItem> listado)
        {
            return false;
        }
    }
}
