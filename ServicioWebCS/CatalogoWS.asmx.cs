using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;

namespace ServicioWebCS
{
    /// <summary>
    /// Summary description for CatalogoWS
    /// </summary>
    [WebService(Namespace = "http://localhost/CatalogoWS",Name="CatalogoWS")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CatalogoWS : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public DataSet ObtenerCatalogo()
        {
            return EntidadesCS.Productos.TraerProductos();
        }
    }
}
