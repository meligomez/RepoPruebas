namespace PalcoNet.Listado_Estadistico
{
    partial class ListadoEstadistico
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListadoEstadistico));
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.Filtros = new System.Windows.Forms.GroupBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnFiltroFecha = new System.Windows.Forms.Button();
			this.s = new System.Windows.Forms.ComboBox();
			this.cbxTrimestre = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.lblTrimestre = new System.Windows.Forms.Label();
			this.grafico = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.Filtros.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grafico)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Raleway", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(89, 36);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(369, 39);
			this.label1.TabIndex = 0;
			this.label1.Text = "LISTADO ESTADISTICO";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
			this.pictureBox1.Location = new System.Drawing.Point(12, 25);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(62, 50);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// Filtros
			// 
			this.Filtros.Controls.Add(this.comboBox1);
			this.Filtros.Controls.Add(this.label4);
			this.Filtros.Controls.Add(this.btnFiltroFecha);
			this.Filtros.Controls.Add(this.s);
			this.Filtros.Controls.Add(this.cbxTrimestre);
			this.Filtros.Controls.Add(this.label3);
			this.Filtros.Controls.Add(this.lblTrimestre);
			this.Filtros.Location = new System.Drawing.Point(12, 105);
			this.Filtros.Name = "Filtros";
			this.Filtros.Size = new System.Drawing.Size(1087, 227);
			this.Filtros.TabIndex = 2;
			this.Filtros.TabStop = false;
			this.Filtros.Text = "Filtros de Fechas";
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "Empresas con mayor cantidad de localidades no vendidas",
            "Clientes con mayores puntos vencidos",
            "Clientes con mayor cantidad de compras"});
			this.comboBox1.Location = new System.Drawing.Point(330, 101);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(463, 32);
			this.comboBox1.TabIndex = 8;
			this.comboBox1.Text = "Seleccione una opcion ";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(28, 109);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(362, 24);
			this.label4.TabIndex = 7;
			this.label4.Text = "Seleccione una Estadisica a consultar:";
			// 
			// btnFiltroFecha
			// 
			this.btnFiltroFecha.Location = new System.Drawing.Point(819, 151);
			this.btnFiltroFecha.Name = "btnFiltroFecha";
			this.btnFiltroFecha.Size = new System.Drawing.Size(204, 46);
			this.btnFiltroFecha.TabIndex = 3;
			this.btnFiltroFecha.Text = "Buscar Estadistica";
			this.btnFiltroFecha.UseVisualStyleBackColor = true;
			this.btnFiltroFecha.Click += new System.EventHandler(this.btnFiltroFecha_Click);
			// 
			// s
			// 
			this.s.FormattingEnabled = true;
			this.s.Location = new System.Drawing.Point(176, 47);
			this.s.Name = "s";
			this.s.Size = new System.Drawing.Size(214, 32);
			this.s.TabIndex = 6;
			this.s.Text = "Seleccione un año";
			this.s.SelectedIndexChanged += new System.EventHandler(this.anioChange);
			// 
			// cbxTrimestre
			// 
			this.cbxTrimestre.FormattingEnabled = true;
			this.cbxTrimestre.Items.AddRange(new object[] {
            "Primer",
            "Segundo",
            "Tercero"});
			this.cbxTrimestre.Location = new System.Drawing.Point(637, 42);
			this.cbxTrimestre.Name = "cbxTrimestre";
			this.cbxTrimestre.Size = new System.Drawing.Size(268, 32);
			this.cbxTrimestre.TabIndex = 5;
			this.cbxTrimestre.Text = "Seleccione un Trimestre";
			this.cbxTrimestre.Visible = false;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(28, 50);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(186, 24);
			this.label3.TabIndex = 4;
			this.label3.Text = "Seleccione un año:";
			// 
			// lblTrimestre
			// 
			this.lblTrimestre.AutoSize = true;
			this.lblTrimestre.Location = new System.Drawing.Point(440, 50);
			this.lblTrimestre.Name = "lblTrimestre";
			this.lblTrimestre.Size = new System.Drawing.Size(239, 24);
			this.lblTrimestre.TabIndex = 3;
			this.lblTrimestre.Text = "Seleccione un Trimestre:";
			this.lblTrimestre.Visible = false;
			// 
			// grafico
			// 
			chartArea1.Name = "ChartArea1";
			this.grafico.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.grafico.Legends.Add(legend1);
			this.grafico.Location = new System.Drawing.Point(556, 355);
			this.grafico.Name = "grafico";
			this.grafico.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Grayscale;
			series1.ChartArea = "ChartArea1";
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			this.grafico.Series.Add(series1);
			this.grafico.Size = new System.Drawing.Size(543, 334);
			this.grafico.TabIndex = 4;
			this.grafico.Text = "chart2";
			this.grafico.Visible = false;
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 357);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(530, 332);
			this.dataGridView1.TabIndex = 5;
			this.dataGridView1.Visible = false;
			// 
			// ListadoEstadistico
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.Silver;
			this.ClientSize = new System.Drawing.Size(1143, 701);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.grafico);
			this.Controls.Add(this.Filtros);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "ListadoEstadistico";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.ListadoEstadistico_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.Filtros.ResumeLayout(false);
			this.Filtros.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grafico)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.GroupBox Filtros;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblTrimestre;
		private System.Windows.Forms.Button btnFiltroFecha;
		private System.Windows.Forms.ComboBox s;
		private System.Windows.Forms.ComboBox cbxTrimestre;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DataVisualization.Charting.Chart grafico;
		private System.Windows.Forms.DataGridView dataGridView1;
	}
}