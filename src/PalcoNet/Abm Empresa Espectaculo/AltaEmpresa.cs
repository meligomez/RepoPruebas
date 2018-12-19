using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo.Comun;
using Modelo.Dominio;
using System.Text.RegularExpressions;


namespace PalcoNet.Abm_Empresa_Espectaculo
{
	public partial class AltaEmpresa : Form
	{

        string rolLogueado;
        Usuario usuario = new Usuario();
        ConfigGlobal archivoDeConfig = new ConfigGlobal();

		public AltaEmpresa(string rol)
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

        private void labelUserEscribir(object sender, EventArgs e)
        {
            if (rolLogueado != "sin Rol")
            {
                lblUsername.Text = textCUIT.Text;
                lblUsername.Visible = true;
                lblPassword.Text = textCUIT.Text;
                lblPassword.Visible = true;
                usuario.creadoPor = "admin";
            }
            else
            {
                lblUsername.Visible = false;
                lblPassword.Visible = false;
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (todosCamposCompletos())
                //if (true)
                {
                    Usuario usuario = new Usuario();
                    if (rolLogueado != "sin Rol")
                    {
                        usuario.username = textCUIT.Text;
                        usuario.password = textCUIT.Text;
                        usuario.creadoPor = "admin";
                    }
                    else
                    {
                        usuario.username = textUsername.Text;
                        usuario.password = textPassword.Text;
                        usuario.creadoPor = "empresa";
                    }
                    Empresa empresa = new Empresa();
                    Domicilio dom = new Domicilio();
                    dom.piso = -1;
                    dom.dpto = "";
                    dom.localidad = "";
                    dom.cp = -1;
                    empresa.Empresa_telefono = -1;
                    empresa.Empresa_Cuit = textCUIT.Text;
                    empresa.Empresa_mail = textMail.Text;
                    if (textTelefono.Text != "")
                    empresa.Empresa_telefono = int.Parse(textTelefono.Text);
                    empresa.Empresa_razon_social = "RAZON SOCIAL Nº:" + textRazonSocial.Text;
                    empresa.Empresa_estado = true;
                    usuario.fechaCreacionPsw = archivoDeConfig.getFechaSistema();
                    dom.calle = textDireccion.Text;
                    dom.numero = int.Parse(txtNro.Text);
                    if (textPiso.Text != "")
                    dom.piso = int.Parse(textPiso.Text);
                    if (textDepto.Text != "")
                    dom.dpto = textDepto.Text;
                    dom.localidad = textLocalidad.Text;
                    if (textCP.Text != "")
                    dom.cp = int.Parse(textCP.Text);
                    dom.ciudad = textCiudad.Text;
                    empresa.Empresa_Dom = dom;
                    usuario.empresa = empresa;
                    int resp = usuario.AltaEmpresa();
                    if (resp == -1)
                    {
                        MessageBox.Show("Error al conectarse con la DB. No se ha creado el Usuario.", "Error al crear Nuevo Usuario",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (resp == 5)
                    {
                        MessageBox.Show("Error. No se ha creado el Usuario. El cuit o Razon Social Ya han sido creados anteriormente!", "Error al crear Nuevo Usuario",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show("Empresa: " + textCUIT.Text + " creada satisfactoriamente.", "Alta de Usuario",
                 MessageBoxButtons.OK);
                    limpiar();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ERROR", MessageBoxButtons.OK);
            }
        }

        private void limpiar()
        {
            textRazonSocial.Text = "";
            textCUIT.Text = "";
            textTelefono.Text = "";
            textMail.Text = "";
            textCiudad.Text = "";
            textDireccion.Text = "";
            txtNro.Text = "";
            textLocalidad.Text = "";
            textPiso.Text = "";
            textDepto.Text = "";
            textCP.Text = "";

        }

        public static bool emailIsValid(string email)
        {
            string expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
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
    private bool todosCamposCompletos()
        {
            int value;
            if (textRazonSocial.Text.Trim() == "" || !int.TryParse(textRazonSocial.Text, out value))
            {
            	MessageBox.Show("Debe ingresar una RAZON SOCIAL.", "Error al crear Nueva empresa",
            			MessageBoxButtons.OK, MessageBoxIcon.Error);
            	return false;
            }
            if (textCUIT.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un CUIT.", "Error al crear Nueva empresa",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //if (textTelefono.Text.Trim() == "")
            //{
            //    MessageBox.Show("Debe ingresar un TELEFONO.", "Error al crear Nueva empresa",
            //            MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}
            if (textMail.Text.Trim() == "" || !emailIsValid(textMail.Text))
            {
                MessageBox.Show("Debe ingresar un MAIL valido.", "Error al crear Nueva empresa",
            			MessageBoxButtons.OK, MessageBoxIcon.Error);
            	return false;
            }
            
            if (textCiudad.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una CIUDAD.", "Error al crear Nueva empresa",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textDireccion.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una DIRECCIÓN.", "Error al crear Nueva empresa",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtNro.Text.Trim() == "" || !int.TryParse(txtNro.Text, out value))
            {
                MessageBox.Show("Debe ingresar un EL NUMERO DE DIRECCÍON.", "Error al crear Nueva empresa",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //if (textPiso.Text.Trim() == "" || !int.TryParse(textPiso.Text, out value))
            //{
            //    MessageBox.Show("Debe ingresar EL PISO .", "Error al crear Nueva empresa",
            //            MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}
            //if (textDepto.Text.Trim() == "")
            //{
            //    MessageBox.Show("Debe ingresar el DEPARTAMENTO.", "Error al crear Nueva empresa",
            //            MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}
            //if (textLocalidad.Text.Trim() == "")
            //{
            //    MessageBox.Show("Debe ingresar la LOCALIDAD.", "Error al crear Nueva empresa",
            //            MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}
           if (textCP.Text.Trim() != "" && !int.TryParse(textCP.Text, out value))
            {
                MessageBox.Show("Debe ingresar el CODIGO POSTAL.", "Error al crear Nueva empresa",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }    
        
			return true;
		}

    private void btnVolver_Click(object sender, EventArgs e)
    {
        this.Hide();

    }

    private void AltaEmpresa_Load(object sender, EventArgs e)
    {

    }

		private void textCUIT_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
		{

		}

        private void label9_Click(object sender, EventArgs e)
        {

        }
	}
    

        }
