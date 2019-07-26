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
    public partial class FormClientes : Form
    {


        public FormClientes()
        {
            InitializeComponent();
        }



        public void cargartabla()
        {
            tabla.DataSource = Inicio.lc.listar();
        }



        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            FormRegistraryActualizarCliente from = new FormRegistraryActualizarCliente();
            from.cargarplanes();
            from.Show();
        }


        private void FormClientes_Load(object sender, EventArgs e)
        {
            cargartabla();
            Inicio.lc.Lista();
        }

        private void txtfiltro_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FormRegistraryActualizarCliente from = new FormRegistraryActualizarCliente();
            Cliente p = new Cliente();
            if (tabla.SelectedRows.Count > 0)
            {

                p.cedula = tabla.CurrentRow.Cells[0].Value.ToString();
                p.nombre = tabla.CurrentRow.Cells[1].Value.ToString();
                p.direccion = tabla.CurrentRow.Cells[2].Value.ToString();
                p.telefono = tabla.CurrentRow.Cells[3].Value.ToString();
                p.fechaNacimiento = DateTime.Parse(tabla.CurrentRow.Cells[4].Value.ToString());
                p.pecho = double.Parse(tabla.CurrentRow.Cells[5].Value.ToString());
                p.cintura = double.Parse(tabla.CurrentRow.Cells[6].Value.ToString());
                p.cadera = double.Parse(tabla.CurrentRow.Cells[7].Value.ToString());
                p.idPlan = tabla.CurrentRow.Cells[8].Value.ToString();
                from.cargarcliente(p);
                from.Show();

            }
            else { MessageBox.Show("debe seleccionar fila"); }
        }

        private void btnActualizarTabla_Click(object sender, EventArgs e)
        {
            cargartabla();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tabla.SelectedRows.Count > 0)
            {
                string cedula = tabla.CurrentRow.Cells[0].Value.ToString();
                if (Inicio.lc.eliminar(cedula))
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
    }
}
