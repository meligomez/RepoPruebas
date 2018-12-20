using Modelo.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio
{
    public class Empresa
    {

        public string Empresa_Cuit { get; set; }
        public string Empresa_mail { get; set; }
        public int Empresa_telefono { get; set; }
        public string Empresa_razon_social { get; set; }
        public int Empresa_domicilio { get; set; }
        public bool Empresa_estado { get; set; }

        public Domicilio Empresa_Dom { get; set; }





        public static bool actualizar(Empresa empresa_Seleccionada, string nroCuilViejo,string razonSocialVieja)
        {
            DaoSP dao = new DaoSP();
            DataTable dt,da = new DataTable();
            int cant = 0;
            int puedeUpdetear = 0;
            int IDempresa = 000000;
            string cuitViejo = nroCuilViejo;
            string Rzantigua = razonSocialVieja;
            string cuit = empresa_Seleccionada.Empresa_Cuit;
            string razonSocial = empresa_Seleccionada.Empresa_razon_social;
            string email = empresa_Seleccionada.Empresa_mail;
            int telefono = empresa_Seleccionada.Empresa_telefono;
            string calle = empresa_Seleccionada.Empresa_Dom.calle;
            int numero = empresa_Seleccionada.Empresa_Dom.numero;
            int piso = empresa_Seleccionada.Empresa_Dom.piso;
            string depto = empresa_Seleccionada.Empresa_Dom.dpto;
            string localidad = empresa_Seleccionada.Empresa_Dom.localidad;
            string ciudad = empresa_Seleccionada.Empresa_Dom.ciudad;
            int cp = empresa_Seleccionada.Empresa_Dom.cp;
            int campoBaja = (empresa_Seleccionada.Empresa_estado) ? 1 : 1;
            dt = dao.ConsultarConQuery("SELECT empresa_domicilio from dropeadores.Empresa c where c.empresa_Cuit like '" + cuit + "' and c.empresa_razon_social like '" + razonSocial + "'");
            
            foreach (DataRow row in dt.Rows)
            {
                IDempresa = Convert.ToInt32(row["empresa_domicilio"].ToString());
            }
            if ((cuitViejo != cuit) || (Rzantigua!=razonSocial))
            {
                da = dao.ConsultarConQuery("select count(c.empresa_Cuit) as 'Id' from dropeadores.Empresa c where c.empresa_Cuit like '" + cuit + "' and c.empresa_razon_social like '"+ razonSocial +"'");
                foreach (DataRow row in da.Rows)
                {

                    cant = Convert.ToInt32(row["Id"].ToString());

                }
                puedeUpdetear = cant;
            }
            else
            {

                puedeUpdetear = 0;
            }
            if (puedeUpdetear == 0)
            {
                if (dao.EjecutarSP("dropeadores.updateDomicilioCliente", IDempresa, calle, numero, piso, depto, localidad, ciudad, cp) > 0)
                {
                    if (dao.EjecutarSP("dropeadores.updateEmpresa", cuit, razonSocial, email, telefono, campoBaja) > 0)
                    {

                        return true;

                    }

                }
            }
            return false;
        }

                
        public int existEmpresa(string razonSocial, string cuit, string mail)
        {


            DataTable dt, dr, da = new DataTable();
            int cant = 0;
            DaoSP dao = new DaoSP();
            dt = dao.ConsultarConQuery("Select COUNT(empresa_Cuit) as 'cantidad' from dropeadores.Empresa where empresa_razon_social LIKE " + "'" + razonSocial + "'");
            dr = dao.ConsultarConQuery("Select COUNT(empresa_Cuit) as 'cantidad' from dropeadores.Empresa where empresa_Cuit LIKE " + "'" + cuit + "'");
            da = dao.ConsultarConQuery("Select COUNT(empresa_Cuit) as 'cantidad' from dropeadores.Empresa where empresa_mail LIKE " + "'" + mail + "'");

            foreach (DataRow row in dt.Rows)
            {
                cant = Convert.ToInt32(row["cantidad"]);
            }
            foreach (DataRow row in dr.Rows)
            {
                cant = cant + Convert.ToInt32(row["cantidad"]);
            }
            foreach (DataRow row in da.Rows)
            {
                cant = cant + Convert.ToInt32(row["cantidad"]);
            }

            return cant;
        }


    }
}

