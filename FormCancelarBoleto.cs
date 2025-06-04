using ProyectoProgramacion.Clases;
using System;
using Newtonsoft.Json;
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
    public partial class FormCancelarBoleto : Form
    {
        private string rutaBoletos = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../boletos.json");
        private string rutaZonas = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../zonas.json");

        private List<Boleto> boletos;
        private Estadio estadio = new Estadio();
        private PilaCancelaciones pilaCancelaciones = new PilaCancelaciones();
        public FormCancelarBoleto()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            int num;
            if (!int.TryParse(txtNumeroBoleto.Text, out num))
            {
                MessageBox.Show("Ingrese un número válido de boleto.");
                return;
            }
          
            if (!File.Exists(rutaBoletos)) return;

            boletos = JsonConvert.DeserializeObject<List<Boleto>>(File.ReadAllText(rutaBoletos));
            estadio.CargarDesdeJson(rutaZonas);

            var boleto = boletos.FirstOrDefault(b => b.Numero == num);
            if (boleto == null)
            {
                MessageBox.Show("Boleto no encontrado.");
                return;
            }

            boletos.Remove(boleto);
            File.WriteAllText(rutaBoletos, JsonConvert.SerializeObject(boletos, Formatting.Indented));

            var zona = estadio.Zonas.FirstOrDefault(z => z.Nombre == boleto.Zona);
            if (zona != null) zona.Disponibles++;

            estadio.GuardarEnJson(rutaZonas);

            pilaCancelaciones.Agregar(boleto);

            MessageBox.Show("Boleto cancelado y agregado a pila de devoluciones.");
            txtNumeroBoleto.Clear();
        }
    }
}
