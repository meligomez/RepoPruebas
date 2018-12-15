namespace PalcoNet.Generar_Rendicion_Comisiones
{
    partial class GenerarRendicionComisiones
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerarRendicionComisiones));
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.btnPagarEmpresa = new System.Windows.Forms.Button();
			this.btnVolver = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.lblEmpresa = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lblTotal = new System.Windows.Forms.Label();
			this.lblTotalConComision = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Raleway", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(111, 49);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(576, 35);
			this.label1.TabIndex = 0;
			this.label1.Text = "GENERAR RENDICION DE COMISIONES ";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
			this.pictureBox1.Location = new System.Drawing.Point(26, 22);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(79, 83);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(26, 147);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(1016, 326);
			this.dataGridView1.TabIndex = 2;
			this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
			// 
			// btnPagarEmpresa
			// 
			this.btnPagarEmpresa.Location = new System.Drawing.Point(882, 612);
			this.btnPagarEmpresa.Name = "btnPagarEmpresa";
			this.btnPagarEmpresa.Size = new System.Drawing.Size(188, 42);
			this.btnPagarEmpresa.TabIndex = 3;
			this.btnPagarEmpresa.Text = "Pagar a Empresa";
			this.btnPagarEmpresa.UseVisualStyleBackColor = true;
			this.btnPagarEmpresa.Click += new System.EventHandler(this.btnPagarEmpresa_Click);
			// 
			// btnVolver
			// 
			this.btnVolver.Location = new System.Drawing.Point(26, 612);
			this.btnVolver.Name = "btnVolver";
			this.btnVolver.Size = new System.Drawing.Size(114, 42);
			this.btnVolver.TabIndex = 4;
			this.btnVolver.Text = "Volver";
			this.btnVolver.UseVisualStyleBackColor = true;
			this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(34, 120);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(171, 24);
			this.label2.TabIndex = 5;
			this.label2.Text = "Empresa a rendir:";
			// 
			// lblEmpresa
			// 
			this.lblEmpresa.AutoSize = true;
			this.lblEmpresa.Location = new System.Drawing.Point(197, 120);
			this.lblEmpresa.Name = "lblEmpresa";
			this.lblEmpresa.Size = new System.Drawing.Size(0, 24);
			this.lblEmpresa.TabIndex = 6;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(630, 488);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(180, 24);
			this.label3.TabIndex = 7;
			this.label3.Text = "Total sin Comision:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(630, 524);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(252, 24);
			this.label4.TabIndex = 8;
			this.label4.Text = "Total a rendir c/ Comision:";
			// 
			// lblTotal
			// 
			this.lblTotal.AutoSize = true;
			this.lblTotal.Location = new System.Drawing.Point(807, 488);
			this.lblTotal.Name = "lblTotal";
			this.lblTotal.Size = new System.Drawing.Size(0, 24);
			this.lblTotal.TabIndex = 9;
			// 
			// lblTotalConComision
			// 
			this.lblTotalConComision.AutoSize = true;
			this.lblTotalConComision.Location = new System.Drawing.Point(878, 524);
			this.lblTotalConComision.Name = "lblTotalConComision";
			this.lblTotalConComision.Size = new System.Drawing.Size(0, 24);
			this.lblTotalConComision.TabIndex = 10;
			// 
			// GenerarRendicionComisiones
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Silver;
			this.ClientSize = new System.Drawing.Size(1091, 666);
			this.Controls.Add(this.lblTotalConComision);
			this.Controls.Add(this.lblTotal);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lblEmpresa);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnVolver);
			this.Controls.Add(this.btnPagarEmpresa);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "GenerarRendicionComisiones";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.GenerarRendicionComisiones_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button btnPagarEmpresa;
		private System.Windows.Forms.Button btnVolver;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblEmpresa;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblTotal;
		private System.Windows.Forms.Label lblTotalConComision;
	}
}