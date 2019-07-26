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
    public partial class FormRegistraryActualizarCliente : Form
    {

        public FormRegistraryActualizarCliente()
        {
            InitializeComponent();
        }

        public void cargarcliente(Cliente p)
        {
            cargarplanes();
            txtced.Text = p.cedula;
            txtced.Enabled = false;
            txtnom.Text = p.nombre;
            txtdir.Text = p.direccion;
            txttel.Text = p.telefono;
            txtfec.Value = p.fechaNacimiento;
            txtpec.Text = p.pecho.ToString();
            txtcin.Text = p.cintura.ToString();
            txtcad.Text = p.cadera.ToString();
            comboplanes.Text = p.idPlan;
        }
        public void limpiar()
        {
            txtced.Text = "";
            txtnom.Text = "";
            txtdir.Text = "";
            txttel.Text ="";
            txtfec.Value =DateTime.Now;
            txtpec.Text ="";
            txtcin.Text = "";
            txtcad.Text = "";
            comboplanes.Text = comboplanes.Items[0].ToString();
        }

        public void guardar()
        {
            //Miro si ya existe el cliente
            //si ya existe entonces lo va a editar
            //sino lo va a guardar

            Cliente p = new Cliente();
            p.cedula = txtced.Text;
            p.nombre = txtnom.Text;
            p.direccion = txtdir.Text;
            p.telefono = txttel.Text;
            p.fechaNacimiento = txtfec.Value.Date;
            p.pecho = Double.Parse(txtpec.Text);
            p.cintura = Double.Parse(txtcin.Text);
            p.cadera = Double.Parse(txtcad.Text);
            p.idPlan = comboplanes.Text;
            if (Inicio.lc.buscar(txtced.Text)==null)
            {
                MessageBox.Show(Inicio.lc.guardar(p));
                limpiar();
            }
            else {
                MessageBox.Show(Inicio.lc.editar(p));
                this.Close();
            }


        }

        public void cargarplanes()
        {
            DataTable dt = new DataTable();
            dt = Inicio.lpl.listar();
            comboplanes.Text = "Seleccione...";
            foreach (DataRow fila in dt.Rows)
            {
                comboplanes.Items.Add(fila[0]);
            }
        }

        private void FormRegistraryActualizarCliente_Load(object sender, EventArgs e)
        {
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void txtpec_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtdir_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
