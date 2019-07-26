using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Venta
    {
        public string id;
        public DateTime fecha;
        public Cliente cliente;
        public List<Producto> productos;
        public double total;
    }
}
