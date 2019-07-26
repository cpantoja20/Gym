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
    public partial class FormRutinas : Form
    {
        public FormRutinas()
        {
            InitializeComponent();
        }

        public void cargartabla()
        {
            tabla.DataSource = Inicio.lru.listar();
        }
        private void FormRutinas_Load(object sender, EventArgs e)
        {
            cargartabla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tabla.SelectedRows.Count > 0)
            {
                string id = tabla.CurrentRow.Cells[0].Value.ToString();
                if (Inicio.lru.eliminar(id))
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

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            FormRegistraryActualizarRutina from = new FormRegistraryActualizarRutina();
            from.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            FormRegistraryActualizarRutina from = new FormRegistraryActualizarRutina();
            Rutina p = new Rutina();
            if (tabla.SelectedRows.Count > 0)
            {

                p.id = tabla.CurrentRow.Cells[0].Value.ToString();
                p.nombre = tabla.CurrentRow.Cells[1].Value.ToString();
                p.descripcion = tabla.CurrentRow.Cells[2].Value.ToString();
                from.cargarrutina(p);
                from.Show();

            }
            else { MessageBox.Show("debe seleccionar fila"); }

        }

        private void btnActualizarTabla_Click(object sender, EventArgs e)
        {
            cargartabla();
        }
    }
}
