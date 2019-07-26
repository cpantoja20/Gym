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
    public partial class FormReportes : Form
    {
        public FormReportes()
        {
            InitializeComponent();
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            
            string fechainicial = txtfec1.Value.Year.ToString() +"-"+ txtfec1.Value.Month.ToString()+"-"+txtfec1.Value.Day.ToString();
            string fechafinal = txtfec2.Value.Year.ToString() + "-" + txtfec2.Value.Month.ToString() + "-" + (txtfec2.Value.Day+1).ToString();
           
            tabla1.DataSource = Inicio.lve.listarVentasPorFecha(fechainicial, fechafinal);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
        public void cargartop10productosmasvendidos()
        {
            tabla2.DataSource = Inicio.lpr.top10masvendidos();
        }

        public void cargartop10planesmasescogidos()
        {
            tabla3.DataSource = Inicio.lpl.top10masescogidos();
        }
        private void FormReportes_Load(object sender, EventArgs e)
        {
            cargartop10productosmasvendidos();
            cargartop10planesmasescogidos();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
        }
    }
}
