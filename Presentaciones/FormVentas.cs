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
    public partial class FormVentas : Form
    {
        public FormVentas()
        {
            InitializeComponent();
        }
        public void cargartabla()
        {
            tabla.DataSource = Inicio.lve.listar();
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            cargartabla();
            cargarclientes();
            cargarproductos();
        }

        private void btnActualizarTabla_Click(object sender, EventArgs e)
        {
            cargartabla();
        }

        public void cargarclientes()
        {
            comboclientes.Items.Clear();
            DataTable dt = new DataTable();
            dt = Inicio.lc.listar();
            comboclientes.Text = "Seleccione...";
            foreach (DataRow fila in dt.Rows)
            {
                comboclientes.Items.Add(fila[0]);
            }
        }

        public void cargarproductos()
        {
            comboproductos.Items.Clear();
            DataTable dt = new DataTable();
            dt = Inicio.lpr.listar();
            comboproductos.Text = "Seleccione...";
            foreach (DataRow fila in dt.Rows)
            {
                comboproductos.Items.Add(fila[0]);
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void comboclientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cedula = comboclientes.Text;
            if (Inicio.lc.buscar(cedula) != null)
            {
                Cliente p = new Cliente();
                p = Inicio.lc.buscar(cedula);
                labelinfocliente.Text = " Nombre: " + p.nombre + " \n Telefono: " + p.telefono + " \n Direccion: " + p.direccion;
            }
            else
            {
                labelinfocliente.Text = "";
            }
        }

        private void comboproductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = comboproductos.Text;
            if (Inicio.lpr.buscar(id) != null)
            {
                Producto p = new Producto();
                p = Inicio.lpr.buscar(id);
                labelinfoproducto.Text = " Nombre: " + p.nombre + "\n Precio: " + p.precio_venta + "\n Cantidad actual: " + p.cantidad;
            }
            else
            {
                labelinfoproducto.Text = "";
            }
        }

        private void btnagregarrutina_Click(object sender, EventArgs e)
        {
            string id = comboproductos.Text;
            if (Inicio.lpr.buscar(id) != null)
            {
                Producto p = Inicio.lpr.buscar(id);
                object[] fila = new string[] { p.id, p.nombre, p.descripcion, txtcan.Value.ToString(), p.precio_venta.ToString(), (txtcan.Value * p.precio_venta).ToString() };
                labeltotal.Text = (Decimal.Parse(labeltotal.Text) + (p.precio_venta * txtcan.Value)).ToString();
                tablaproducto.Rows.Add(fila);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto valido");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tablaproducto.SelectedRows.Count > 0)
            {
                if (Decimal.Parse(labeltotal.Text) > 0) {
                    decimal valorrestar = Decimal.Parse(tablaproducto.CurrentRow.Cells[5].Value.ToString());
                    labeltotal.Text = (Decimal.Parse(labeltotal.Text) - valorrestar).ToString();
                }
                tablaproducto.Rows.RemoveAt(tablaproducto.CurrentRow.Index);
            }
            else {
            }
        }

        public void hacerVenta()
        {
            Venta p = new Venta();
            p.cliente = Inicio.lc.buscar(comboclientes.Text);
            p.productos = new List<Producto>();
            foreach (DataGridViewRow fila in tablaproducto.Rows)
            {
                Producto producto = new Producto();
                string id = fila.Cells[0].Value.ToString();
                producto = Inicio.lpr.buscar(id);
                producto.cantidad = int.Parse(fila.Cells[3].Value.ToString());
                p.productos.Add(producto);
            }
            p.total = double.Parse(labeltotal.Text);
            MessageBox.Show(Inicio.lve.guardar(p));
            limpiar();

            cargartabla();
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            hacerVenta();
        }

        public void limpiar()
        {
            comboclientes.Items.Clear();
            cargarclientes();
            comboproductos.Items.Clear();
            cargarproductos();
            labelinfocliente.Text = "";
            labelinfoproducto.Text = "";
            txtcan.Value = 0;
            tablaproducto.Rows.Clear();
            labeltotal.Text = "0";
        }
        private void tablaproducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tabla.SelectedRows.Count > 0)
            {
                string id = tabla.CurrentRow.Cells[0].Value.ToString();
                FormProductosComprados p = new FormProductosComprados();
                p.cargarProductos(id);
                p.Show();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila");
            }
        }
    }
}
