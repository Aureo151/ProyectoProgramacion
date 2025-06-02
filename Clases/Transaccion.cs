using System;
using Newtonsoft.Json;
using QRCoder;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacion.Clases
{
    internal class Transaccion
    {
        private int contador = 1;
        private string rutaBoletos = "../../boletos.json";
        private List<Boleto> boletos = new List<Boleto>();

        public Transaccion()
        {
            if (File.Exists(rutaBoletos))
            {
                boletos = JsonConvert.DeserializeObject<List<Boleto>>(File.ReadAllText(rutaBoletos));
                if (boletos.Count > 0)
                    contador = boletos[boletos.Count - 1].Numero + 1; // último número + 1
            }
        }

        public Boleto ProcesarCompra(Comprador comprador, Zona zona)
        {
            if (zona.Disponibles <= 0)
                return null;

            zona.Disponibles--;

            var asiento = $"{zona.Nombre}-{zona.Capacidad - zona.Disponibles}";
            var boleto = comprador.EsVIP ? new BoletoVIP() : new Boleto();

            boleto.Numero = contador++;
            boleto.Zona = zona.Nombre;
            boleto.Asiento = asiento;
            boleto.Comprador = comprador.Nombre;
            boleto.FechaCompra = DateTime.Now;

            // Ruta de QR
            string qrRuta = $"QRs/QR_{boleto.Numero}.png";
            boleto.QRPath = qrRuta;

            // Crear QR
            GenerarCodigoQR(boleto, qrRuta);

            // Guardar
            boletos.Add(boleto);
            GuardarBoletos();

            return boleto;
        }

        private void GuardarBoletos()
        {
            var json = JsonConvert.SerializeObject(boletos, Formatting.Indented);
            File.WriteAllText(rutaBoletos, json);
        }

        private void GenerarCodigoQR(Boleto boleto, string ruta)
        {
            Directory.CreateDirectory("QRs");

            string contenido = $"Boleto #{boleto.Numero}\nZona: {boleto.Zona}\nAsiento: {boleto.Asiento}\nComprador: {boleto.Comprador}";
            QRCodeGenerator qrGenerador = new QRCodeGenerator();
            QRCodeData data = qrGenerador.CreateQrCode(contenido, QRCodeGenerator.ECCLevel.Q);
            QRCode qr = new QRCode(data);

            using (Bitmap imagen = qr.GetGraphic(20))
            {
                imagen.Save(ruta, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        public List<Boleto> ObtenerBoletos()
        {
            return boletos;
        }
    }
}
