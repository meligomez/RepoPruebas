using Modelo.Comun;
using Modelo.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Cliente
{
	public partial class AltaCliente : Form
	{
		string rolLogueado;
        ConfigGlobal fech = new ConfigGlobal();
		public AltaCliente(string rol)
		{
			InitializeComponent();
            foreach (string tipo in Documento.string_docu)
                comboTipoDoc.Items.Add(tipo);
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

        public static bool nameIsValid(string name)
        {
            string expresion;
            expresion = "^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$";
            if (Regex.IsMatch(name, expresion))
            {
                if (Regex.Replace(name, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
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
			lblUsername.Text = textNroIdenficiacion.Text;
			lblUsername.Visible = true;
			lblPassword.Text = textNroIdenficiacion.Text;
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
            comboTipoTarj.Items.Add("DEBITO");
            comboTipoTarj.Items.Add("CREDITO");

		}
		private void limpiar()
		{
			textNombre.Text = "";
			textApellido.Text = "";
			textNroIdenficiacion.Text = "";
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
                if (true)
				{
					Usuario usuario = new Usuario();
					if (rolLogueado != "sin Rol")
					{
                       
						usuario.username = textNroIdenficiacion.Text;
						usuario.password = textNroIdenficiacion.Text;
						usuario.creadoPor = "admin";
					}
					
                    if (rolLogueado == "sin Rol")
                    {
                        usuariosCompletos();
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
                    cli.tipoDocumento = Documento.string_docu[comboTipoDoc.SelectedIndex];
                    cli.numeroDocumento = int.Parse(textNroIdenficiacion.Text);
					cli.mail = textMail.Text;
					cli.fechaNacimiento = dateTimePickerFechaNac.Value;
					cli.cuil = textCUIL.Text;
                    if (textTelefono.Text == "")
                    {
                        cli.telefono = -1;
                    }
                    else
                    {
                        cli.telefono = int.Parse(textTelefono.Text);
                    }
					
					usuario.fechaCreacionPsw = archivoDeConfig.getFechaSistema();
					dire.calle = textDireccion.Text;
                    if (textPiso.Text == "")
                    {
                        dire.piso = -1;
                    }
                    else
                    {
                        dire.piso = int.Parse(textPiso.Text);
                    }
                    if (textDepto.Text == "")
                    {
                        dire.dpto = " ";
                    }
                    else
                    {
                        dire.dpto = textDepto.Text;
                    }
					dire.localidad = textLocalidad.Text;
                    if (textCP.Text == "")
                    {
                        dire.cp = -1;
                    }
                    else
                    {
                        dire.cp = int.Parse(textCP.Text);
                    }
					 dire.numero = int.Parse(txtNro.Text);
					cli.Cli_Dir = dire;
					usuario.cliente = cli;
					tar.propietario = txtTarjProp.Text;
					tar.numero = txtTarjNum.Text;
					tar.fechaVencimiento = dateTimePickerVenc.Value;
                    tar.descripcion = Tarjeta.string_tipo[comboTipoTarj.SelectedIndex];
					cli.Cli_Tar = tar;
					//Alta del cliente
					int resp = usuario.Alta();
					if (resp == -1) 
					{
						MessageBox.Show("Error!. No se ha creado el Usuario.", "Error al crear Nuevo Usuario",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
                    if (resp == 7)
                    {
                        MessageBox.Show("Error!. No se ha creado el Usuario. DNI ingresado anteriormente.", "Error al crear Nuevo Usuario",
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

        public static bool emailIsValid(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        //public static bool emailIsValid(string email)
        //{
        //    string expresion;
        //    //expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
        //    expresion = "(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*)@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])";
        //    if (Regex.IsMatch(email, expresion))
        //    {
        //        if (Regex.Replace(email, expresion, string.Empty).Length == 0)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

		private bool todosCamposCompletos()
		{
            if (textNombre.Text.Trim() == "" || !nameIsValid(textNombre.Text))
			{
				MessageBox.Show("Debe ingresar un nombre válido", "Error al crear Nuevo Usuario",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			if (textApellido.Text.Trim() == "")
			{
                MessageBox.Show("Debe ingresar un apellido válido", "Error al crear Nuevo Usuario",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
            if (textMail.Text.Trim() == "" || !emailIsValid(textMail.Text))
			{
				MessageBox.Show("Debe ingresar un mail.", "Error al crear Nuevo Usuario",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
           
			if (textCUIL.Text.Trim() == "" )
			{
				MessageBox.Show("Debe ingresar un CUIL.", "Error al crear Nuevo Usuario",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
            
			if (dateTimePickerFechaNac.Value == null)
			{
				MessageBox.Show("Debe ingresar una fecha de nacimiento.", "Error al crear Nuevo Usuario",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
            if (textDireccion.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una calle.", "Error al crear Nuevo Usuario",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtNro.Text.Trim() == "" || txtNro.Text == null)
			{
                MessageBox.Show("Debe ingresar un numero de direccion.", "Error al crear Nuevo Usuario",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
           
			if (textNroIdenficiacion.Text.Trim() == "" || textNroIdenficiacion.Text == null)
			{
				MessageBox.Show("Debe ingresar un numero de DNI.", "Error al crear Nuevo Usuario",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
            if ((Convert.ToInt32(textNroIdenficiacion.Text) <= 11111111) || (Convert.ToInt32(textNroIdenficiacion.Text) > 99999999))
            {
                MessageBox.Show("Debe ingresar un numero de DNI Valido.   XXXXXXXX", "Error al crear Nuevo Usuario",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            

               
			if (textLocalidad.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una localidad.", "Error al crear Nuevo Usuario",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtTarjProp.Text.Trim() == "" || !nameIsValid(txtTarjProp.Text))
            {
                MessageBox.Show("Debe ingresar un propietario de tarjeta.", "Error al crear Nuevo Usuario",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtTarjNum.Text.Trim() == "" )
            {
                MessageBox.Show("Debe ingresar un numero de tarjeta.", "Error al crear Nuevo Usuario",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtTarjNum.Text.Length != 16)
            {
                MessageBox.Show("Debe ingresar un numero de tarjeta valido. XXXX-XXXX-XXXX-XXXX, SIN '-' ", "Error al crear Nuevo Usuario",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textCUIL.Text.Length != 11)
            {
                MessageBox.Show("Debe ingresar un numero de Cuil valido. XX-DNI-X, SIN '-' ", "Error al crear Nuevo Usuario",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }   
            else
            {
                if ((Convert.ToInt64(txtTarjNum.Text) <= 0000000000000000) || (Convert.ToInt64(txtTarjNum.Text) > 9999999999999999))
                {
                    MessageBox.Show("Debe ingresar un numero de tarjeta valido. XXXXXXXXXXXXXXXX ", "Error al crear Nuevo Usuario",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            if (dateTimePickerVenc.Value == null)
			{
				MessageBox.Show("Debe ingresar una fecha de nacimiento.", "Error al crear Nuevo Usuario",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
            DateTime hoy = fech.getFechaSistema();
            if (hoy < dateTimePickerFechaNac.Value.Date)
            {
                MessageBox.Show("La fecha de nacimiento debe ser anterior al dia actual");
                return false;
            }
            if (hoy>dateTimePickerVenc.Value.Date)
            {
                MessageBox.Show("La fecha de vencimiento debe ser posterior al dia actual");
                return false;
            }
            Usuario usuario = new Usuario();
            if (rolLogueado != "sin Rol")
            {
                usuario.username = textNroIdenficiacion.Text;
                usuario.password = textNroIdenficiacion.Text;
                usuario.creadoPor = "admin";
            }
            return true;
		}
        private bool usuariosCompletos()
        {
            if (textUsername.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una contraseña.", "Error al crear Nuevo Usuario",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textPassword.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una contraseña.", "Error al crear Nuevo Usuario",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

		private void btnVolver_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

		private void txtNro_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
