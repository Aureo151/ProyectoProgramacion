using ProyectoProgramacion.Clases;
using System;
using System.IO;
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
    public partial class FormTransacciones : Form
    {
        private List<Boleto> boletosOriginales;
        public FormTransacciones()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string criterio = txtBuscar.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(criterio))
            {
                MessageBox.Show("Ingrese texto para buscar.");
                return;
            }

            List<Boleto> filtrados = new List<Boleto>();

            if (comboFiltro.SelectedItem.ToString() == "Comprador")
            {
                filtrados = boletosOriginales
                    .FindAll(b => b.Comprador.ToLower().Contains(criterio));
            }
            else if (comboFiltro.SelectedItem.ToString() == "Zona")
            {
                filtrados = boletosOriginales
                    .FindAll(b => b.Zona.ToLower().Contains(criterio));
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = filtrados;

            if (dataGridView1.Columns.Contains("QRPath"))
                dataGridView1.Columns["QRPath"].Visible = false;

            if (filtrados.Count > 0)
            {
                string rutaQR = filtrados[0].QRPath;
                string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, rutaQR);

                if (File.Exists(rutaCompleta))
                {
                    using (var imgTemp = new Bitmap(rutaCompleta))
                    {
                        pictureBoxQR.Image = new Bitmap(imgTemp);
                    }
                }
                else
                {
                    pictureBoxQR.Image = null;
                }
            }
            else
            {
                pictureBoxQR.Image = null;
            }
        }

        private void FormTransacciones_Load(object sender, EventArgs e)
        {
            Transaccion transaccion = new Transaccion();
            boletosOriginales = transaccion.ObtenerBoletos();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = boletosOriginales;

            if (dataGridView1.Columns.Contains("QRPath"))
                dataGridView1.Columns["QRPath"].Visible = false;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            comboFiltro.Items.Clear();
            comboFiltro.Items.Add("Comprador");
            comboFiltro.Items.Add("Zona");
            comboFiltro.SelectedIndex = 0;
        }

        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = boletosOriginales;

            if (dataGridView1.Columns.Contains("QRPath"))
                dataGridView1.Columns["QRPath"].Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
