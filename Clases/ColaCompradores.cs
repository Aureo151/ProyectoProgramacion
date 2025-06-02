using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacion.Clases
{
    internal class ColaCompradores
    {
        private Queue<Comprador> colaVIP = new Queue<Comprador>();
        private Queue<Comprador> colaNormal = new Queue<Comprador>();

        public void Encolar(Comprador c)
        {
            if (c.EsVIP)
                colaVIP.Enqueue(c);
            else
                colaNormal.Enqueue(c);
        }

        public Comprador Desencolar()
        {
            return colaVIP.Count > 0 ? colaVIP.Dequeue() : colaNormal.Dequeue();
        }

        public bool HayElementos()
        {
            return colaVIP.Count > 0 || colaNormal.Count > 0;
        }
    }
}
