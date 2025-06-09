using System;
using ProyectoProgramacion.Clases;
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
    public partial class FormPrincipal : Form
    {
        private Estadio estadio = new Estadio();
        private string rutaZonas = "../../zonas.json";
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            estadio.CargarDesdeJson(rutaZonas);
            CargarZonasEnGrid();
        }
        private void CargarZonasEnGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = estadio.Zonas;
            dataGridView1.Columns["Nombre"].HeaderText = "Zona";
            dataGridView1.Columns["Capacidad"].HeaderText = "Capacidad";
            dataGridView1.Columns["Disponibles"].HeaderText = "Disponibles";
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            
                FormCompra formCompra = new FormCompra();
                formCompra.ShowDialog();

                // Recargar zonas desde JSON actualizado
                estadio.CargarDesdeJson(rutaZonas);
                CargarZonasEnGrid();
                     
        }

        private void btnVerTransacciones_Click(object sender, EventArgs e)
        {
            FormTransacciones formTransacciones = new FormTransacciones();
            formTransacciones.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormCancelarBoleto formCancelarBoleto = new FormCancelarBoleto();
            formCancelarBoleto.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cancelaciones cancelaciones = new Cancelaciones();
            cancelaciones.ShowDialog();
        }
    }
}
