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

namespace PalcoNet.Canje_Puntos
{
	public partial class CanjePuntos : Form
	{
		Usuario userLogueado;
		DateTime fechaDelSistema;
		Cliente cliente = new Cliente();
		Puntos puntos = new Puntos();
		Premio premio = new Premio();
		public CanjePuntos(Usuario user)
		{
			userLogueado = user;
			InitializeComponent();
		}

		private void CanjePuntos_Load(object sender, EventArgs e)
		{
			ConfigGlobal global = new ConfigGlobal();
			int puntosVigentes = 0;
			fechaDelSistema = global.getFechaSistema();
			DaoSP dao = new DaoSP();
			lblPuntosACanjear.Visible = false;
			//Busco los puntos de ese cliente
			puntosVigentes = puntos.consultarPuntosVigentes(fechaDelSistema, userLogueado.cliente.numeroDocumento);
			lblPuntosVigentes.Text = puntosVigentes.ToString();

			//Busco los premios que pueda a llegar a canjear un cliente,
			//tener en cuenta que los premios tienen su puntaje,
			//por ende el cliente segun sus puntos es el premio que le corresponde.
			DataTable dtPremios = new DataTable();
			//dtPremios = dao.ConsultarConQuery("select distinct p.Id as IdPremio,p.descripcion as Descripcion,PuntosVigentes,p.puntos as Puntos,FechaVencimiento from dropeadores.Puntos pu, " +
			//" dropeadores.Premio p where Id_Cliente =" + userLogueado.cliente.Id_Cliente +
			//" and pu.PuntosVigentes > p.puntos and FechaVencimiento > '" + fechaDelSistema + "' ");
			DataRow rowPremios = dtPremios.Rows[0];
			premio.Id = int.Parse(rowPremios["IdPremio"].ToString());
			premio.puntos = int.Parse(rowPremios["Puntos"].ToString());
			premio.descripcion = rowPremios["Descripcion"].ToString();

			CargarData.cargarComboBox(cbxPremios, dtPremios, "Puntos", "descripcion");

			DataTable dtcli = new DataTable();
			//dtcli = dao.ConsultarConQuery("select Cli_Nombre,Cli_Apeliido,Cli_Dni from dbo.Clientes where Id_Cliente= " + userLogueado.cliente.Id_Cliente);
			//DataRow rowcli = dtcli.Rows[0];
			//cliente.Cli_Nombre = rowcli["Cli_Nombre"].ToString();
			//cliente.Cli_Apellido = rowcli["Cli_Apeliido"].ToString();
			//cliente.Cli_Dni = int.Parse(rowcli["Cli_Dni"].ToString());
			//lblCliente.Text = cliente.Cli_Nombre + " " + cliente.Cli_Apellido;
			//lblDniCli.Text = cliente.Cli_Dni.ToString();
		}

		private void btnCanjear_Click(object sender, EventArgs e)
		{
			Puntos p = new Puntos();
			int puntosVigentesActuales = 0;
			//Premio.punto son los puntos seleccionados del cbx.
			premio.puntos = int.Parse(cbxPremios.SelectedValue.ToString());
			//p.actualizarPuntaje(userLogueado.cliente.Id_Cliente, premio.puntos, premio.Id);
			//puntosVigentesActuales = puntos.consultarPuntosVigentes(fechaDelSistema, userLogueado.cliente.Id_Cliente);
			lblPuntosVigentes.Text = puntosVigentesActuales.ToString();
			lblPuntosActuales.Text = puntosVigentesActuales.ToString();
		}
	}
}
