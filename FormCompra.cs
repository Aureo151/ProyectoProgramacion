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
    public partial class FormCompra : Form
    {
        private Estadio estadio = new Estadio();
        private Transaccion transaccion = new Transaccion();
        private string rutaZonas = "../../zonas.json";
        public FormCompra()
        {
            InitializeComponent();
            
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre del comprador.");
                return;
            }

            if (comboZonas.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una zona.");
                return;
            }

            string nombreZona = comboZonas.SelectedItem.ToString();
            Zona zonaSeleccionada = estadio.Zonas.Find(z => z.Nombre == nombreZona);

            if (zonaSeleccionada == null)
            {
                MessageBox.Show("Zona no válida.");
                return;
            }

            Comprador comprador = new Comprador()
            {
                Nombre = txtNombre.Text,
                ZonaDeseada = zonaSeleccionada.Nombre,
                EsVIP = checkBoxVIP.Checked
            };

            Boleto boleto = transaccion.ProcesarCompra(comprador, zonaSeleccionada);

            if (boleto != null)
            {              
                if (!string.IsNullOrEmpty(boleto.QRPath) && File.Exists(boleto.QRPath))
                {
                    using (var tempImg = new Bitmap(boleto.QRPath))
                    {
                        pictureBoxQR.Image = new Bitmap(tempImg);
                    }
                }

                MessageBox.Show($"Compra exitosa.\nNúmero de boleto: {boleto.Numero}\nAsiento: {boleto.Asiento}");
                estadio.GuardarEnJson(rutaZonas); 
            }
            else
            {
                MessageBox.Show("No hay boletos disponibles.");
            }
        }

        private void FormCompra_Load(object sender, EventArgs e)
        {
            estadio.CargarDesdeJson(rutaZonas);
            comboZonas.Items.Clear();

            foreach (Zona z in estadio.Zonas)
            {
                comboZonas.Items.Add(z.Nombre);
            }

            if (comboZonas.Items.Count > 0)
                comboZonas.SelectedIndex = 0;
        }
    }
}
