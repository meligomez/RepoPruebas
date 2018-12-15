namespace PalcoNet.Comprar
{
    partial class ConfirmarCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmarCompra));
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridViewCompra = new System.Windows.Forms.DataGridView();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.labelMedioPago = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNuevoMedioPago = new System.Windows.Forms.Button();
            this.lblPuntos = new System.Windows.Forms.Label();
            this.lblImporte = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonPAGAR = new System.Windows.Forms.Button();
            this.buttonVOLVER = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(117, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(327, 29);
            this.label7.TabIndex = 124;
            this.label7.Text = "CONFIRMACIÓN COMPRAR";
            // 
            // dataGridViewCompra
            // 
            this.dataGridViewCompra.AllowUserToAddRows = false;
            this.dataGridViewCompra.AllowUserToDeleteRows = false;
            this.dataGridViewCompra.AllowUserToResizeColumns = false;
            this.dataGridViewCompra.AllowUserToResizeRows = false;
            this.dataGridViewCompra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCompra.Location = new System.Drawing.Point(132, 112);
            this.dataGridViewCompra.MultiSelect = false;
            this.dataGridViewCompra.Name = "dataGridViewCompra";
            this.dataGridViewCompra.Size = new System.Drawing.Size(743, 263);
            this.dataGridViewCompra.TabIndex = 125;
            this.dataGridViewCompra.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCompra_CellContentClick);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.Location = new System.Drawing.Point(46, 21);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(65, 66);
            this.pictureBox3.TabIndex = 126;
            this.pictureBox3.TabStop = false;
            // 
            // labelMedioPago
            // 
            this.labelMedioPago.AutoSize = true;
            this.labelMedioPago.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelMedioPago.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelMedioPago.Location = new System.Drawing.Point(286, 424);
            this.labelMedioPago.MaximumSize = new System.Drawing.Size(200, 23);
            this.labelMedioPago.MinimumSize = new System.Drawing.Size(200, 23);
            this.labelMedioPago.Name = "labelMedioPago";
            this.labelMedioPago.Size = new System.Drawing.Size(200, 23);
            this.labelMedioPago.TabIndex = 127;
            this.labelMedioPago.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 427);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 13);
            this.label2.TabIndex = 128;
            this.label2.Text = "Seleccione un medio de Pago";
            // 
            // btnNuevoMedioPago
            // 
            this.btnNuevoMedioPago.Location = new System.Drawing.Point(132, 488);
            this.btnNuevoMedioPago.Name = "btnNuevoMedioPago";
            this.btnNuevoMedioPago.Size = new System.Drawing.Size(290, 42);
            this.btnNuevoMedioPago.TabIndex = 129;
            this.btnNuevoMedioPago.Text = "Asociar Medio de Pago";
            this.btnNuevoMedioPago.UseVisualStyleBackColor = true;
            this.btnNuevoMedioPago.Click += new System.EventHandler(this.btnNuevoMedioPago_Click);
            // 
            // lblPuntos
            // 
            this.lblPuntos.AutoSize = true;
            this.lblPuntos.Location = new System.Drawing.Point(728, 491);
            this.lblPuntos.Name = "lblPuntos";
            this.lblPuntos.Size = new System.Drawing.Size(128, 13);
            this.lblPuntos.TabIndex = 133;
            this.lblPuntos.Text = "suma de puntos(readonly)";
            // 
            // lblImporte
            // 
            this.lblImporte.AutoSize = true;
            this.lblImporte.Location = new System.Drawing.Point(728, 427);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(135, 13);
            this.lblImporte.TabIndex = 132;
            this.lblImporte.Text = "suma de importes(readonly)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(508, 491);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 13);
            this.label6.TabIndex = 131;
            this.label6.Text = "Puntos para el cliente:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(570, 434);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 130;
            this.label5.Text = "Importe total:";
            // 
            // buttonPAGAR
            // 
            this.buttonPAGAR.Location = new System.Drawing.Point(841, 510);
            this.buttonPAGAR.Name = "buttonPAGAR";
            this.buttonPAGAR.Size = new System.Drawing.Size(131, 55);
            this.buttonPAGAR.TabIndex = 135;
            this.buttonPAGAR.Text = "PAGAR";
            this.buttonPAGAR.UseVisualStyleBackColor = true;
            this.buttonPAGAR.Click += new System.EventHandler(this.buttonPAGAR_Click);
            // 
            // buttonVOLVER
            // 
            this.buttonVOLVER.Location = new System.Drawing.Point(12, 531);
            this.buttonVOLVER.Name = "buttonVOLVER";
            this.buttonVOLVER.Size = new System.Drawing.Size(71, 33);
            this.buttonVOLVER.TabIndex = 136;
            this.buttonVOLVER.Text = "VOLVER";
            this.buttonVOLVER.UseVisualStyleBackColor = true;
            this.buttonVOLVER.Click += new System.EventHandler(this.buttonVOLVER_Click);
            // 
            // ConfirmarCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1006, 576);
            this.Controls.Add(this.buttonVOLVER);
            this.Controls.Add(this.buttonPAGAR);
            this.Controls.Add(this.lblPuntos);
            this.Controls.Add(this.lblImporte);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnNuevoMedioPago);
            this.Controls.Add(this.labelMedioPago);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.dataGridViewCompra);
            this.Controls.Add(this.label7);
            this.Name = "ConfirmarCompra";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ConfirmarCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridViewCompra;
        private System.Windows.Forms.PictureBox pictureBox3;
        public System.Windows.Forms.Label labelMedioPago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNuevoMedioPago;
        private System.Windows.Forms.Label lblPuntos;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button buttonPAGAR;
        private System.Windows.Forms.Button buttonVOLVER;
	}
}