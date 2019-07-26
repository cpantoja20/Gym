using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Pago
    {
        public string id { get; set; }
        public DateTime fecha { get; set; }  
        public Cliente cliente { get; set; }
        public string forma_de_pago { get; set; }
        public string opcion_de_pago { get; set; }
        public double valor { get; set; }


    }
}
