namespace PalcoNet.Abm_Grado
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
			this.txtPorcentaje = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtTipo = new System.Windows.Forms.TextBox();
			this.btnGuardar = new System.Windows.Forms.Button();
			this.btnVolver = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Raleway", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(115, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(175, 35);
			this.label1.TabIndex = 0;
			this.label1.Text = "ABM Grado";
			// 
			// txtPorcentaje
			// 
			this.txtPorcentaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.txtPorcentaje.Location = new System.Drawing.Point(193, 134);
			this.txtPorcentaje.Margin = new System.Windows.Forms.Padding(4);
			this.txtPorcentaje.MaxLength = 255;
			this.txtPorcentaje.Name = "txtPorcentaje";
			this.txtPorcentaje.Size = new System.Drawing.Size(132, 30);
			this.txtPorcentaje.TabIndex = 16;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.label4.Location = new System.Drawing.Point(66, 134);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(111, 25);
			this.label4.TabIndex = 15;
			this.label4.Text = "Porcentaje:";
			// 
			// txtTipo
			// 
			this.txtTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.txtTipo.Location = new System.Drawing.Point(193, 71);
			this.txtTipo.Margin = new System.Windows.Forms.Padding(4);
			this.txtTipo.MaxLength = 255;
			this.txtTipo.Name = "txtTipo";
			this.txtTipo.Size = new System.Drawing.Size(132, 30);
			this.txtTipo.TabIndex = 14;
			// 
			// btnGuardar
			// 
			this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.btnGuardar.Location = new System.Drawing.Point(277, 207);
			this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(145, 38);
			this.btnGuardar.TabIndex = 13;
			this.btnGuardar.Text = "Guardar";
			this.btnGuardar.UseVisualStyleBackColor = true;
			this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
			// 
			// btnVolver
			// 
			this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.btnVolver.Location = new System.Drawing.Point(13, 207);
			this.btnVolver.Margin = new System.Windows.Forms.Padding(4);
			this.btnVolver.Name = "btnVolver";
			this.btnVolver.Size = new System.Drawing.Size(145, 38);
			this.btnVolver.TabIndex = 12;
			this.btnVolver.Text = "Volver";
			this.btnVolver.UseVisualStyleBackColor = true;
			this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.label2.Location = new System.Drawing.Point(66, 71);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 25);
			this.label2.TabIndex = 11;
			this.label2.Text = "Tipo:";
			// 
			// AltaGrado
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Silver;
			this.ClientSize = new System.Drawing.Size(435, 287);
			this.Controls.Add(this.txtPorcentaje);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtTipo);
			this.Controls.Add(this.btnGuardar);
			this.Controls.Add(this.btnVolver);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Raleway", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "AltaGrado";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtPorcentaje;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtTipo;
		private System.Windows.Forms.Button btnGuardar;
		private System.Windows.Forms.Button btnVolver;
		private System.Windows.Forms.Label label2;
	}
}