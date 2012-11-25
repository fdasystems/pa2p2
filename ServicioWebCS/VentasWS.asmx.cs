using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using CarritoDeCompras_2012.CS;

namespace ServicioWebCS
{
    /// <summary>
    /// Summary description for VentasWS
    /// </summary>
    [WebService(Namespace = "localhost/VentasWS.asmx")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class VentasWS : System.Web.Services.WebService
    {   
        [WebMethod]
        public bool AgregarVenta(Cliente cli, List<Carrito> listado)
        {
            return false;
        }
    }
}
