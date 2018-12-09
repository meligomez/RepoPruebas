using Modelo.Base;
using Modelo.Comun;
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

		private void EliminarCliente_Load(object sender, EventArgs e)
		{
			cargarTabla();
		}
		private void cargarTabla()
		{

			DaoSP prueba = new DaoSP();

			CargarData.cargarGridView(dataGridCliente, prueba.ConsultarConQuery("SELECT nombre as 'NOMBRE',apellido as 'APELLIDO' ,tipoDocumento as 'tipoDocumento' ,numeroDocumento as 'numeroDocumento' ,mail as 'MAIL', estado as 'ESTADO' from dropeadores.Cliente WHERE estado = 1"));

			CargarData.AddButtonEliminar(dataGridCliente);


		}
		private DataTable FiltrarCliente(string nombre, string apellido, string mail, int tipoDoc, int numDoc)
		{
			DaoSP dao = new DaoSP();
			DataTable tabla_Cliente;
			int docVacio = 0;
			if (numDoc != docVacio)
			{
				tabla_Cliente = dao.ObtenerDatosSP("dropeadores.getCliente", numDoc);
			}
			else
			{
				tabla_Cliente = dao.ObtenerDatosSP("dropeadores.getCliente", docVacio);
			}

			var final_rol = "";
			var posFiltro = true;
			var filtrosBusqueda = new List<string>();
			if (nombre != "") filtrosBusqueda.Add("nombre LIKE '%" + nombre + "%'");
			if (apellido != "") filtrosBusqueda.Add("apellido LIKE '%" + apellido + "%'");
			if (mail != "") filtrosBusqueda.Add("mail LIKE '%" + mail + "%'");
			if (tipoDoc != -1) filtrosBusqueda.Add("tipoDocumento LIKE '%" + comboTipoDoc.Items[tipoDoc] + "%'");
			if (numDoc != 0) filtrosBusqueda.Add("numeroDocumento = " + numDoc);

			foreach (var filtro in filtrosBusqueda)
			{
				if (!posFiltro)
					final_rol += " AND " + filtro;
				else
				{
					final_rol += filtro;
					posFiltro = false;
				}
			}


			if (tabla_Cliente != null)
				tabla_Cliente.DefaultView.RowFilter = final_rol;
			return tabla_Cliente;



		}
		private void botonBuscar_Click(object sender, EventArgs e)
		{
			int documento;
			if (textNroIdentificacion.Text != "")
				documento = Int32.Parse(textNroIdentificacion.Text);
			else
			{
				documento = 0;
			}

			DataTable respuesta = FiltrarCliente(textNombre.Text, textApellido.Text, textEmail.Text, comboTipoDoc.SelectedIndex, documento);
			dataGridCliente.DataSource = respuesta;
			if (dataGridCliente.CurrentRow == null)
			{

				MessageBox.Show("El Cliente requerido no se encuentra.", "Baja de Cliente",
				   MessageBoxButtons.OK);

				cargarTabla();

			}
		}

		private void btCancelar_Click_1(object sender, EventArgs e)
		{
			this.Hide();
		}
	}
}
