using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacion.Clases
{
    internal class Boleto
    {
        public int Numero { get; set; }
        public string Zona { get; set; }
        public string Asiento { get; set; }
        public string Comprador { get; set; }
        public DateTime FechaCompra { get; set; }
        public string QRPath { get; set; }
    }
}
