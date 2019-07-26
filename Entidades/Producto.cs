using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Producto
    {
        public string id{ get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int cantidad { get; set; }
        public decimal precio_compra { get; set; }
        public decimal precio_venta { get; set; }
    }
}
