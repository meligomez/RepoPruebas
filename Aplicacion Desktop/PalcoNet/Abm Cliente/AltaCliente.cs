using Modelo.Comun;
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

namespace PalcoNet.Abm_Cliente
{
	public partial class AltaCliente : Form
	{
		string rolLogueado;
		public AltaCliente(string rol)
		{
			InitializeComponent();
			ConfigGlobal cg = new ConfigGlobal();
			DateTime fechaSistema = cg.getFechaSistema();
			lblFechaSistema.Visible = true;
			lblFechaSistema.Text = fechaSistema.ToString();
			rolLogueado = rol;
			if (rolLogueado != "sin Rol")
			{
				textUsername.ReadOnly = true;
				textUsername.Visible = false;
				textUsername.BackColor = System.Drawing.SystemColors.Window;
				textPassword.ReadOnly = true;
				textPassword.Visible = false;
				textPassword.BackColor = System.Drawing.SystemColors.Window;
				labelUser.Text = "Usuario y Password creadas por defecto.";
			}
			else
			{
				lblUsername.Visible = false;
				lblPassword.Visible = false;

			}
		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}

		private void label5_Click(object sender, EventArgs e)
		{

		}
		private void labelUserEscribir(object sender, EventArgs e)
		{
			if (rolLogueado != "sin Rol")
			{
			lblUsername.Text = textNroIdentificacion.Text;
			lblUsername.Visible = true;
			lblPassword.Text = textNroIdentificacion.Text;
			lblPassword.Visible = true;
			}
			else
			{
				lblUsername.Visible = false;
				lblPassword.Visible = false;
			}
		}


		private void textDireccion_TextChanged(object sender, EventArgs e)
		{

		}

		private void label13_Click(object sender, EventArgs e)
		{

		}

		private void AltaCliente_Load(object sender, EventArgs e)
		{
			

		}
		private void limpiar()
		{
			textNombre.Text = "";
			textApellido.Text = "";
			txtTipoDoc.Text = "";
			textNroIdentificacion.Text = "";
			dateTimePickerFechaNac.Text = "";
			textMail.Text = "";
			textCUIL.Text = "";
			textTelefono.Text = "";
			textDireccion.Text = "";
			txtNro.Text = "";
			textDepto.Text = "";
			textPiso.Text = "";
			textLocalidad.Text = "";
			textCP.Text = "";
			txtTarjProp.Text = "";
			txtTarjNum.Text = "";
			dateTimePickerVenc.Text = "";
		}
		private void btnGuardar_Click(object sender, EventArgs e)
		{
			try
			{
				if (todosCamposCompletos())
				{
					Usuario usuario = new Usuario();
					if (rolLogueado != "sin Rol")
					{
						usuario.username = textNroIdentificacion.Text;
						usuario.password = textNroIdentificacion.Text;
						usuario.creadoPor = "admin";
					}
					else
					{
						usuario.username = textUsername.Text;
						usuario.password = textPassword.Text;
						usuario.creadoPor = "cliente";
					}
					//Carga de datos
					Domicilio dire = new Domicilio();
					Cliente cli = new Cliente();
					Tarjeta tar = new Tarjeta();
					ConfigGlobal archivoDeConfig = new ConfigGlobal();
					cli.apellido = textApellido.Text;
					cli.nombre = textNombre.Text;
					cli.tipoDocumento = txtTipoDoc.Text;
					cli.numeroDocumento = int.Parse(textNroIdentificacion.Text);
					cli.mail = textMail.Text;
					cli.fechaNacimiento = dateTimePickerFechaNac.Value;
					cli.cuil = textCUIL.Text;
					cli.telefono = int.Parse(textTelefono.Text);
					usuario.fechaCreacionPsw = archivoDeConfig.getFechaSistema();
					dire.calle = textDireccion.Text;
					dire.piso = int.Parse(textPiso.Text);
					dire.dpto = textDepto.Text;
					dire.localidad = textLocalidad.Text;
					dire.cp = int.Parse(textCP.Text);
					dire.numero = int.Parse(txtNro.Text);
					cli.Cli_Dir = dire;
					usuario.cliente = cli;
					tar.propietario = txtTarjProp.Text;
					tar.numero = txtTarjNum.Text;
					tar.fechaVencimiento = dateTimePickerVenc.Value;
					cli.Cli_Tar = tar;
					//Alta del cliente
					int resp = usuario.Alta();
					if (resp != 0)
					{
						MessageBox.Show("Error!. No se ha creado el Usuario.", "Error al crear Nuevo Usuario",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
					if (rolLogueado != "sin Rol")
					{
						MessageBox.Show("Cliente " + textNombre.Text + " creado, tiene hasta el día " + (usuario.fechaCreacionPsw.AddDays(2)) + " Para cambiar la password creada por defecto.", "Usuario Creado",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
						limpiar();
					}
					else
					{
						MessageBox.Show("Cliente " + textNombre.Text + " creado", "Usuario Creado",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
						limpiar();
					}
				}


			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message, "ERROR", MessageBoxButtons.OK);
			}
		}
		private bool todosCamposCompletos()
		{
			//if (textNombre.Text.Trim() == "")
			//{
			//	MessageBox.Show("Debe ingresar un nombre.", "Error al crear Nuevo Usuario",
			//			MessageBoxButtons.OK, MessageBoxIcon.Error);
			//	return false;
			//}
			//if (textApellido.Text.Trim() == "")
			//{
			//	MessageBox.Show("Debe ingresar un apellido.", "Error al crear Nuevo Usuario",
			//			MessageBoxButtons.OK, MessageBoxIcon.Error);
			//	return false;
			//}
			//if (textMail.Text.Trim() == "")
			//{
			//	MessageBox.Show("Debe ingresar un mail.", "Error al crear Nuevo Usuario",
			//			MessageBoxButtons.OK, MessageBoxIcon.Error);
			//	return false;
			//}
			//if (textPassword.Text.Trim() == "")
			//{
			//	MessageBox.Show("Debe ingresar una contraseña.", "Error al crear Nuevo Usuario",
			//			MessageBoxButtons.OK, MessageBoxIcon.Error);
			//	return false;
			//}
			//if (textCUIL.Text.Trim() == "" )
			//{
			//	MessageBox.Show("Debe ingresar un CUIL.", "Error al crear Nuevo Usuario",
			//			MessageBoxButtons.OK, MessageBoxIcon.Error);
			//	return false;
			//}
			//if (dateTimePickerFechaNac.Value == null)
			//{
			//	MessageBox.Show("Debe ingresar una fecha de nacimiento.", "Error al crear Nuevo Usuario",
			//			MessageBoxButtons.OK, MessageBoxIcon.Error);
			//	return false;
			//}
			return true;
		}

		private void btnVolver_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
	}
}
