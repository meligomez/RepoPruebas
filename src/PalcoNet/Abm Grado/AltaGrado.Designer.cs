﻿namespace PalcoNet.Abm_Grado
{
    partial class AltaGrado
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
			this.label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtTipo = new System.Windows.Forms.TextBox();
			this.btnGuardar = new System.Windows.Forms.Button();
			this.btnVolver = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.nota = new System.Windows.Forms.Label();
			this.txtPorcentaje = new System.Windows.Forms.MaskedTextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(153, 27);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(172, 36);
			this.label1.TabIndex = 0;
			this.label1.Text = "ABM Grado";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.label4.Location = new System.Drawing.Point(95, 126);
			this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(111, 25);
			this.label4.TabIndex = 15;
			this.label4.Text = "Porcentaje:";
			// 
			// txtTipo
			// 
			this.txtTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.txtTipo.Location = new System.Drawing.Point(159, 82);
			this.txtTipo.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.txtTipo.MaxLength = 255;
			this.txtTipo.Name = "txtTipo";
			this.txtTipo.Size = new System.Drawing.Size(166, 30);
			this.txtTipo.TabIndex = 14;
			// 
			// btnGuardar
			// 
			this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.btnGuardar.Location = new System.Drawing.Point(357, 203);
			this.btnGuardar.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(193, 47);
			this.btnGuardar.TabIndex = 13;
			this.btnGuardar.Text = "Guardar";
			this.btnGuardar.UseVisualStyleBackColor = true;
			this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
			// 
			// btnVolver
			// 
			this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.btnVolver.Location = new System.Drawing.Point(5, 203);
			this.btnVolver.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.btnVolver.Name = "btnVolver";
			this.btnVolver.Size = new System.Drawing.Size(193, 47);
			this.btnVolver.TabIndex = 12;
			this.btnVolver.Text = "Volver";
			this.btnVolver.UseVisualStyleBackColor = true;
			this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.label2.Location = new System.Drawing.Point(88, 87);
			this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 25);
			this.label2.TabIndex = 11;
			this.label2.Text = "Tipo:";
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label21.Location = new System.Drawing.Point(309, 132);
			this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(90, 17);
			this.label21.TabIndex = 111;
			this.label21.Text = "Nro sin \"%\"";
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label24.Location = new System.Drawing.Point(334, 82);
			this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(14, 17);
			this.label24.TabIndex = 112;
			this.label24.Text = "*";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(268, 126);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(14, 17);
			this.label3.TabIndex = 113;
			this.label3.Text = "*";
			this.label3.Click += new System.EventHandler(this.label3_Click);
			// 
			// nota
			// 
			this.nota.AutoSize = true;
			this.nota.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.nota.Location = new System.Drawing.Point(365, 66);
			this.nota.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.nota.Name = "nota";
			this.nota.Size = new System.Drawing.Size(164, 17);
			this.nota.TabIndex = 114;
			this.nota.Text = "*Campos Obligatorios";
			// 
			// txtPorcentaje
			// 
			this.txtPorcentaje.Location = new System.Drawing.Point(203, 129);
			this.txtPorcentaje.Mask = "9999";
			this.txtPorcentaje.Name = "txtPorcentaje";
			this.txtPorcentaje.Size = new System.Drawing.Size(58, 22);
			this.txtPorcentaje.TabIndex = 115;
			this.txtPorcentaje.ValidatingType = typeof(int);
			// 
			// AltaGrado
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Silver;
			this.ClientSize = new System.Drawing.Size(580, 353);
			this.Controls.Add(this.txtPorcentaje);
			this.Controls.Add(this.nota);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label24);
			this.Controls.Add(this.label21);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtTipo);
			this.Controls.Add(this.btnGuardar);
			this.Controls.Add(this.btnVolver);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "AltaGrado";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtTipo;
		private System.Windows.Forms.Button btnGuardar;
		private System.Windows.Forms.Button btnVolver;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label nota;
		private System.Windows.Forms.MaskedTextBox txtPorcentaje;
	}
}