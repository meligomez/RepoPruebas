using Modelo.Base;
using Modelo.Comun;
using Modelo.Dominio;
using PalcoNet.VentanasPorRol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Generar_Publicacion
{
	public partial class GenerarPublicacion : Form
	{
		public Usuario userLogueado;
		public Panel panel;
		public GenerarPublicacion(Usuario userLog,Panel panel1)
		{
			panel = panel1;
			userLogueado = userLog;
			InitializeComponent();
	
		}
		


		private void CategoriaUbicacion_Load(object sender, EventArgs e)
		{
			//Necesito en empresa un metodo que dado el id me devuelva la razon social.
			DataTable dtGrado = new DataTable();
			DataTable dtRubro = new DataTable();
			DataTable dtTipoUbicacion = new DataTable();
			DaoSP dao = new DaoSP();
			dtGrado = dao.ConsultarConQuery("SELECT id, tipo FROM dropeadores.Grado");
			dtRubro = dao.ConsultarConQuery("SELECT Codigo,Descripcion FROM dropeadores.Rubro");
			dtTipoUbicacion = dao.ConsultarConQuery("select distinct Ubicacion_Tipo_Descripcion,Ubicacion_Tipo_Codigo as Codigo from gd_esquema.Maestra");
			CargarData.cargarComboBox(comboRubro, dtRubro, "Codigo", "Descripcion");
			CargarData.cargarComboBox(comboGradoPublicacion, dtGrado, "id", "tipo");
			//CargarData.cargarComboBox(comboBox1, dtTipoUbicacion, "Ubicacion_Tipo_Descripcion", "Ubicacion_Tipo_Descripcion");
			lblEstado.Visible = true;
			lblUserLogueado.Visible = true;
			//BUSCAR LA EMPRESAAAA!!
			lblUserLogueado.Text = userLogueado.empresa.Empresa_Cuit;
			lblEstado.Text = "Borrador";
			dateTimePickerEspectaculo.Format = DateTimePickerFormat.Custom;
			dateTimePickerEspectaculo.CustomFormat = "MM/dd/yyyy hh:mm:ss";

		}

		private void changeRadioButton(object sender, EventArgs e)
		{
			groupBox1.Visible = false;
			if (radioNo.Checked)
			{
				lblFechaEspectaculo.Visible = true;
				dateTimePickerEspectaculo.Visible = true;
			}
		}

		private void btnSiguiente_Click(object sender, EventArgs e)
		{
			if (this.validarData())
			{
				Publicacion publicacion = new Publicacion();
				publicacion.estado = 0;
				publicacion.descripcion = textDescripcion.Text;
				publicacion.direccion = textDireccion.Text;
				publicacion.rubroId = int.Parse(comboRubro.SelectedValue.ToString());
				publicacion.gradoId = int.Parse(comboGradoPublicacion.SelectedValue.ToString());
				publicacion.stock = int.Parse(textStock.Text);
				publicacion.fechaPublicacion = dateTimePickerPublicacion.Value;
				publicacion.empresaId = userLogueado.empresa.Empresa_Cuit;
				if (radioNo.Checked)
				{
					publicacion.fechaEspectaculo = dateTimePickerEspectaculo.Value;
					//dateTimePickerEspectaculo.Value.Hour;
				}
				else
				{
					//lo hace javier.
				}
				try
				{
					int idPublicacionInsertado = 0;
					idPublicacionInsertado = publicacion.altaPublicacion();
					publicacion.codigo = idPublicacionInsertado;
					if (idPublicacionInsertado>0)
					{
						CategoriaUbicacion categoria = new CategoriaUbicacion(userLogueado, publicacion);
						categoria.Dock = DockStyle.Fill;
						categoria.TopLevel = false;
						categoria.FormBorderStyle = FormBorderStyle.None;
						this.panel.Controls.Add(categoria);
						this.panel.Tag = categoria;
						categoria.Show();

						this.Hide();
					}
					else
					{
						MessageBox.Show("Error..", "¡Advertencia!",
							MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					
					}
					//if (textDescripcion.Text=="")
					//{
				

				}
				catch (Exception ex)
				{

					throw ex;
				}

			}


		}

		private bool validarData()
		{
			if (radioNo.Checked == false && radioSi.Checked == false)
			{
				MessageBox.Show("Debe seleccionar al menos una opción para la fecha del Espectáculo.", "¡Advertencia!",
				MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			//if (textDescripcion.Text=="")
			//{
			//	MessageBox.Show("Debe escribir una descripcion.", "¡Advertencia!",
			//	MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			//	return false;
			//}
			//if (textDireccion.Text == "")
			//{
			//	MessageBox.Show("Debe escribir una direccion del espectáculo.", "¡Advertencia!",
			//	MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			//	return false;
			//}
			if (comboGradoPublicacion.SelectedIndex==0)
			{
				MessageBox.Show("Debe seleccionar un Grado de publicacion", "¡Advertencia!",
				MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			if (comboRubro.SelectedIndex==0)
			{
				MessageBox.Show("Debe seleccionar un Rubro.", "¡Advertencia!",
				MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			if (textStock.Text == "")
			{
				MessageBox.Show("Ingrese algún stock.", "¡Advertencia!",
				MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			if (textStock.Text == "")
			{
				MessageBox.Show("Ingrese algún stock.", "¡Advertencia!",
				MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			if (int.Parse(textStock.Text.ToString()) > 100)
			{
				MessageBox.Show("La máxima cantidad de stock es 100", "¡Advertencia!",
				MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			if (int.Parse(textStock.Text.ToString()) <= 0)
			{
				MessageBox.Show("La mínima cantidad de stock es 10", "¡Advertencia!",
				MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			if (int.Parse(textStock.Text.ToString()) %10 !=0)
			{
				MessageBox.Show("El stock debe ser múltiplo de 10", "¡Advertencia!",
				MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			return true;
		}

		private void cuandoCambia(object sender, KeyPressEventArgs e)
		{
			if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
			{
				MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				e.Handled = true;
				return;
			}
		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}

		private void btnVolver_Click(object sender, EventArgs e)
		{
			this.Hide();
		}
	}
}
