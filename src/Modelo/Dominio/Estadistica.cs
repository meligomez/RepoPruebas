using Modelo.Base;
using Modelo.Comun;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelo.Dominio
{
	public class Estadistica
	{
		
		public DataTable getClientesMasPuntosVencidos(DataGridView dataGridView1, string trimestre, string anio)
		{
			try
			{
				DataTable dt = new DataTable();

				DaoSP dao = new DaoSP();
				dt = dao.ObtenerDatosSP("dropeadores.getClientesMasPuntosVencidos", trimestre, anio);
				return dt;
			}
			catch (Exception ex)
			{

				throw ex;
			}
			
		
		}

		public DataTable getClientesMayorCompras(DataGridView dataGridView1,string trimestre, string anio)
		{
			try
			{
				DataTable dt = new DataTable();
				DaoSP dao = new DaoSP();
				dt = dao.ObtenerDatosSP("dropeadores.getClientesMayorCantCompras", trimestre, anio);
				return dt;
			}
			catch (Exception ex)
			{

				throw ex;
			}
			
		}
		public DataTable getLocalidadesNoVendidas(DataGridView dataGridView1, string trimestre, string anio, int idGrado)
		{
			try
			{
				DataTable dt = new DataTable();
				DaoSP dao = new DaoSP();
				dt = dao.ObtenerDatosSP("dropeadores.getLocalidadesNoVendidas", trimestre, anio, idGrado);
				return dt;
			}
			catch (Exception ex)
			{

				throw ex;
			}
			
		}

	}
}
