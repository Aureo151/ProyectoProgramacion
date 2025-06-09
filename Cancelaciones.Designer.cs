namespace ProyectoProgramacion
{
    partial class Cancelaciones
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
            this.dataGridViewCancelaciones = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCancelaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCancelaciones
            // 
            this.dataGridViewCancelaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCancelaciones.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewCancelaciones.Name = "dataGridViewCancelaciones";
            this.dataGridViewCancelaciones.RowHeadersWidth = 51;
            this.dataGridViewCancelaciones.RowTemplate.Height = 24;
            this.dataGridViewCancelaciones.Size = new System.Drawing.Size(776, 366);
            this.dataGridViewCancelaciones.TabIndex = 0;
            this.dataGridViewCancelaciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Cancelaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 394);
            this.Controls.Add(this.dataGridViewCancelaciones);
            this.Name = "Cancelaciones";
            this.Text = "Cancelaciones";
            this.Load += new System.EventHandler(this.Cancelaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCancelaciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCancelaciones;
    }
}