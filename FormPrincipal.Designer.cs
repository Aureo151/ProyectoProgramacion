namespace ProyectoProgramacion
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnComprar = new System.Windows.Forms.Button();
            this.btnVerTransacciones = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(776, 360);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnComprar
            // 
            this.btnComprar.Location = new System.Drawing.Point(12, 378);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(254, 60);
            this.btnComprar.TabIndex = 1;
            this.btnComprar.Text = "Ir a Comprar";
            this.btnComprar.UseVisualStyleBackColor = true;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // btnVerTransacciones
            // 
            this.btnVerTransacciones.Location = new System.Drawing.Point(538, 378);
            this.btnVerTransacciones.Name = "btnVerTransacciones";
            this.btnVerTransacciones.Size = new System.Drawing.Size(250, 60);
            this.btnVerTransacciones.TabIndex = 2;
            this.btnVerTransacciones.Text = "Ver Transacciones";
            this.btnVerTransacciones.UseVisualStyleBackColor = true;
            this.btnVerTransacciones.Click += new System.EventHandler(this.btnVerTransacciones_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(278, 378);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(254, 60);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cancelacion de Boleto";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnVerTransacciones);
            this.Controls.Add(this.btnComprar);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormPrincipal";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnComprar;
        private System.Windows.Forms.Button btnVerTransacciones;
        private System.Windows.Forms.Button button1;
    }
}

