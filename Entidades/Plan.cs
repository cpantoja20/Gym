using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Plan
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public string duracion { get; set; }
        public List<Rutina> rutinas { get; set; }
    }
}
