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

namespace PalcoNet.Generar_Rendicion_Comisiones
{
    public partial class GenerarRendicionComisiones : Form
    {
		Usuario userLog = new Usuario();
        public GenerarRendicionComisiones(Usuario u)
        {
			userLog = u;
            InitializeComponent();
        }

		private void GenerarRendicionComisiones_Load(object sender, EventArgs e)
		{
			try
			{
				lblEmpresa.Text = userLog.empresa.Empresa_Cuit;
				DataTable dt = new DataTable();
				DaoSP dao = new DaoSP();
				dt = dao.ObtenerDatosSP("dropeadores.GetComprasPorEmpresa", userLog.empresa.Empresa_Cuit);
				CargarData.cargarGridView(dataGridView1, dt);
				CargarData.AddCheckColumn(dataGridView1, "seleccion");
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				//int Codigo = int.Parse(dataGridView1.CurrentRow.Cells["Codigo"].Value.ToString());
				//Seleccionando
				if (this.dataGridView1.Columns[e.ColumnIndex].Name.Equals("seleccion"))
				{
					decimal total = 0;
					total+= decimal.Parse(dataGridView1.CurrentRow.Cells["precio"].Value.ToString());
					lblTotal.Text = total.ToString();
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		private void btnVolver_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void btnPagarEmpresa_Click(object sender, EventArgs e)
		{
			//validar que cuando haya seleccionado todas no haya quedado ninguna sin seleccionar que tenga una fecha anterior.
			//validar que se hayan seleccionado la cantidad de compras a rendir que haya dicho el admin
			//PAGAR A LA EMPRESA significa crear una factura para ESA EMPRESA,
			//y agregar todos los items por esa facutra (EL MONTO DEL ITEM ES EL DE LA COMPRA MENOS LA COMISION)
		}
	}
}
