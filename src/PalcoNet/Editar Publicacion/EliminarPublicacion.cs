using Modelo.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Editar_Publicacion
{
	public partial class EliminarPublicacion : Form
	{
		Publicacion publicacion = new Publicacion();
		public EliminarPublicacion(Publicacion p)
		{
			publicacion = p;
			InitializeComponent();
		}

		private void EliminarPublicacion_Load(object sender, EventArgs e)
		{
			Grado gr = new Grado();
			lblCodigo.Text = publicacion.codigo.ToString();
			lblDescripcion.Text = publicacion.descripcion.ToString();
			lblDireccion.Text = publicacion.direccion.ToString();
			lblEmpresa.Text = publicacion.empresaId;
			//lblEstado.Text = publicacion.estado;
			lblFechaEspectaculo.Text = publicacion.fechaEspectaculo.ToString();
			lblFechaPublicacion.Text = publicacion.fechaPublicacion.ToString();
			//lblGradoPublicacion.Text=gr.
			//lblRubro.Text=publicacion.rubroId
			lblStock.Text = publicacion.stock.ToString();
		
		}

		private void btnEliminar_Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("¿Desea eliminar la publicacion?  ",
				"", MessageBoxButtons.YesNo);
			switch (dr)
			{
				case DialogResult.Yes:
					if (publicacion.eliminar())
					{
						MessageBox.Show("Correcto! Se eliminó la publicacion");
						this.Hide();
					}
					else
					{
						MessageBox.Show("Error, no se pudo eliminar la publicacion.");
						this.Hide();
					}
					break;

				case DialogResult.No:
					this.Hide();
					break;
			}
		}

		private void btnVolver_Click(object sender, EventArgs e)
		{
			this.Hide();
		}
	}
}
