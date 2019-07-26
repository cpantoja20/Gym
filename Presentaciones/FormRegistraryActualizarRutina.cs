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
    
    public partial class FormRegistraryActualizarRutina : Form
    {
        private string ideditar = "";
        public FormRegistraryActualizarRutina()
        {
            InitializeComponent();
        }

        public void cargarrutina(Rutina p)
        {
            ideditar = p.id;
            labelid.Text = "Id : " + p.id;
            txtnom.Text = p.nombre;
            txtdes.Text = p.descripcion;
           
        }

        public void limpiar()
        {
            labelid.Text = "Id";
            txtnom.Text = "";
            txtdes.Text = "";
           
        }

        public void guardar()
        {
            //Miro si ya existe el cliente
            //si ya existe entonces lo va a editar
            //sino lo va a guardar

            Rutina p = new Rutina();
            p.id = ideditar;
            p.nombre = txtnom.Text;
            p.descripcion = txtdes.Text;
           
            if (Inicio.lru.buscar(ideditar) == null)
            {
                MessageBox.Show(Inicio.lru.guardar(p));
                limpiar();
            }
            else
            {
                MessageBox.Show(Inicio.lru.editar(p));
                this.Close();
            }


        }

        private void FormRegistraryActualizarRutina_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            guardar();
        }
    }
}
