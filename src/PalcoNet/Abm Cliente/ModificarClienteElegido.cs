using Modelo.Base;
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

namespace PalcoNet.Abm_Cliente
{
	public partial class ModificarClienteElegido : Form
	{
		Cliente cliente_seleccionado;
        ConfigGlobal fech = new ConfigGlobal();
        int nroDOCViejo = 0;
		public ModificarClienteElegido(string tipoDoc, int nroDoc)
		{
			InitializeComponent();
			DaoSP dao = new DaoSP();
			cliente_seleccionado = obtener(tipoDoc, nroDoc);
			if (cliente_seleccionado == null)
			{
				MessageBox.Show("Error al cargar el cliente.", "Error al Modificar Cliente",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Dispose();
			}

			foreach (string tipo in Documento.string_docu)
				comboTipoDoc.Items.Add(tipo);
            nroDOCViejo = Convert.ToInt32(cliente_seleccionado.numeroDocumento);
            txtNroIdentificacion.ReadOnly = true;
           // txtNroIdentificacion.Visible = false;
           txtNroIdentificacion.BackColor = System.Drawing.SystemColors.Window;
		}

		private void ModificarClienteElegido_Load(object sender, EventArgs e)
		{
			cargarDatos();
		}
		 public static DataTable obtenerTabla(string tipoDoc, int nroDoc)
        {

            DaoSP dao = new DaoSP();
              return dao.ObtenerDatosSP("dropeadores.ObtenerClienteEspecifico", tipoDoc, nroDoc);
        }

        public static Cliente obtener(string tipoDoc, int nroDoc)
        {
            List<Cliente> lista = transductor(obtenerTabla(tipoDoc, nroDoc));
            if (lista.Count == 0)
                return null;
            return lista[0];
        }
        public static List<Cliente> transductor(DataTable tabla)
        {
            List<Cliente> lista = new List<Cliente>();
            DaoSP dao = new DaoSP();
            foreach (DataRow fila in tabla.Rows)
            {
                Domicilio dom = new Domicilio();
                ConfigGlobal archivoDeConfig = new ConfigGlobal();
                Cliente cli = new Cliente();
                Tarjeta tar = new Tarjeta();
                tar.propietario = " ";
                tar.numero = " ";
                tar.fechaVencimiento = archivoDeConfig.getFechaSistema();
                cli.apellido = Convert.ToString(fila["apellido"]);
                cli.nombre = Convert.ToString(fila["nombre"]);
                cli.TipoDocu = Convert.ToString(fila["TipoDocumento"]);
                cli.numeroDocumento = Convert.ToInt32(fila["numeroDocumento"]);
                cli.fechaNacimiento = Convert.ToDateTime(fila["fechaNacimiento"]);
                cli.estado = Convert.ToBoolean(fila["estado"]);
                cli.cuil = Convert.ToString(fila["cuil"]);
                dom.calle = Convert.ToString(fila["calle"]);
                dom.piso = Convert.ToInt32(fila["piso"]);
                dom.numero = Convert.ToInt32(fila["numero"]);
                
                //Campos Nulleables  (CHECKEAR)
                if (!(fila["telefono"] is DBNull))
                    cli.telefono = Convert.ToInt32(fila["telefono"]);
                if (!(fila["mail"] is DBNull))
                    cli.mail = Convert.ToString(fila["mail"]);
                if (!(fila["departamento"] is DBNull))
                    dom.dpto = Convert.ToString(fila["departamento"]);
                if (!(fila["localidad"] is DBNull))
                    dom.localidad = Convert.ToString(fila["localidad"]);
                if (!(fila["codigoPostal"] is DBNull))
                    dom.cp = Convert.ToInt32(fila["codigoPostal"]);
                cli.Cli_Dir = dom;
                string query2 = "select count(T.Id) as 'cantidad' from dropeadores.TarjetaCredito T join dropeadores.Cliente C on (C.NumeroDocumento=T.clieteId) where T.clieteId = " + Convert.ToInt32(fila["numeroDocumento"]);
                DataTable dr = dao.ConsultarConQuery(query2);
                DataRow roww = dr.Rows[0];
                int cantDNI = int.Parse(roww["cantidad"].ToString());
                if (cantDNI == 0)
                
               // if (dao.EjecutarSP("dropeadores.ExistTarjetaCliente", cli.numeroDocumento) == 0)
                {
                    tar.propietario = " ";
                    tar.numero = " ";
                    tar.fechaVencimiento = archivoDeConfig.getFechaSistema();
                }
                else
                {
                    tar.propietario = Convert.ToString(fila["propietario"]);
                    tar.numero = Convert.ToString(fila["numero1"]);
                    tar.fechaVencimiento = Convert.ToDateTime(fila["fechaVencimiento"]);
                }

                cli.Cli_Tar = tar;
                lista.Add(cli);
            }
            return lista;
        }

         private void cargarDatos()
		{
          
			txtNombre.Text = cliente_seleccionado.nombre;
			txtApellido.Text = cliente_seleccionado.apellido;
			txtNroIdentificacion.Text = cliente_seleccionado.numeroDocumento.ToString();

           
            comboTipoDoc.SelectedIndex = (int)cliente_seleccionado.TipoDocu_enum;
			textCUIL.Text = cliente_seleccionado.cuil;
			textTelefono.Text = cliente_seleccionado.telefono.ToString();
			textMail.Text = cliente_seleccionado.mail;
			dateTimePickerFechaNac.Value = cliente_seleccionado.fechaNacimiento;
			textDireccion.Text = cliente_seleccionado.Cli_Dir.calle;
			txtNro.Text = cliente_seleccionado.Cli_Dir.numero.ToString();
			textLocalidad.Text = cliente_seleccionado.Cli_Dir.localidad;
            if (cliente_seleccionado.Cli_Tar.propietario != "''")
			txtTarjProp.Text = cliente_seleccionado.Cli_Tar.propietario;
            if (cliente_seleccionado.Cli_Tar.numero != "''")
			txtTarjNum.Text = cliente_seleccionado.Cli_Tar.numero.ToString();
           		dateTimePickerVenc.Value = cliente_seleccionado.Cli_Tar.fechaVencimiento;
            checkBaja.Checked = cliente_seleccionado.estado;
			if (cliente_seleccionado.Cli_Dir.dpto != "''")
				textDepto.Text = cliente_seleccionado.Cli_Dir.dpto.ToString();
			if (cliente_seleccionado.Cli_Dir.piso != -1)
				textPiso.Text = cliente_seleccionado.Cli_Dir.piso.ToString();
            if (cliente_seleccionado.Cli_Dir.cp != -1)
                txtCP.Text = cliente_seleccionado.Cli_Dir.cp.ToString();
			
		}

		private void groupBox2_Enter(object sender, EventArgs e)
		{

		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{

            if (todosCamposCompletos())
			{

				cliente_seleccionado.nombre = txtNombre.Text;
				cliente_seleccionado.apellido = txtApellido.Text;
				cliente_seleccionado.tipoDocumento = Documento.string_docu[comboTipoDoc.SelectedIndex];
				cliente_seleccionado.numeroDocumento = Int32.Parse(txtNroIdentificacion.Text);
				cliente_seleccionado.Fecha_nacimiento = dateTimePickerFechaNac.Text;
				cliente_seleccionado.mail = textMail.Text;
				cliente_seleccionado.telefono = Int32.Parse(textTelefono.Text);
				cliente_seleccionado.Cli_Dir.calle = textDireccion.Text;
                cliente_seleccionado.cuil = textCUIL.Text;
				cliente_seleccionado.Cli_Dir.numero = Int32.Parse(txtNro.Text);
				if (textPiso.Text != "")
					cliente_seleccionado.Cli_Dir.piso = Int32.Parse(textPiso.Text);
				if (textDepto.Text != "")
					cliente_seleccionado.Cli_Dir.dpto = textDepto.Text;
                if (textLocalidad.Text != "")
				cliente_seleccionado.Cli_Dir.localidad = textLocalidad.Text;
                if (txtCP.Text != "")
                    cliente_seleccionado.Cli_Dir.cp = Int32.Parse(txtCP.Text);
                cliente_seleccionado.Cli_Tar.propietario = txtTarjProp.Text;
                cliente_seleccionado.Cli_Tar.numero =(txtTarjNum.Text);
                cliente_seleccionado.Cli_Tar.fechaVencimiento = DateTime.Parse(dateTimePickerVenc.Text);
				cliente_seleccionado.estado = checkBaja.Checked;
                int rta= Cliente.actualizar(cliente_seleccionado,nroDOCViejo);
                if (rta== 1)
				{
					MessageBox.Show("Error al modificar el Cliente.", "Error al Modificar Cliente",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
                if (rta==0)
				{
					MessageBox.Show("Cliente Modificado Correctamente.", "Modificar Cliente",
					MessageBoxButtons.OK, MessageBoxIcon.None);
					
					this.Close();
				}

                if (rta==9)
                {
                    MessageBox.Show("Error al modificar el Cliente, dni ya ingresado.", "Error al Modificar Cliente",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
			}
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
            if (txtNombre.Text.Trim() == "" || !nameIsValid(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar un nombre válido", "Error al crear Nuevo Usuario",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtApellido.Text.Trim() == "" || !nameIsValid(txtApellido.Text))
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

            if (textCUIL.Text.Trim() == "")
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

            if (txtNroIdentificacion.Text.Trim() == "" || txtNroIdentificacion.Text == null)
            {
                MessageBox.Show("Debe ingresar un numero de DNI.", "Error al crear Nuevo Usuario",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if ((Convert.ToInt32(txtNroIdentificacion.Text) <= 0000) || (Convert.ToInt32(txtNroIdentificacion.Text) > 99999999))
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
            if (txtTarjNum.Text.Trim() == "")
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
            if (textCUIL.Text.Length > 11)
            {
                MessageBox.Show("Debe ingresar un numero de Cuil valido. XX-XXXXXXXX-X, SIN '-' ", "Error al crear Nuevo Usuario",
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
            if (hoy > dateTimePickerVenc.Value.Date)
            {
                MessageBox.Show("La fecha de vencimiento debe ser posterior al dia actual");
                return false;
            }
            Usuario usuario = new Usuario();
           
            return true;
        }
        

		private void btnVolver_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

        private void txtNroIdentificacion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNroIdentificacion_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
	}
}
