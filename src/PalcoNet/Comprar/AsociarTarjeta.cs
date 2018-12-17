using Modelo.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Comprar
{
	public partial class AsociarTarjeta : Form
	{
		Usuario user = new Usuario();
        ConfigGlobal fech = new ConfigGlobal();
		public AsociarTarjeta(Usuario usuario)
		{
			InitializeComponent();
			user = usuario;
			comboTipoTarj.Items.Add("DEBITO");
			comboTipoTarj.Items.Add("CREDITO");
		}

		private void AsociarTarjeta_Load(object sender, EventArgs e)
		{

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
        private bool validarDatos()
        {
            if (txtTarjProp.Text.Trim() == "" || !nameIsValid(txtTarjProp.Text))
            {
                MessageBox.Show("Debe ingresar un propietario de tarjeta.", "Error al crear Nuevo Usuario",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtTarjNum.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un numero de tarjeta.", "Error al crear Nuevo Usuario",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            DateTime hoy = fech.getFechaSistema();
           
            if (hoy > dateTimePickerVenc.Value.Date)
            {
                MessageBox.Show("La fecha de vencimiento debe ser posterior al dia actual");
                return false;
            }
            if (txtTarjNum.Text.Length != 16)
            {
                MessageBox.Show("Debe ingresar un numero de tarjeta valido. XXXX-XXXX-XXXX-XXXX, SIN '-' ", "Error al crear Nuevo Usuario",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
           
        }
		private void btnGuardar_Click(object sender, EventArgs e)
		{
			Cliente cli = new Cliente();
			Tarjeta tar = new Tarjeta();
			tar.propietario = txtTarjProp.Text;
			tar.numero = txtTarjNum.Text;
			tar.fechaVencimiento = dateTimePickerVenc.Value;
			tar.descripcion = Tarjeta.string_tipo[comboTipoTarj.SelectedIndex];
			cli.numeroDocumento = user.cliente.numeroDocumento;
			cli.Cli_Tar = tar;
            if (validarDatos())
            {
                int resp = Cliente.updateTarj(cli);

                if (resp != 0)
                {
                    MessageBox.Show("Error!. No se ha creado la tarjeta correctamente.", "Error al actualizar Nueva tajeta",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Tarjeta del cliente " + txtTarjProp.Text + " creado correctamente", "Usuario Creado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                }
            }
		}
	}
}
