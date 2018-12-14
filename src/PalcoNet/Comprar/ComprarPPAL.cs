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
    public partial class ComprarPPAL : Form
    {

        private bool CategoriaCargada;
        private bool UbicacionCargada;
        private DateTime fecDesde, fecHasta;
        List<String> listaCategorias = new List<String>();
        List<Ubicacion> ubicacionesSeleccionadas = new List<Ubicacion>();
        List<String> IDs = new List<String>();
        ConfigGlobal fech = new ConfigGlobal();
        Usuario usuario = new Usuario();


        public ComprarPPAL(Usuario user)
        {
            InitializeComponent();
            
            usuario = user;
            string medioDePago = "";
            usuario.cliente.numeroDocumento = 35550990;
            DaoSP tj = new DaoSP();
            DataTable dt = new DataTable();
            dt = tj.ConsultarConQuery("select t.descripcion as 'tipoTarjeta' from dropeadores.Cliente c join dropeadores.TarjetaCredito t on (t.clieteId=c.numeroDocumento) where c.numeroDocumento=" + usuario.cliente.numeroDocumento);
            //dt = tj.ConsultarConQuery("select * from dropeadores.Cliente c left join dropeadores.TarjetaCredito t on (t.clieteId=c.numeroDocumento)");
            
            foreach (DataRow row in dt.Rows)
            {
                medioDePago = Convert.ToString(row["tipoTarjeta"]);
            }
            labelMedioPago.Text = medioDePago.ToString();
        }


        private void ComprarPPAL_Load(object sender, EventArgs e)
        {
            cargarTabla();
        }


        public void CompletarCategoríasSeleccionadas(List<String> CatElegidas)
        {
            labelCategorias.Text = "";
            listaCategorias = CatElegidas;
            for (int i = 0; i < CatElegidas.Count(); i++)
            {
                labelCategorias.Text += CatElegidas[i] + "  ";
            }
            CategoriaCargada = true;

        }



        private void cargarTabla()
        {

            DaoSP prueba = new DaoSP();

            CargarData.cargarGridView(dataGridViewCompras, prueba.ObtenerDatosSP("dropeadores.getTablaPublicacion", fech.getFechaSistema()));

            CargarData.AddButtonSeleccionar(dataGridViewCompras);
        }

        private DataTable FiltrarPublicacion(string CatElegidas, string descripcion, DateTime fechaDesde, DateTime fechaHasta, List<String> listaCat)
        {
            try
            {
                DaoSP dao = new DaoSP();
                DataTable tabla_Publicacion = new DataTable();

                //Publicacion pub = new Publicacion();

                tabla_Publicacion = dao.ObtenerDatosSP("dropeadores.getPublicacion", fech.getFechaSistema(), fechaDesde, fechaHasta);

                if (tabla_Publicacion == null)
                {
                    cargarTabla();
                }

                var final_rol = "";
                var posFiltro = true;
                var filtrosBusqueda = new List<string>();
                var filtrosCategoria = new List<string>();
                if (descripcion != "") filtrosBusqueda.Add("DESCRIPCION LIKE '%" + descripcion + "%'");
                final_rol = "(";
                for (int i = 0; i < listaCat.Count(); i++)
                {

                    filtrosCategoria.Add("RUBRO_DESCRIPCION LIKE '%" + listaCat[i] + "%'");

                }
                foreach (var filtro in filtrosCategoria)
                {
                    if (!posFiltro)
                        final_rol += " OR " + filtro;
                    else
                    {
                        final_rol += filtro;
                        posFiltro = false;
                    }
                }
                foreach (var filtro in filtrosBusqueda)
                {
                    if (!posFiltro)
                        final_rol += " )AND " + filtro;
                    else
                    {
                        final_rol += filtro;
                        posFiltro = false;
                    }
                }
                //int cant = emp.existEmpresa(razonSocial, cuit, mail);
                if (tabla_Publicacion != null)
                {

                    // error cuando probas por filtrar por 2 campos y alguno es incorrecto
                    tabla_Publicacion.DefaultView.RowFilter = final_rol;
                }
                else
                {
                    tabla_Publicacion = null;
                    dataGridViewCompras.DataSource = null;
                }
                return tabla_Publicacion;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void buttonPAGAR_Click(object sender, EventArgs e)
        {
            
        }
        
        private int tieneTarjeta(Usuario user)
        {
            DataTable dt, dr, da = new DataTable();
            int cant = 0;
            DaoSP dao = new DaoSP();

            dt = dao.ConsultarConQuery("select count(clieteId) from dropeadores.TarjetaCredito t join dropeadores.Cliente c on(c.numeroDocumento=t.clieteId) join dropeadores.Usuario u on (u.clienteId=c.numeroDocumento) where u.username='" + user.username + "'");
            foreach (DataRow row in dt.Rows)
            {
                cant = Convert.ToInt32(row["cantidad"]);
            }

            return cant;
        }
        private void labelubicaciones_Click(object sender, EventArgs e)
        {

        }

        private void labelCategorias_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridViewCompras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnNuevoMedioPago_Click(object sender, EventArgs e)
        {

        }

        private void buttonVOLVER_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonPAGAR_Click_1(object sender, EventArgs e)
        {
           
            if (dataGridViewCompras.CurrentRow == null)
            {
                MessageBox.Show("Seleccione la ubicacion del espectaculo que desea comprar.",
                "", MessageBoxButtons.OK);
                return;
            }
           // string cuit = dataGridViewCompras.CurrentRow.Cells["CUIT"].Value.ToString();
            DialogResult dr = MessageBox.Show("Seguro que desea realizar la compra?", "", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    ConfirmarCompra(ubicacionesSeleccionadas);
                    break;
                case DialogResult.No: break;
            }

        }
        private void ConfirmarCompra(List<Ubicacion> ubicSeleccionadas)
        {
            this.Hide();
            new ConfirmarCompra(ubicSeleccionadas,usuario).Show();

        }

        private void buttonCategoria_Click_1(object sender, EventArgs e)
        {
            ComprarPPAL comprar = this;
            SeleccionCategorias cate = new SeleccionCategorias(labelCategorias.Text, comprar);
            cate.Show();
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {

            if (dateTimePickerDesde.Value.Date > dateTimePickerHasta.Value.Date)
            {
                MessageBox.Show("La segunda fecha no puede ser inferior a la primera \nFECHA 1:" + dateTimePickerDesde.Text + "\nFECHA 2:" + dateTimePickerHasta.Text);
                return;
            }
            DateTime hoy = DateTime.Today;
            if (hoy > dateTimePickerDesde.Value.Date)
            {
                MessageBox.Show("La fecha inicial no puede ser menor que la actual");
                return;
            }


            DataTable respuesta = FiltrarPublicacion(labelCategorias.Text, textDescripcion.Text, dateTimePickerDesde.Value, dateTimePickerHasta.Value, listaCategorias);
            dataGridViewCompras.DataSource = respuesta;
            if (dataGridViewCompras.CurrentRow == null)
            {

                MessageBox.Show("La empresa requerida no se encuentra.", "Baja de Empresa",
                   MessageBoxButtons.OK);

                cargarTabla();
            }


        }

        private void dataGridViewCompras_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            Cliente cliente = new Cliente();
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                string descripcion = dataGridViewCompras.CurrentRow.Cells["DESCRIPCION"].Value.ToString();
                string fila = dataGridViewCompras.CurrentRow.Cells["FILA"].Value.ToString();
                string asiento = dataGridViewCompras.CurrentRow.Cells["ASIENTO"].Value.ToString();
                string precio = dataGridViewCompras.CurrentRow.Cells["PRECIO"].Value.ToString();
                DialogResult dr = MessageBox.Show("Desea seleccionar el espectaculo" + descripcion + " con la fila " + fila + " asiento " + asiento +  "?",
                "", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.Yes:
                       if (dataGridViewCompras.Rows.Count != 0)
                        {
                            String ID = dataGridViewCompras.CurrentRow.Cells["CODIGO"].Value.ToString();
                            Ubicacion ubicacion = new Ubicacion();
                            ubicacion.publicacionId = Convert.ToInt32(ID);
                            ubicacion.fila = Convert.ToChar(fila);
                            ubicacion.asiento = Convert.ToInt32(asiento);
                            ubicacion.precio = Convert.ToDouble(precio);
                            ubicacionesSeleccionadas.Add(ubicacion);
                            cliente.numeroDocumento = usuario.cliente.numeroDocumento;
                            MessageBox.Show("La ubicación con ID " + ID + " fue añadida");
                            int rowindex = dataGridViewCompras.CurrentCell.RowIndex;
                            dataGridViewCompras.Rows.RemoveAt(rowindex);
                        }
                        break;

                    case DialogResult.No:
                        break;
                }

            }

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

    }
}
