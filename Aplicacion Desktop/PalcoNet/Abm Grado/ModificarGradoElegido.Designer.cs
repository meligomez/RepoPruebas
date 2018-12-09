namespace PalcoNet.Abm_Grado
{
	partial class ModificarGradoElegido
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
			this.btnVolver = new System.Windows.Forms.Button();
			this.btnGuardar = new System.Windows.Forms.Button();
			this.checkBaja = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtPorcentaje = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtTipo = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnVolver
			// 
			this.btnVolver.Location = new System.Drawing.Point(199, 306);
			this.btnVolver.Name = "btnVolver";
			this.btnVolver.Size = new System.Drawing.Size(121, 38);
			this.btnVolver.TabIndex = 92;
			this.btnVolver.Text = "Volver";
			this.btnVolver.UseVisualStyleBackColor = true;
			this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
			// 
			// btnGuardar
			// 
			this.btnGuardar.Location = new System.Drawing.Point(408, 306);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(121, 38);
			this.btnGuardar.TabIndex = 91;
			this.btnGuardar.Text = "Guardar";
			this.btnGuardar.UseVisualStyleBackColor = true;
			this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
			// 
			// checkBaja
			// 
			this.checkBaja.AutoSize = true;
			this.checkBaja.Location = new System.Drawing.Point(277, 248);
			this.checkBaja.Name = "checkBaja";
			this.checkBaja.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.checkBaja.Size = new System.Drawing.Size(126, 21);
			this.checkBaja.TabIndex = 90;
			this.checkBaja.Text = "Habilitar Grado";
			this.checkBaja.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(236, 76);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(298, 36);
			this.label7.TabIndex = 89;
			this.label7.Text = "MODIFICAR GRADO";
			// 
			// txtPorcentaje
			// 
			this.txtPorcentaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.txtPorcentaje.Location = new System.Drawing.Point(367, 192);
			this.txtPorcentaje.MaxLength = 255;
			this.txtPorcentaje.Name = "txtPorcentaje";
			this.txtPorcentaje.Size = new System.Drawing.Size(100, 30);
			this.txtPorcentaje.TabIndex = 88;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.label4.Location = new System.Drawing.Point(250, 192);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(111, 25);
			this.label4.TabIndex = 87;
			this.label4.Text = "Porcentaje:";
			// 
			// txtTipo
			// 
			this.txtTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.txtTipo.Location = new System.Drawing.Point(313, 141);
			this.txtTipo.MaxLength = 255;
			this.txtTipo.Name = "txtTipo";
			this.txtTipo.Size = new System.Drawing.Size(100, 30);
			this.txtTipo.TabIndex = 86;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.label3.Location = new System.Drawing.Point(250, 141);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 25);
			this.label3.TabIndex = 85;
			this.label3.Text = "Tipo:";
			// 
			// ModificarGradoElegido
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Silver;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.btnVolver);
			this.Controls.Add(this.btnGuardar);
			this.Controls.Add(this.checkBaja);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txtPorcentaje);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtTipo);
			this.Controls.Add(this.label3);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "ModificarGradoElegido";
			this.Text = "ModificarGradoElegidocs";
			this.Load += new System.EventHandler(this.ModificarGradoElegidocs_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnVolver;
		private System.Windows.Forms.Button btnGuardar;
		private System.Windows.Forms.CheckBox checkBaja;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtPorcentaje;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtTipo;
		private System.Windows.Forms.Label label3;
	}
}