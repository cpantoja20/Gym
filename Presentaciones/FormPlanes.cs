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
    public partial class FormPlanes : Form
    {
        public FormPlanes()
        {
            InitializeComponent();
        }
        public void cargartabla()
        {
            tabla.DataSource = Inicio.lpl.listar();
        }

        private void FormPlanes_Load(object sender, EventArgs e)
        {
            cargartabla();
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            FormRegistraryActualizarPlanes from = new FormRegistraryActualizarPlanes();
            from.Show();
        }

        private void btnActualizarTabla_Click(object sender, EventArgs e)
        {
            cargartabla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tabla.SelectedRows.Count > 0)
            {
                string id = tabla.CurrentRow.Cells[0].Value.ToString();
                if (Inicio.lpl.eliminar(id))
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
            FormRegistraryActualizarPlanes from = new FormRegistraryActualizarPlanes();
            Plan p = new Plan();
            if (tabla.SelectedRows.Count > 0)
            {

                p.id = tabla.CurrentRow.Cells[0].Value.ToString();
                p.nombre = tabla.CurrentRow.Cells[1].Value.ToString();
                p.precio = Decimal.Parse(tabla.CurrentRow.Cells[2].Value.ToString());
                p.duracion = tabla.CurrentRow.Cells[3].Value.ToString();
                p.rutinas = Inicio.lpl.MiListaDeRutinas(p.id);
                from.cargarplan(p);
                from.Show();
            }
            else { MessageBox.Show("debe seleccionar fila"); }
        }
    }
}
