using Modelo.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelo.Dominio
{
	public class Cliente
	{
        public int numeroDocumento { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string tipoDocumento { get; set; }
        public string cuil { get; set; }
        public string mail { get; set; }
        public bool estado { get; set; }
        public DateTime fechaNacimiento { get; set; }
        private DateTime? fecha_nacimiento = null;
        public DateTime fechaCreacion { get; set; }
        public int telefono { get; set; }
        private Documento documento = new Documento();
        public Domicilio Cli_Dir { get; set; }
        public Tarjeta Cli_Tar { get; set; }
        private Tarjeta tarjeta = new Tarjeta();

        

		public string Fecha_nacimiento
		{
			get { return ((DateTime)fecha_nacimiento).ToString("yyyyMMdd"); }
			set { fecha_nacimiento = DateTime.Parse(value); }
		}
		public DateTime? Fecha_nacimiento_struct
		{
			get { return fecha_nacimiento; }
			set { fecha_nacimiento = value; }
		}
        public DocumentoTipoEnum TipoDocu_enum
        {
            get { return documento.Tipo; }
            set { documento.Tipo = value; }
        }

        public TarjetaTipoEnum TipoTar_enum
        {
            get { return tarjeta.Tipo; }
            set { tarjeta.Tipo = value; }
        }
      

		public static int actualizar(Cliente cliente_seleccionado, int nroViejo)
		{

			DaoSP dao = new DaoSP();
            int puedeUpdetear = 0;
            int docViejo = nroViejo;
			DataTable dt, dr,da = new DataTable();
             int cant = 0;
			int IDcliente = 000000;
			string nombre = cliente_seleccionado.nombre;
			string apellido = cliente_seleccionado.apellido;
			string tipoDocumento = cliente_seleccionado.tipoDocumento;
			int numeroDocumento = cliente_seleccionado.numeroDocumento;
            int numeroDocumentoViejo = nroViejo;
			string cuil = cliente_seleccionado.cuil;
			string email = cliente_seleccionado.mail;
			int telefono = cliente_seleccionado.telefono;
			DateTime fecha_nacimiento = cliente_seleccionado.fechaNacimiento;
			string calle = cliente_seleccionado.Cli_Dir.calle;
			int numero = cliente_seleccionado.Cli_Dir.numero;
			int piso = cliente_seleccionado.Cli_Dir.piso;
			string depto = cliente_seleccionado.Cli_Dir.dpto;
			string localidad = cliente_seleccionado.Cli_Dir.localidad;
            string ciudad = cliente_seleccionado.Cli_Dir.ciudad;
			int cp = cliente_seleccionado.Cli_Dir.cp;
			string propietarioTar = cliente_seleccionado.Cli_Tar.propietario;
			string numeroTar = cliente_seleccionado.Cli_Tar.numero;
            string descripcionTar = cliente_seleccionado.Cli_Tar.descripcion;
			DateTime fecha_vencimiento = cliente_seleccionado.Cli_Tar.fechaVencimiento;
            int campoBaja = (cliente_seleccionado.estado) ? 1 : 1;
            //si es 0 puede updetear el cliente ya que no existe
            if (numeroDocumentoViejo != numeroDocumento)
            {
                da = dao.ConsultarConQuery("select count(c.numeroDocumento) as 'Id' from dropeadores.Cliente c where c.numeroDocumento=" + numeroDocumento + "AND c.TipoDocumento LIKE '" + tipoDocumento + "'" );
                foreach (DataRow row in da.Rows)
                {

                    cant = Convert.ToInt32(row["Id"].ToString());

                }
                puedeUpdetear=cant;
            }
            else
            {
                puedeUpdetear = 0;
            }
            dt = dao.ConsultarConQuery("SELECT cliente_domicilio FROM dropeadores.Cliente WHERE tipoDocumento like " + "'" + tipoDocumento + "' AND numeroDocumento like" + "'" + docViejo + "'");
            foreach (DataRow row in dt.Rows)
            {
                IDcliente = Convert.ToInt32(row["cliente_domicilio"].ToString());
                
            }
            if (puedeUpdetear==0)
            {
                if (dao.EjecutarSP("dropeadores.updateDomicilioCliente", IDcliente, calle, numero, piso, depto, localidad, " ", cp) > 0)
                {
                    if (dao.EjecutarSP("dropeadores.updateCliente", numeroDocumento, nombre, apellido, tipoDocumento, cuil, email, fecha_nacimiento, IDcliente, telefono, campoBaja) > 0)
                    {

                        dt = dao.ConsultarConQuery("select count(T.Id) as 'Id' from dropeadores.TarjetaCredito T join dropeadores.Cliente C on (C.NumeroDocumento=T.clieteId) where T.clieteId=" + numeroDocumento);
                        foreach (DataRow row in dt.Rows)
                        {

                            cant = Convert.ToInt32(row["Id"].ToString());

                        }

                        if (cant == 0)
                        {
                            if (dao.EjecutarSP("dropeadores.Cliente_Alta_Tarjeta", propietarioTar, numeroTar, fecha_vencimiento, numeroDocumento, descripcionTar) > 0)
                            {
                                return 0;
                            }
                        }
                        else
                        {
                            if (dao.EjecutarSP("dropeadores.updateTarjetaCliente", numeroDocumento, propietarioTar, numeroTar, fecha_vencimiento, descripcionTar) > 0)
                            {
                                return 0;
                            }

                        }

                    }

                }
            }
           

			return 1;
		}

        //public bool existeELcliente(string tipo, int numeroDoc)
        //{
        //    DataTable dt, dr = new DataTable();
        //    int cant = 0;
        //    DaoSP dao = new DaoSP();
        //    dt = dao.ConsultarConQuery("select count(c.numeroDocumento) as 'cantidad' from dropeadores.Cliente c where c.estado=1 and c.cuil LIKE" + "'" + tipo + "' and c.numeroDocumento=" + numDni);
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        cant = Convert.ToInt32(row["cantidad"]);
        //    }
        //    if (cant > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
          
        //}
        
        public int NroDocu
        {
            get { return documento.nroDoc; }
            set { documento.nroDoc = (int)value; }
        }

        public string TipoDocu
        {
            get { return documento.tipoDoc; }
            set { documento.tipoDoc = value; }
        }


        public string TipoTar
        {
            get { return tarjeta.tipoTar; }
            set { tarjeta.tipoTar = value; }
        }


		public static int updateTarj(Cliente cli)
		{
			DataTable dt, dr = new DataTable();
			DaoSP dao = new DaoSP();
			string propietarioTar = cli.Cli_Tar.propietario;
			string numeroTar = cli.Cli_Tar.numero;
			DateTime fecha_vencimiento = cli.Cli_Tar.fechaVencimiento;
			string descripcion = cli.Cli_Tar.descripcion;
			int numeroDocumento = cli.numeroDocumento;

			if (dao.EjecutarSP("dropeadores.asociarTarjetaCliente", numeroDocumento, propietarioTar, numeroTar, fecha_vencimiento, descripcion) > 0)
			{

				return 0;

			}
			else
			{

				return 1;

			}


		}
	}


}
