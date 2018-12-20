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

namespace PalcoNet.Abm_Empresa_Espectaculo
{
	public partial class ModificarEmpresaElegida : Form
	{
        Empresa empresa_Seleccionada;
        string nroCuilViejo = "";
       
        ConfigGlobal archivoDeConfig = new ConfigGlobal();
       
		public ModificarEmpresaElegida(string cuit)
		{
			InitializeComponent();
            DaoSP dao = new DaoSP();
            empresa_Seleccionada = obtener(cuit);
            //textCUIT.ReadOnly = true;
            //textRazonSocial.ReadOnly = true;
          
            if (empresa_Seleccionada == null)
            {
                MessageBox.Show("Error al cargar el cliente.", "Error al Modificar Cliente",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Dispose();
            }
		}


        private void cargarDatos()
        {   textRazonSocial.Text = empresa_Seleccionada.Empresa_razon_social;
            textCUIT.Text = empresa_Seleccionada.Empresa_Cuit;
            nroCuilViejo = Convert.ToString(empresa_Seleccionada.Empresa_Cuit);
            textTelefono.Text = empresa_Seleccionada.Empresa_telefono.ToString();
            textMail.Text = empresa_Seleccionada.Empresa_mail;
            textCiudad.Text = empresa_Seleccionada.Empresa_Dom.ciudad;
            textDireccion.Text = empresa_Seleccionada.Empresa_Dom.calle;
            txtNro.Text = empresa_Seleccionada.Empresa_Dom.numero.ToString();
            textLocalidad.Text = empresa_Seleccionada.Empresa_Dom.localidad;
            textPiso.Text = empresa_Seleccionada.Empresa_Dom.piso.ToString();
            textDepto.Text = empresa_Seleccionada.Empresa_Dom.dpto.ToString();
            textCP.Text = empresa_Seleccionada.Empresa_Dom.cp.ToString();

            checkBaja.Checked = empresa_Seleccionada.Empresa_estado;
            if (empresa_Seleccionada.Empresa_Dom.calle != "''")
                textDepto.Text = empresa_Seleccionada.Empresa_Dom.dpto.ToString();
            if (empresa_Seleccionada.Empresa_Dom.piso != -1)
                textPiso.Text = empresa_Seleccionada.Empresa_Dom.piso.ToString();
        }

        private void limpiar()
        {
            textRazonSocial.Text = "";
            textCUIT.Text = "";
            textTelefono.Text="";
            textMail.Text = "";
            textCiudad.Text = "";
            textDireccion.Text = "";
            txtNro.Text = "";
            textLocalidad.Text = "";
            textPiso.Text = "";
            textDepto.Text = "";
            textCP.Text = "";
           
        }

        public static DataTable obtenerTabla(string cuit)
        {


            DaoSP dao = new DaoSP();
            return dao.ObtenerDatosSP("dropeadores.ObtenerEmpresaEspecifica", cuit);
        }

        public static Empresa obtener(string cuit)
        {
            List<Empresa> lista = transductor(obtenerTabla(cuit));
            if (lista.Count == 0)
                return null;
            return lista[0];
        }
        public static List<Empresa> transductor(DataTable tabla)
        {
            List<Empresa> lista = new List<Empresa>();
            foreach (DataRow fila in tabla.Rows)
            {
                Domicilio dom = new Domicilio();
                Empresa empresa = new Empresa();
                empresa.Empresa_Cuit = Convert.ToString(fila["empresa_Cuit"]);
                empresa.Empresa_razon_social = Convert.ToString(fila["empresa_razon_social"]);
                empresa.Empresa_estado = Convert.ToBoolean(fila["empresa_estado"]);
                dom.calle = Convert.ToString(fila["calle"]);
                dom.numero = Convert.ToInt32(fila["numero"]);
                dom.piso = Convert.ToInt32(fila["piso"]);
                dom.dpto = Convert.ToString(fila["departamento"]);
                dom.localidad = Convert.ToString(fila["localidad"]);
                dom.cp = Convert.ToInt32(fila["codigoPostal"]);
                dom.ciudad = Convert.ToString(fila["ciudad"]);

                empresa.Empresa_Dom = dom;
                //Campos Nulleables  (CHECKEAR)
                if (!(fila["empresa_telefono"] is DBNull))
                    empresa.Empresa_telefono = Convert.ToInt32(fila["empresa_telefono"]);
                if (!(fila["empresa_mail"] is DBNull))
                    empresa.Empresa_mail = Convert.ToString(fila["empresa_mail"]);
               
                lista.Add(empresa);
            }
            return lista;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (todosCamposCompletos())
            {
                empresa_Seleccionada.Empresa_razon_social = textRazonSocial.Text;
                empresa_Seleccionada.Empresa_Cuit = textCUIT.Text;
                empresa_Seleccionada.Empresa_telefono = Int32.Parse(textTelefono.Text);
                empresa_Seleccionada.Empresa_mail = textMail.Text;
                empresa_Seleccionada.Empresa_Dom.ciudad = textCiudad.Text;
                empresa_Seleccionada.Empresa_Dom.calle = textDireccion.Text;
                empresa_Seleccionada.Empresa_Dom.numero = Int32.Parse(txtNro.Text);
                empresa_Seleccionada.Empresa_Dom.localidad = textLocalidad.Text;
                empresa_Seleccionada.Empresa_Dom.piso = Int32.Parse(textPiso.Text);
                empresa_Seleccionada.Empresa_Dom.dpto = textDepto.Text;
                empresa_Seleccionada.Empresa_Dom.cp = Int32.Parse(textCP.Text);

                if (textPiso.Text != "")
                    empresa_Seleccionada.Empresa_Dom.piso = Int32.Parse(textPiso.Text);
                if (textDepto.Text != "")
                    empresa_Seleccionada.Empresa_Dom.dpto = textDepto.Text;

                if (checkBaja.Checked)
                {
                    empresa_Seleccionada.Empresa_estado = checkBaja.Checked;
                }

                if (!Empresa.actualizar(empresa_Seleccionada, nroCuilViejo))
                {
                    MessageBox.Show("Error al modificar la empresa.", "Error al Modificar empresa",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Empresa Modificada Correctamente.", "Modificar empresa",
                    MessageBoxButtons.OK, MessageBoxIcon.None);
                    ModificacionEmpresa empMod = new ModificacionEmpresa();
                    empMod.Show();
                    this.Hide();
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
            int value;
            if (textRazonSocial.Text.Trim() == "" )
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
            if (textTelefono.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un TELEFONO.", "Error al crear Nueva empresa",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
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
            if (textPiso.Text.Trim() != "" && !int.TryParse(textPiso.Text, out value))
            {
                MessageBox.Show("Debe ingresar EL PISO .", "Error al crear Nueva empresa",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
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
        private void ModificarEmpresaElegida_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void checkBaja_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
           ModificacionEmpresa modEmp = new ModificacionEmpresa();
           modEmp.Show();
            this.Hide();
        }
	}
}
