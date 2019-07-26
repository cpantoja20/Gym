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
    public partial class FormProductos : Form
    {
        public FormProductos()
        {
            InitializeComponent();
        }
        public void cargartabla()
        {
            tabla.DataSource = Inicio.lpr.listar();
        }
        private void FormProductos_Load(object sender, EventArgs e)
        {
            cargartabla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tabla.SelectedRows.Count > 0)
            {
                string id = tabla.CurrentRow.Cells[0].Value.ToString();
                if (Inicio.lpr.eliminar(id))
                {
                    cargartabla();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FormRegistraryActualizarProducto from = new FormRegistraryActualizarProducto();
            Producto p = new Producto();
            if (tabla.SelectedRows.Count > 0)
            {

                p.id = tabla.CurrentRow.Cells[0].Value.ToString();
                p.nombre = tabla.CurrentRow.Cells[1].Value.ToString();
                p.descripcion = tabla.CurrentRow.Cells[2].Value.ToString();
                p.cantidad = int.Parse(tabla.CurrentRow.Cells[3].Value.ToString());
                p.precio_compra = Decimal.Parse(tabla.CurrentRow.Cells[4].Value.ToString());
                p.precio_venta = Decimal.Parse(tabla.CurrentRow.Cells[5].Value.ToString());
                from.cargarproducto(p);
                from.Show();

            }
            else { MessageBox.Show("debe seleccionar fila"); }
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            FormRegistraryActualizarProducto from = new FormRegistraryActualizarProducto();
            from.Show();
        }

        private void btnActualizarTabla_Click(object sender, EventArgs e)
        {
            cargartabla();
        }

        private void tabla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
