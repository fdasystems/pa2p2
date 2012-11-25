using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarritoDeCompras_2012.CS
{
    public class Cliente
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }

        //seteo variables del carrito
        Cliente(string nom, string ape, string email)
        {
            this.Nombre     = nom;
            this.Apellido   = ape;
            this.Email      = email;
            
        }
    }
    
}
