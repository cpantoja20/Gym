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
    public partial class FormRegistraryActualizarProducto : Form
    {
        private string ideditar = "";
        public FormRegistraryActualizarProducto()
        {
            InitializeComponent();
        }

        public void cargarproducto(Producto p)
        {
            ideditar = p.id;
            labelid.Text = "Id : " + p.id;
            txtnom.Text = p.nombre;
            txtdes.Text = p.descripcion;
            txtcan.Text = p.cantidad.ToString();
            txtprecomp.Text = p.precio_compra.ToString();
            txtpreven.Text = p.precio_venta.ToString();
        }

        public void limpiar()
        {
            labelid.Text = "Id";
            txtnom.Text = "";
            txtdes.Text = "";
            txtcan.Text = "";
            txtprecomp.Text = "";
            txtpreven.Text = "";
         }

        public void guardar()
        {
            //Miro si ya existe el cliente
            //si ya existe entonces lo va a editar
            //sino lo va a guardar

            Producto p = new Producto();
            p.id = ideditar;
            p.nombre = txtnom.Text;
            p.descripcion = txtdes.Text;
            p.cantidad = int.Parse(txtcan.Text);
            p.precio_compra = Decimal.Parse(txtprecomp.Text);
            p.precio_venta = Decimal.Parse(txtpreven.Text);
            if (Inicio.lpr.buscar(ideditar) == null)
            {
                MessageBox.Show(Inicio.lpr.guardar(p));
                limpiar();
            }
            else
            {
                MessageBox.Show(Inicio.lpr.editar(p));
                this.Close();
            }


        }

        private void FormRegistraryActualizarProducto_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtpreven_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtcan_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtnom_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtprecomp_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            guardar();
        }
    }
}
