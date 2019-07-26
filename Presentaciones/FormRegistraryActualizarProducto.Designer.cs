namespace Presentaciones
{
    partial class FormRegistraryActualizarProducto
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
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.txtdes = new System.Windows.Forms.TextBox();
            this.txtnom = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtcan = new System.Windows.Forms.NumericUpDown();
            this.txtpreven = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtprecomp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelid = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtcan)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardarCambios.AutoSize = true;
            this.btnGuardarCambios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(51)))), ((int)(((byte)(72)))));
            this.btnGuardarCambios.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGuardarCambios.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btnGuardarCambios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGuardarCambios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGuardarCambios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarCambios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarCambios.ForeColor = System.Drawing.Color.Silver;
            this.btnGuardarCambios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarCambios.Location = new System.Drawing.Point(150, 262);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(185, 30);
            this.btnGuardarCambios.TabIndex = 57;
            this.btnGuardarCambios.Text = "Guardar cambios";
            this.btnGuardarCambios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardarCambios.UseVisualStyleBackColor = false;
            this.btnGuardarCambios.Click += new System.EventHandler(this.btnGuardarCambios_Click);
            // 
            // txtdes
            // 
            this.txtdes.Location = new System.Drawing.Point(190, 53);
            this.txtdes.Multiline = true;
            this.txtdes.Name = "txtdes";
            this.txtdes.Size = new System.Drawing.Size(289, 195);
            this.txtdes.TabIndex = 55;
            // 
            // txtnom
            // 
            this.txtnom.Location = new System.Drawing.Point(40, 53);
            this.txtnom.Name = "txtnom";
            this.txtnom.Size = new System.Drawing.Size(104, 20);
            this.txtnom.TabIndex = 54;
            this.txtnom.TextChanged += new System.EventHandler(this.txtnom_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(36, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(121, 19);
            this.label11.TabIndex = 52;
            this.label11.Text = "Cantidad (Stock)";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(186, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 19);
            this.label10.TabIndex = 51;
            this.label10.Text = "Descripcion";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(36, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 19);
            this.label9.TabIndex = 50;
            this.label9.Text = "Nombre";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // txtcan
            // 
            this.txtcan.Location = new System.Drawing.Point(40, 107);
            this.txtcan.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtcan.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.txtcan.Name = "txtcan";
            this.txtcan.Size = new System.Drawing.Size(104, 20);
            this.txtcan.TabIndex = 58;
            this.txtcan.ValueChanged += new System.EventHandler(this.txtcan_ValueChanged);
            // 
            // txtpreven
            // 
            this.txtpreven.Location = new System.Drawing.Point(40, 219);
            this.txtpreven.Name = "txtpreven";
            this.txtpreven.Size = new System.Drawing.Size(104, 20);
            this.txtpreven.TabIndex = 60;
            this.txtpreven.TextChanged += new System.EventHandler(this.txtpreven_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(36, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 19);
            this.label1.TabIndex = 59;
            this.label1.Text = "Precio de venta";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtprecomp
            // 
            this.txtprecomp.Location = new System.Drawing.Point(40, 163);
            this.txtprecomp.Name = "txtprecomp";
            this.txtprecomp.Size = new System.Drawing.Size(104, 20);
            this.txtprecomp.TabIndex = 62;
            this.txtprecomp.TextChanged += new System.EventHandler(this.txtprecomp_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(36, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 19);
            this.label2.TabIndex = 61;
            this.label2.Text = "Precio de compra";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // labelid
            // 
            this.labelid.AutoSize = true;
            this.labelid.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelid.ForeColor = System.Drawing.Color.White;
            this.labelid.Location = new System.Drawing.Point(444, 9);
            this.labelid.Name = "labelid";
            this.labelid.Size = new System.Drawing.Size(23, 19);
            this.labelid.TabIndex = 63;
            this.labelid.Text = "Id";
            // 
            // FormRegistraryActualizarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(491, 307);
            this.Controls.Add(this.labelid);
            this.Controls.Add(this.txtprecomp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtpreven);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtcan);
            this.Controls.Add(this.btnGuardarCambios);
            this.Controls.Add(this.txtdes);
            this.Controls.Add(this.txtnom);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Name = "FormRegistraryActualizarProducto";
            this.Text = "FormRegistraryActualizarProducto";
            this.Load += new System.EventHandler(this.FormRegistraryActualizarProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtcan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardarCambios;
        private System.Windows.Forms.TextBox txtdes;
        private System.Windows.Forms.TextBox txtnom;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown txtcan;
        private System.Windows.Forms.TextBox txtpreven;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtprecomp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelid;
    }
}