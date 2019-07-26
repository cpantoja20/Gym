using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;
namespace Presentaciones
{
    public static class Inicio
    {
        public static GestionCliente lc = new GestionCliente();
        public static GestionPlan lpl = new GestionPlan();
        public static GestionProducto lpr = new GestionProducto();
        public static GestionRutina lru = new GestionRutina();
        public static GestionVenta lve = new GestionVenta();
        public static GestionPago lpa = new GestionPago();


        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());
        }
    }
}
