using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Cliente
    {
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public double pecho { get; set; }
        public double cintura { get; set; }
        public double cadera { get; set; }
        public string idPlan { get; set; }
    }

}
