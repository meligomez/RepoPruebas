using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization;

namespace PalcoNet.Listado_Estadistico
{
    public partial class ListadoEstadistico : Form
    {

		int vContadorDatos = 0;
		public ListadoEstadistico()
        {
            InitializeComponent();
        }

		private void ListadoEstadistico_Load(object sender, EventArgs e)
		{

		}

		private void btnFiltroFecha_Click(object sender, EventArgs e)
		{
			grafico.Visible = true;
			dataGridView1.Visible = true;
		}
		private void anioChange(object sender, EventArgs e)
		{
			lblTrimestre.Visible = true;
			cbxTrimestre.Visible = true;
		}
	}
}
