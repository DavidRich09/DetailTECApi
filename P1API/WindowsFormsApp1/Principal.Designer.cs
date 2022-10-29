namespace WindowsFormsApp1
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.BtnClientePts = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TBCliente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnLavado = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Planilla = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.Factura = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnClientePts
            // 
            this.BtnClientePts.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClientePts.Location = new System.Drawing.Point(161, 434);
            this.BtnClientePts.Name = "BtnClientePts";
            this.BtnClientePts.Size = new System.Drawing.Size(222, 51);
            this.BtnClientePts.TabIndex = 4;
            this.BtnClientePts.Text = "Generar Reporte";
            this.BtnClientePts.UseVisualStyleBackColor = true;
            this.BtnClientePts.Click += new System.EventHandler(this.BtnClientePts_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(243, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(669, 162);
            this.label1.TabIndex = 5;
            this.label1.Text = "Bienvenido al Asistente\r\nde Reportes";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 307);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(514, 82);
            this.label2.TabIndex = 6;
            this.label2.Text = "Clientes con la mayor cantidad \r\nde puntos redimidos";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montserrat", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(747, 307);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(343, 82);
            this.label3.TabIndex = 7;
            this.label3.Text = "Historial de Lavados \r\nde un Cliente";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TBCliente
            // 
            this.TBCliente.Font = new System.Drawing.Font("Montserrat Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBCliente.Location = new System.Drawing.Point(918, 386);
            this.TBCliente.Name = "TBCliente";
            this.TBCliente.Size = new System.Drawing.Size(123, 32);
            this.TBCliente.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Montserrat", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(800, 385);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 32);
            this.label4.TabIndex = 9;
            this.label4.Text = "Cédula: ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnLavado
            // 
            this.BtnLavado.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLavado.Location = new System.Drawing.Point(806, 434);
            this.BtnLavado.Name = "BtnLavado";
            this.BtnLavado.Size = new System.Drawing.Size(222, 51);
            this.BtnLavado.TabIndex = 10;
            this.BtnLavado.Text = "Generar Reporte";
            this.BtnLavado.UseVisualStyleBackColor = true;
            this.BtnLavado.Click += new System.EventHandler(this.BtnLavado_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Montserrat", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(132, 636);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(280, 41);
            this.label5.TabIndex = 11;
            this.label5.Text = "Planilla Semanal";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Planilla
            // 
            this.Planilla.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Planilla.Location = new System.Drawing.Point(161, 725);
            this.Planilla.Name = "Planilla";
            this.Planilla.Size = new System.Drawing.Size(222, 51);
            this.Planilla.TabIndex = 12;
            this.Planilla.Text = "Generar Reporte";
            this.Planilla.UseVisualStyleBackColor = true;
            this.Planilla.Click += new System.EventHandler(this.Planilla_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Montserrat", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(812, 636);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(216, 41);
            this.label6.TabIndex = 13;
            this.label6.Text = "Facturación ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Factura
            // 
            this.Factura.BackColor = System.Drawing.Color.Transparent;
            this.Factura.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Factura.Location = new System.Drawing.Point(806, 725);
            this.Factura.Name = "Factura";
            this.Factura.Size = new System.Drawing.Size(222, 51);
            this.Factura.TabIndex = 14;
            this.Factura.Text = "Generar Reporte";
            this.Factura.UseVisualStyleBackColor = false;
            this.Factura.Click += new System.EventHandler(this.Factura_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1022, 54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 159);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 51);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(154, 159);
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1182, 863);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Factura);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Planilla);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BtnLavado);
            this.Controls.Add(this.TBCliente);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnClientePts);
            this.Name = "Principal";
            this.Text = "Asistente de Reportes";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnClientePts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBCliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnLavado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Planilla;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Factura;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}