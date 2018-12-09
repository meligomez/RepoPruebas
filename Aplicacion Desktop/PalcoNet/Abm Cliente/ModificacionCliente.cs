using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Cliente
{
	public partial class ModificacionCliente : Form
	{
		public ModificacionCliente()
		{
			InitializeComponent();
		}

		private void textNroIdentificacion_TextChanged(object sender, EventArgs e)
		{

		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
	}
}
