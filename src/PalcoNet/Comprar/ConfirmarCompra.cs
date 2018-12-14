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

namespace PalcoNet.Comprar
{
    public partial class ConfirmarCompra : Form
    {
        List<Ubicacion> ubicacionesSeleccionadas;
        Usuario usuario = new Usuario();
        Cliente cliente = new Cliente();
        ConfigGlobal fech = new ConfigGlobal();


        public ConfirmarCompra(List<Ubicacion> ubicacSeleccionadas, Usuario user)
        {
            DaoSP tj = new DaoSP();
            ubicacionesSeleccionadas = ubicacSeleccionadas;
            usuario = user;
            cliente.numeroDocumento = usuario.cliente.numeroDocumento;
            DataTable dt = new DataTable();
            string medioDePago = "";
            InitializeComponent();
            dt = tj.ConsultarConQuery("select t.descripcion as 'tipoTarjeta' from dropeadores.Cliente c join dropeadores.TarjetaCredito t on (t.clieteId=c.numeroDocumento) where c.numeroDocumento=" + usuario.cliente.numeroDocumento);
            
            foreach (DataRow row in dt.Rows)
            {
                medioDePago = Convert.ToString(row["tipoTarjeta"]);
            }
            labelMedioPago.Text = medioDePago.ToString();
        }
        private void cargarTabla()
        {

            ConfigGlobal fech = new ConfigGlobal();

            DaoSP prueba = new DaoSP();

            dataGridViewCompra.DataSource = ubicacionesSeleccionadas;
            dataGridViewCompra.Columns[2].Visible = false;
            dataGridViewCompra.Columns[6].Visible = false;
            dataGridViewCompra.Columns[4].Visible = false;
           
        }
        private int calcularPrecio()
        {
            double precioTotal = 0;
            foreach (DataGridViewRow row in dataGridViewCompra.Rows)
            {
              
                string fila = row.Cells[0].Value.ToString();
                string asiento = row.Cells[1].Value.ToString();
                string publicacionID = row.Cells[5].Value.ToString();
                Double precio = Convert.ToDouble(row.Cells[3].Value.ToString());
                precioTotal = precioTotal + precio;
            }
            lblImporte.Text = Convert.ToString(precioTotal);
            return 0;
        }
        private void calcularPuntos()
        {
            DaoSP dao = new DaoSP();
            int puntos = 5;
            if (dao.EjecutarSP("dropeadores.insertPuntos", puntos, usuario.cliente.numeroDocumento, fech.getFechaSistema()) > 0)
            {

            }
        }
        private void ConfirmarCompra_Load(object sender, EventArgs e)
        {
            cargarTabla();
           int x = calcularPrecio();
           calcularPuntos();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevoMedioPago_Click(object sender, EventArgs e)
        {
            if (labelMedioPago.Text=="")
            {
                this.Hide();
                new AsociarTarjeta(usuario).Show();
            }
        }

        private void buttonPAGAR_Click(object sender, EventArgs e)
        {
            queryComprar();
            insertarUbicacionXPublCompradoYActualizarCompra();
            //obtenerValorPuntajeCompra();
        }
        public void queryComprar()
        {
            DaoSP tj = new DaoSP();
            DataTable dt = new DataTable();
            string tipoDoc="";
            int nroDoc=0;
            dt = tj.ConsultarConQuery("select c.TipoDocumento as 'TIPO DOCUMENTO',  c.NumeroDocumento as 'NUMERO DOCUMENTO' from dropeadores.Cliente c join dropeadores.Usuario u on (u.clienteId=c.NumeroDocumento) where c.NumeroDocumento=" + usuario.cliente.numeroDocumento);
            foreach (DataRow row in dt.Rows)
            {
                tipoDoc = Convert.ToString(row["TIPO DOCUMENTO"]);
                nroDoc = Convert.ToInt32(row["NUMERO DOCUMENTO"]);
               
            }

            int cantidadUbicacionesCompradas = ubicacionesSeleccionadas.Count;
            if (tj.EjecutarSP("dropeadores.InsertCompra", tipoDoc, nroDoc, fech.getFechaSistema(), cantidadUbicacionesCompradas, lblImporte.Text) > 0)
            {
                //crear insert
                MessageBox.Show("La compra fue realizada con éxito");
        
            }

         

           }
        private void insertarUbicacionXPublCompradoYActualizarCompra()
        {
           
        }

        private void lblImporte_Click(object sender, EventArgs e)
        {

        }

    }
}
