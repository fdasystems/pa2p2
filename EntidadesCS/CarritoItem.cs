using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCS
{
    public class CarritoItem

    {
            private int _cantidad;
            private int _idProducto;
            private string _nombreProducto;
            //utilizo valores en float para tomar los decimales
            private float _precioUnitario;
            //AGREGO COSTO TOTAL
            private float _precioTotal;

            public int Cantidad
            {
                get { return _cantidad; }
                set { _cantidad = value; }
            }
            public int idProducto
            {
                get { return _idProducto; }
                set { _idProducto = value; }
            }
            public string NombreProducto
            {
                get { return _nombreProducto; }
                set { _nombreProducto = value; }
            }
            public float PrecioUnitario
            {
                get { return _precioUnitario; }
                set { _precioUnitario = value; }
            }

            public float PrecioTotal
            {
                get { return _precioTotal; }
                set { _precioTotal = value; }
            }


        
    }
}
