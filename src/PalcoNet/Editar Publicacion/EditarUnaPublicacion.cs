using Modelo.Base;
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

namespace PalcoNet.Editar_Publicacion
{
    public partial class btnEditPublic : Form
    {
		Usuario userLogueado;
		Publicacion publicacion= new Publicacion();
        public btnEditPublic(Usuario user, int idpubli )
        {
			userLogueado = user;
			publicacion.codigo = idpubli;
            InitializeComponent();
        }

		private void EditarUnaPublicacion_Load(object sender, EventArgs e)
		{
			DataTable dtGrado = new DataTable();
			DataTable dtRubro = new DataTable();
			DaoSP dao = new DaoSP();
			dtGrado = dao.ConsultarConQuery("SELECT id, tipo FROM dropeadores.Grado");
			dtRubro = dao.ConsultarConQuery("SELECT Codigo,Descripcion FROM dropeadores.Rubro");
			CargarData.cargarComboBox(comboRubro, dtRubro, "Codigo", "Descripcion");
			CargarData.cargarComboBox(comboGradoPublicacion, dtGrado, "id", "tipo");
			dateTimePicker1.Format = DateTimePickerFormat.Custom;
			dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss";

			publicacion= publicacion.getPublicacionByCodigo(publicacion.codigo);
			textDescripcion.Text = publicacion.descripcion;
			textDireccion.Text = publicacion.direccion;
			textStock.Text = publicacion.stock.ToString();
			estadoPublicacion.Text = "Borrador";
			dateTimePickerPublicacion.Value= publicacion.fechaPublicacion;
			comboGradoPublicacion.SelectedIndex = publicacion.gradoId;
			comboRubro.SelectedIndex = publicacion.rubroId;
			lblCodigo.Text = publicacion.codigo.ToString() ;
			lblEmpresa.Text = publicacion.empresaId;

		}

		private void btnVolver_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			MessageBox.Show(" ", "¡Correcto!",
				MessageBoxButtons.OK, MessageBoxIcon.None);
			a.Visible = true;
			b.Visible = true;
			c.Visible = true;
			d.Visible = true;
			ee.Visible = true;
			f.Visible = true;
			g.Visible = true;
			h.Visible = true;
			i.Visible = true;
			j.Visible = true;
			groupBox1.Visible = true;
			lblEmpresa.Visible = true;
			lblCodigo.Visible = true;
			lblTextLote.Visible = true;
			comboGradoPublicacion.Visible = true;
			comboRubro.Visible = true;
			textStock.Visible = true;
			dateTimePicker1.Visible = true;
			dateTimePickerPublicacion.Visible = true;
			btnEditUbicacion.Visible = false;
			textDescripcion.Visible = true;
			textDireccion.Visible = true;
			estadoPublicacion.Visible = true;
			button2.Visible = false;

		}

		private void btnEditUbicacion_Click(object sender, EventArgs e)
		{
			a.Visible = false;
			b.Visible = false;
			c.Visible = false;
			d.Visible = false;
			ee.Visible = false;
			f.Visible = false;
			g.Visible = false;
			h.Visible = false;
			i.Visible = false;
			j.Visible = false;
			groupBox1.Visible = false;
			lblEmpresa.Visible = false;
			lblCodigo.Visible = false;
			lblTextLote.Visible = false;
			comboGradoPublicacion.Visible = false;
			comboRubro.Visible = false;
			textStock.Visible = false;
			dateTimePicker1.Visible = false;
			dateTimePickerPublicacion.Visible = false;
			btnEditUbicacion.Visible = false;
			textDescripcion.Visible = false;
			textDireccion.Visible = false;
			estadoPublicacion.Visible = false;
			button2.Visible = false;
			MessageBox.Show("Si ud quiere modificar las ubicaciones deberá generar una nueva publicacion.");

		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			Publicacion p = new Publicacion();
			p.codigo = int.Parse(lblCodigo.Text);
			p.empresaId=lblEmpresa.Text ;
			p.gradoId=int.Parse(comboGradoPublicacion.SelectedValue.ToString()) ;
			p.rubroId=int.Parse(comboRubro.SelectedValue.ToString());
			p.stock=int.Parse(textStock.Text) ;
			p.fechaEspectaculo=dateTimePicker1.Value;
			p.fechaPublicacion=dateTimePickerPublicacion.Value ;
			p.descripcion=textDescripcion.Text ;
			p.direccion= textDireccion.Text;
			p.estado=p.getIdEstadoByName(estadoPublicacion.Text) ;
			if(p.editarPublicacion()>0)
			{
				MessageBox.Show("Cambios guardados correctamente.", "¡Correcto!",
				MessageBoxButtons.OK, MessageBoxIcon.None);
			}
			else
			{
				MessageBox.Show("Error al modificar la publicacion", "¡Error!",
				MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private void textDireccion_TextChanged(object sender, EventArgs e)
		{

		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}

		private void label7_Click(object sender, EventArgs e)
		{

		}
	}
}
