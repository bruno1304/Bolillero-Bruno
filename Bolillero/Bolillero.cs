using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolillero
{
    public class Bolillero : ICloneable
    {
        public List<byte> adentro { get; set; }
        public List<byte> afuera { get; set; }
        Random r { get; set; }
       

        public Bolillero(byte inicio, byte fin)
        {
            var r = new Random(DateTime.Now.Millisecond);
            this.CargarBolillero(inicio, fin);
        }
        private Bolillero(Bolillero original) : this()
        {
            adentro = new List<byte>(original.adentro);
            afuera = new List<byte>(original.afuera);
        }
        private void CargarBolillero(byte inicio, byte fin)
        {
            for (byte i = inicio; i < fin; i++)
            {
                adentro.Add(i);
            }
        }
        public byte SacarBolilla()
        {
            var indice = 0;
            indice = r.Next(adentro.Count);
            var bolilla = adentro[indice];
            return bolilla;
        }

        public void reingresar()
        {
            adentro.AddRange(afuera);
            afuera.Clear();
        }

        public object Clone()
        {
            return new Bolillero(this);
        }
    }
}
