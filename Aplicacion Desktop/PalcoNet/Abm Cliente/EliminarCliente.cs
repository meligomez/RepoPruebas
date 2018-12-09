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
	public partial class EliminarCliente : Form
	{
		public EliminarCliente()
		{
			InitializeComponent();
		}

		private void btCancelar_Click(object sender, EventArgs e)
		{
			this.Hide();
		}
	}
}
