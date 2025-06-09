using ProyectoProgramacion.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoProgramacion
{
    public partial class Cancelaciones : Form
    {
        private PilaCancelaciones pilaCancelaciones = new PilaCancelaciones();
        public Cancelaciones()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Cancelaciones_Load(object sender, EventArgs e)
        {
            List<Boleto> cancelados = pilaCancelaciones.ObtenerTodos();

            dataGridViewCancelaciones.DataSource = null;
            dataGridViewCancelaciones.DataSource = cancelados;

            if (dataGridViewCancelaciones.Columns.Contains("QRPath"))
                dataGridViewCancelaciones.Columns["QRPath"].Visible = false;

            dataGridViewCancelaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCancelaciones.ReadOnly = true;
        }
    }
}
