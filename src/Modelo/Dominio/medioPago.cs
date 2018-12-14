using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio
{

    public enum TarjetaTipo { CREDITO = 0, DEBITO = 1};

    public class medioPago
    {
        public static string[] string_Tarj = new string[2] { "CREDITO", "DEBITO"};
		private string tipoTarjeta;
		private TarjetaTipo tipo;
		private int numero;

		

	}
}
