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
    public partial class FormPagarMensualidad : Form
    {
        public FormPagarMensualidad()
        {
            InitializeComponent();
        }

        private void comboclientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cedula = comboclientes.Text;
            if (Inicio.lc.buscar(cedula) != null)
            {
                Cliente p = new Cliente();
                p = Inicio.lc.buscar(cedula);
                Plan plan = new Plan();
                plan = Inicio.lpl.buscar(p.idPlan);
                labelinfocliente.Text = " Nombre: " + p.nombre +
                    " \n Telefono: " + p.telefono + 
                    " \n Direccion: " + p.direccion + 
                    " \n Plan : " + plan.id+" - "+ plan.nombre +
                    " \n Valor del Plan : " + plan.precio;
            }
            else
            {
                labelinfocliente.Text = "";
            }
        }



        private void comboopcionpago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboopcionpago.Text=="Pago completo")
            {
                
                Cliente p = new Cliente();
                p = Inicio.lc.buscar(comboclientes.Text);
                Plan plan = new Plan();
                plan = Inicio.lpl.buscar(p.idPlan);
                txtval.Enabled = false;
                txtval.Value = plan.precio;

            }
            else if (comboopcionpago.Text == "Abono")
            {
                txtval.Value = 0;
                txtval.Enabled = true;
            }
            else
            {
                txtval.Value = 0;
                txtval.Enabled = false;
            }
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
        
        public void cargartabla()
        {
            tabla.DataSource = Inicio.lpa.listar();

        }


        public void hacerPago()
        {
            Pago p = new Pago();
            p.cliente = Inicio.lc.buscar(comboclientes.Text);
            p.forma_de_pago = comboformapago.Text;
            p.opcion_de_pago = comboopcionpago.Text;
            p.valor = Double.Parse(txtval.Value.ToString());
            MessageBox.Show(Inicio.lpa.guardar(p));
            limpiar();
            cargartabla();

        }

        public void limpiar()
        {
            comboclientes.Text = "Seleccione...";
            labelinfocliente.Text = "";
            comboformapago.Text = "Seleccione...";
            comboopcionpago.Text = "Seleccione...";
            txtval.Value = 0;
            txtval.Enabled = false;
        }

        private void FormPagarMensualidad_Load(object sender, EventArgs e)
        {
            cargarclientes();
            cargartabla();
        }

        private void txtval_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            hacerPago();
        }
    }
}
