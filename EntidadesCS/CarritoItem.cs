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
            //utilizo valores en double para tomar los decimales
            private double _precioUnitario;
            //AGREGO COSTO TOTAL
            private double _precioTotal;

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
            public double PrecioUnitario
            {
                get { return _precioUnitario; }
                set { _precioUnitario = value; }
            }

            public double PrecioTotal
            {
                get { return _precioTotal; }
                set { _precioTotal = value; }
            }


        
    }
}
