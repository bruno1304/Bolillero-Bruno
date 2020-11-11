using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolillero
{
    class Simulacion
    {
        Bolillero bolillero = new Bolillero();

        public bool Jugar (List<byte> jugadas)
        {
            var comparar = 0;
            bolillero.reingresar();
            foreach (var bolillaJugada in jugadas)
            {
                comparar = bolillero.SacarBolilla();
                if (comparar != bolillaJugada)
                {
                    return false;
                }
            }
            return true;
        }
        public long jugarNveces (List<byte> jugadas, long cantJugadas)
        {
            long cantGanados = 0;
            for (int i = 0; i < cantGanados; i++)
            {
             
                if (this.Jugar(jugadas) == true)
                {
                    cantGanados++;
                }
            }
            return cantGanados;
        }
    }
}
