using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentaciones
{
    public partial class FormProductosComprados : Form
    {
        public FormProductosComprados()
        {
            InitializeComponent();
        }

        public void cargarProductos(string id_venta)
        {
            List<Producto> productos = Inicio.lve.MiListaDeProductos(id_venta);
            foreach (Producto p in productos)
            {
                labelinfoproductos.Text +=
                " ID : " + p.id + " \n " +
                "NOMBRE DE PRODUCTO : " + p.nombre + " \n " +
                "PRECIO : " + p.precio_venta.ToString() + "\n " +
                "CANTIDAD ADQUIRIDA : " + p.cantidad.ToString()+ "\n "+
                "SUB-TOTAL : " + (Decimal.Parse(p.cantidad.ToString()) * p.precio_venta).ToString()+ " \n "+
                "---------------------------------------------------- \n \n";
                        
            }
        }
    }
}
