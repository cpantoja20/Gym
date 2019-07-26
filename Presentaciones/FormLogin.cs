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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtced_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizarTabla_Click(object sender, EventArgs e)
        {
            if (txtusu.Text=="admin" && txtcon.Text == "admin123")
            {
                MessageBox.Show("BIENVENIDO A GIMNASIO BETO'sGYM");
                FormMenu p = new FormMenu();
                p.Show();
                this.Visible=false;
            }
            else
            {
                MessageBox.Show("NOMBRE DE USUARIO O CONTRASEÑA INCORRECTOS");
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
    }
}
