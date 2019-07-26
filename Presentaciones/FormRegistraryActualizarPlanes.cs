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
    public partial class FormRegistraryActualizarPlanes : Form
    {
        private string ideditar = "";
        public FormRegistraryActualizarPlanes()
        {
            InitializeComponent();
        }

        private void labelid_Click(object sender, EventArgs e)
        {

        }

        public void cargarplan(Plan p)
        {
            ideditar = p.id;
            txtid.Text = p.id;
            txtnom.Text = p.nombre;
            txtpre.Text = p.precio.ToString();
            txtdur.Text = p.duracion;
            cargarrutinas();
            foreach (Rutina rutina in p.rutinas)
            {
                object[] fila = new string[] { rutina.id, rutina.nombre, rutina.descripcion };
                tabla.Rows.Add(fila);
            }
            
        }

        private void btnagregarrutina_Click(object sender, EventArgs e)
        {
            string id = comborutinas.Text;
            if (Inicio.lru.buscar(id) != null)
            {
                Rutina p = Inicio.lru.buscar(id);
                object[] fila = new string[] { p.id, p.nombre, p.descripcion};
                tabla.Rows.Add(fila);
            }
            else
            {
                MessageBox.Show("Debe seleccionar una rutina valida");
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tabla.SelectedRows.Count > 0)
            {
                tabla.Rows.RemoveAt(tabla.CurrentRow.Index);
            }
            else { }
            }

        public void cargarrutinas()
        {
            comborutinas.Items.Clear();
            DataTable dt = new DataTable();
            dt = Inicio.lru.listar();
            comborutinas.Text = "Seleccione...";
            foreach (DataRow fila in dt.Rows)
            {
                comborutinas.Items.Add(fila[0]);
            }
        }
        private void FormRegistraryActualizarPlanes_Load(object sender, EventArgs e)
        {
            cargarrutinas();
        }

        private void comborutinas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = comborutinas.Text;
            if (Inicio.lru.buscar(id) != null)
            {
                labelnomrutina.Text = Inicio.lru.buscar(id).nombre;
            }
            else
            {
                labelnomrutina.Text = "";
            }
        }

        public List<Rutina> llenarlistarutinas()
        {
            List<Rutina> lista = new List<Rutina>();

            foreach (DataGridViewRow fila in tabla.Rows)
            {
                Rutina p = new Rutina();
                p.id = fila.Cells[0].Value.ToString();
                p.nombre = fila.Cells[1].Value.ToString();
                p.descripcion = fila.Cells[2].Value.ToString();
                lista.Add(p);
            }
            return lista;
        }
        public void limpiar()
        {
            txtid.Text = "";
            labelnomrutina.Text = "";
            txtnom.Text = "";
            txtpre.Text = "";
            txtdur.Text = "";
            tabla.Rows.Clear();
        }

        public void guardar()
        {

            Plan p = new Plan();
            p.id = txtid.Text;
            p.nombre = txtnom.Text; 
            p.precio = Decimal.Parse(txtpre.Text);
            p.duracion = txtdur.Text;
            p.rutinas = llenarlistarutinas();

            if (ideditar=="")
            {
                MessageBox.Show(Inicio.lpl.guardar(p));
                limpiar();
            }
            else
            {
                MessageBox.Show(Inicio.lpl.editar(p,ideditar));
                this.Close();
            }

        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            guardar();
        }
    }
}
