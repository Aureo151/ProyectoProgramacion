using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacion.Clases
{
    internal class PilaCancelaciones
    {
        private Stack<Boleto> pila = new Stack<Boleto>();
        private readonly string ruta = "cancelaciones.json";

        public PilaCancelaciones()
        {
            if (File.Exists(ruta))
            {
                var lista = JsonConvert.DeserializeObject<List<Boleto>>(File.ReadAllText(ruta));
                pila = new Stack<Boleto>(lista);
            }
        }

        public void Agregar(Boleto b)
        {
            pila.Push(b);
            Guardar();
        }

        public Boleto Reasignar()
        {
            if (pila.Count == 0) return null;

            Boleto b = pila.Pop();
            Guardar();
            return b;
        }

        public bool HayCancelados() => pila.Count > 0;

        private void Guardar()
        {
            File.WriteAllText(ruta, JsonConvert.SerializeObject(pila, Formatting.Indented));
        }

        public List<Boleto> ObtenerTodos()
        {
            return new List<Boleto>(pila);
        }
    }
}
