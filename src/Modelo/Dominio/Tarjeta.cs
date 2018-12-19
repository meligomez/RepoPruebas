using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio
{
    public enum TarjetaTipoEnum { DEBITO = 0, CREDITO = 1 };

	public class Tarjeta
	{
        public long Id { get; set; }
        public string propietario { get; set; }
        public string numero { get; set; }
        public DateTime fechaVencimiento { get; set; }
        public DateTime? fecha_vencimiento = null;
        public string descripcion { get; set; }
        public static string[] string_tipo = new string[2] { "DEBITO", "CREDITO" };
        private TarjetaTipoEnum tipoDescr;
        private string tipoTarjeta;

		public string Fecha_vencimiento
		{
			get { return ((DateTime)fecha_vencimiento).ToString("yyyyMMdd"); }
			set { fecha_vencimiento = DateTime.Parse(value); }
		}
		public DateTime? Fecha_vencimiento_struct
		{
			get { return fecha_vencimiento; }
			set { fecha_vencimiento = value; }
		}

		public Cliente tar_cli { get; set; }
        public string tipoTar
        {
            get { return tipoTarjeta; }
            set
            {
                tipoTarjeta = value;
                tipoDescr = enumByString(value);
            }
        }

        public TarjetaTipoEnum Tipo
        {
            get { return tipoDescr; }
            set
            {
                tipoDescr = value;
                tipoTarjeta = stringByEnum(value);
            }
        }

        public TarjetaTipoEnum enumByString(string cadena)
        {
            switch (cadena)
            {
                case "DEBITO":
                    return TarjetaTipoEnum.DEBITO;
                case "CREDITO":
                    return TarjetaTipoEnum.CREDITO;

            }
            return TarjetaTipoEnum.DEBITO;
        }
        public string stringByEnum(TarjetaTipoEnum enumerador)
        {
            switch (enumerador)
            {
                case TarjetaTipoEnum.DEBITO:
                    return "DEBITO";
                case TarjetaTipoEnum.CREDITO:
                    return "CREDITO";
            }
            return null;

        }
    }
}
