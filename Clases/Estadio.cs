using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacion.Clases
{
    internal class Estadio
    {
        public List<Zona> Zonas { get; set; } = new List<Zona>();

        public void CargarDesdeJson(string ruta)
        {
            if (File.Exists(ruta))
            {
                var json = File.ReadAllText(ruta);
                Zonas = JsonConvert.DeserializeObject<List<Zona>>(json);
            }
        }

        public void GuardarEnJson(string ruta)
        {
            var json = JsonConvert.SerializeObject(Zonas, Formatting.Indented);
            File.WriteAllText(ruta, json);
        }
    }
}
